
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.Conduct;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class ConductService : BaseService, IConductService
    {
        public ConductService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<ConductDto> CreateAsync(ConductCreateDto request)
        {
            var conduct = _mapper.Map<Conduct>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ConductRepository
                    .AddAsync(conduct, new ConductCreateUpdateValidator(_unitOfWorkApp.Repository.ConductRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<ConductDto>(conduct);
        }

        public async Task<bool> UpdateAsync(ConductUpdateDto request)
        {
            var conduct = _mapper.Map<Conduct>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ConductRepository
                    .UpdateAsync(conduct, new ConductCreateUpdateValidator(_unitOfWorkApp.Repository.ConductRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var conduct = await _unitOfWorkApp.Repository.ConductRepository.GetAsync(id);

            if (conduct is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.ConductRepository.DeleteAsync(conduct);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<List<ConductDto>> GetAllBySubcomponentAsync(Guid subcomponentId)
        {
            var conduct = await _unitOfWorkApp.Repository.ConductRepository
                   .Find(c => c.SubcomponentId.Equals(subcomponentId))
                   .ProjectTo<ConductDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();

            if (!conduct.Any())
                throw new WarningException(Messages.General.ResourceNotFound);

            return conduct;
        }
    }
}
