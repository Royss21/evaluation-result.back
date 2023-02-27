namespace Application.Main.Services.Employee
{
    using Domain.Main.Employee;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Gerency;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Main.Services.Employee.Validators;
    using Domain.Common.Constants;

    public class GerencyService : BaseService, IGerencyService
    {
        public GerencyService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<GerencyDto> CreateAsync(GerencyCreateDto request)
        {
            var gerency = _mapper.Map<Gerency>(request);
            var resultValidator = await _unitOfWorkApp.Repository.GerencyRepository
                .AddAsync(gerency, new GerencyCreateUpdateValidation(_unitOfWorkApp.Repository.GerencyRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();
            return _mapper.Map<GerencyDto>(gerency);
        }

        public async Task<bool> UpdateAsync(GerencyUpdateDto request)
        {
            var gerency = _mapper.Map<Gerency>(request);
            var resultValidator = await _unitOfWorkApp.Repository.GerencyRepository
                .UpdateAsync(gerency, new GerencyCreateUpdateValidation(_unitOfWorkApp.Repository.GerencyRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GerencyDto>> GetAllAsync()
        {
            var gerencies = await _unitOfWorkApp.Repository.GerencyRepository
                    .All()
                    .ProjectTo<GerencyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return gerencies;
        }

        public async Task<PaginationResultDto<GerencyDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<GerencyDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Gerency, GerencyDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.GerencyRepository.FindAllPagingAsync(parametersDomain);
            var gerencies = await paging.Entities.ProjectTo<GerencyDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<GerencyDto>
            {
                Count = paging.Count,
                Entities = gerencies
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var gerency =  await _unitOfWorkApp.Repository.GerencyRepository.GetAsync(id);

            if (gerency is null)
                throw new WarningException(Messages.General.ResourceNotFound);
            
            await _unitOfWorkApp.Repository.GerencyRepository.DeleteAsync(gerency);
            await _unitOfWorkApp.SaveChangesAsync();
            
            return true;
        }
    }
}
