
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.ParameterValue;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class ParameterValueService : BaseService, IParameterValueService
    {
        public ParameterValueService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<ParameterValueDto> CreateAsync(ParameterValueCreateDto request)
        {
            var parameterValue = _mapper.Map<ParameterValue>(request);

            await _unitOfWorkApp.Repository.ParameterValueRepository.AddAsync(parameterValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<ParameterValueDto>(parameterValue);
        }

        public async Task<bool> UpdateAsync(ParameterValueUpdateDto request)
        {
            var parameterValue = _mapper.Map<ParameterValue>(request);

            await _unitOfWorkApp.Repository.ParameterValueRepository.UpdateAsync(parameterValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parameterValue = await _unitOfWorkApp.Repository.ParameterValueRepository.GetAsync(id);

            if (parameterValue is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.ParameterValueRepository.DeleteAsync(parameterValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<List<ParameterValueDto>> GetAllByParameterRangeAsync(Guid parameterRangeId)
        {
            var parametersValue = await _unitOfWorkApp.Repository.ParameterValueRepository
                   .Find(c => c.ParameterRangeId.Equals(parameterRangeId))
                   .ProjectTo<ParameterValueDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();

            return parametersValue;
        }
    }
}
