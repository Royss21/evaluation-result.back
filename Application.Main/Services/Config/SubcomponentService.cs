
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class SubcomponentService : BaseService, ISubcomponentService
    {
        public SubcomponentService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<SubcomponentDto> CreateAsync(SubcomponentCreateDto request)
        {
            var subcomponent = _mapper.Map<Subcomponent>(request);
            var resultValidator = await _unitOfWorkApp.Repository.SubcomponentRepository
                    .AddAsync(subcomponent, new SubcomponentCreateUpdateValidator(_unitOfWorkApp.Repository.SubcomponentRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<SubcomponentDto>(subcomponent);
        }

        public async Task<bool> UpdateAsync(SubcomponentUpdateDto request)
        {
            var subcomponent = _mapper.Map<Subcomponent>(request);
            var resultValidator = await _unitOfWorkApp.Repository.SubcomponentRepository
                                .UpdateAsync(subcomponent, new SubcomponentCreateUpdateValidator(_unitOfWorkApp.Repository.SubcomponentRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var subcomponent = await _unitOfWorkApp.Repository.SubcomponentRepository
                .Find(f => f.Id.Equals(id), false)
                .Include("Conducts")
                .Include("SubcomponentValues")
                .FirstOrDefaultAsync();

            if (subcomponent is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.SubcomponentRepository.DeleteAsync(subcomponent);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<PaginationResultDto<SubcomponentDto>> GetAllPagingAsync(SubcomponentFilterDto filter)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<SubcomponentDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Subcomponent, SubcomponentDto>(_mapper);

            parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.ComponentId == filter.ComponentId);

            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                                                .AddCondition(add => add.Name.ToLower().Contains(filter.GlobalFilter.ToLower()) ||
                                                                     add.Description.ToLower().Contains(filter.GlobalFilter.ToLower()) ||
                                                                     add.Area.Name.ToLower().Contains(filter.GlobalFilter.ToLower()) ||
                                                                     add.Formula.Name.ToLower().Contains(filter.GlobalFilter.ToLower()));

                //if (new[] { GeneralConstants.Component.AreaObjectives, GeneralConstants.Component.CorporateObjectives}.Contains(filter.ComponentId))
                //    parametersDomain.FilterWhere = parametersDomain.FilterWhere
                //                                    .AddCondition(add => add.Area.Name.ToLower().Contains(filter.GlobalFilter.ToLower()) ||
                //                                                         add.Formula.Name.ToLower().Contains(filter.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.SubcomponentRepository.FindAllPagingAsync(parametersDomain);
            var Subcomponents = await paging.Entities.ProjectTo<SubcomponentDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<SubcomponentDto>
            {
                Count = paging.Count,
                Entities = Subcomponents
            };
        }

        public async Task<SubcomponentDto> GetByIdAsync(Guid id)
        {
            var Subcomponent = await _unitOfWorkApp.Repository.SubcomponentRepository
                   .Find(c => c.Id.Equals(id))
                   .ProjectTo<SubcomponentDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();

            if (Subcomponent is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            return Subcomponent;
        }
    }
}
