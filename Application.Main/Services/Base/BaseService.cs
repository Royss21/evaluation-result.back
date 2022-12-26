
namespace Application.Main.Service.Base
{
    using ExcelDataReader;
    using Infrastructure.UnitOfWork.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public class BaseService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IUnitOfWorkApp _unitOfWorkApp;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;
        //public readonly UsuarioApp UsuarioActual;

        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _unitOfWorkApp = serviceProvider.GetService<IUnitOfWorkApp>();
            _mapper = serviceProvider.GetService<IMapper>();
            _configuration = serviceProvider.GetService<IConfiguration>();
            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();

            var request = httpContextAccessor?.HttpContext?.Request;
            //UsuarioActual = new UsuarioApp(httpContextAccessor?.HttpContext?.User);
        }

        public ExcelDataSetConfiguration ConfigurarDataReader()
        {
            return new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    FilterRow = (rowReader) => rowReader.Depth > 2,
                    UseHeaderRow = true,
                    ReadHeaderRow = (rowReader) => { rowReader.Read(); rowReader.Read(); },
                    FilterColumn = (rowReader, columnIndex) => columnIndex > 0
                }
            };
        }
    }
}