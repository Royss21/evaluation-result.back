
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.Formula;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using DocumentFormat.OpenXml.Office.Word;
    using Domain.Common.Constants;
    using Domain.Main.Config;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Data.SqlClient;

    public class FormulaService : BaseService, IFormulaService
    {
        public FormulaService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<FormulaDto> CreateAsync(FormulaCreateDto request)
        {
            var formula = _mapper.Map<Formula>(request);
            var resultValidator = await _unitOfWorkApp.Repository.FormulaRepository
                    .AddAsync(formula, new FormulaCreateUpdateValidator(_unitOfWorkApp.Repository.FormulaRepository));

            await ValidateFormula(formula.FormulaQuery);

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<FormulaDto>(formula);
        }

        public async Task<bool> UpdateAsync(FormulaUpdateDto request)
        {
            var formula = _mapper.Map<Formula>(request);

            await ValidateFormula(formula.FormulaQuery);

            var resultValidator = await _unitOfWorkApp.Repository.FormulaRepository
                   .UpdateAsync(formula, new FormulaCreateUpdateValidator(_unitOfWorkApp.Repository.FormulaRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var formula = await _unitOfWorkApp.Repository.FormulaRepository.GetAsync(id);

            if (formula is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.FormulaRepository.DeleteAsync(formula);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<FormulaDto>> GetAllAsync()
        {
            var formulas = await _unitOfWorkApp.Repository.FormulaRepository
                    .All()
                    .ProjectTo<FormulaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return formulas;
        }

        public async Task<PaginationResultDto<FormulaDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<FormulaDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Formula, FormulaDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.Description.ToString().ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.FormulaRepository.FindAllPagingAsync(parametersDomain);
            var formulas = await paging.Entities.ProjectTo<FormulaDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<FormulaDto>
            {
                Count = paging.Count,
                Entities = formulas
            };
        }

        public async Task<FormulaDto> GetByIdAsync(Guid id)
        {
            var formula = await _unitOfWorkApp.Repository.FormulaRepository
                   .Find(c => c.Id.Equals(id))
                   .ProjectTo<FormulaDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();

            if (formula is null)
                throw new WarningException(Messages.General.ResourceNotFound);
            return formula;
        }


        private async Task ValidateFormula(string formulaQuerySql)
        {
            var parametersRangeInternal = await _unitOfWorkApp.Repository.ParameterRangeRepository
                    .Find(f => f.IsInternalConfiguration)
                    .Include(i => i.ParametersValue)
                    .FirstAsync();

            foreach (var parameterValue in parametersRangeInternal.ParametersValue)
            {
                if (formulaQuerySql.Contains(parameterValue.Name))
                    formulaQuerySql = formulaQuerySql.Replace(parameterValue.Name, "1");
            }

            try
            {
                await CalculateFormulaCompliance(formulaQuerySql);
            }
            catch (SqlException e)
            {
                throw new WarningException("La formula ingresada no tiene el formato correcto");
            }
        }

        private async Task<decimal> CalculateFormulaCompliance(string formulaQuerySql)
        {
            return (await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .RunSqlQuery<decimal>("[dbo].[uspCalculateFormulaCompliance]", new { formulaQuerySql }))
                    .FirstOrDefault();
        }

        public async Task<bool> ExistInObjectiveCorporative(Guid id)
        {
            return await _unitOfWorkApp.Repository.SubcomponentRepository
                   .Find(f => f.ComponentId == GeneralConstants.Component.CorporateObjectives
                         && f.FormulaId.Equals(id))
                   .AnyAsync();
        }
    }
}
