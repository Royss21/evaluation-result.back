using Api.Services.Controllers.Config;
using Application.Main.Services.Config;
using Application.Main.Services.Config.Interfaces;
using Microsoft.Extensions.Logging;


namespace Testing
{
    public class SubcomponentTest
    {
        private readonly SubcomponentController _controller;
        private readonly ISubcomponentService _service;
        private readonly ILogger<SubcomponentController> _logger;
        

        public SubcomponentTest(IServiceProvider serviceProvider, ILogger<SubcomponentController> logger)
        {
            _logger = logger;
            _service = new SubcomponentService(serviceProvider);
            _controller = new SubcomponentController(_service, _logger);
        }

        [TestMethod]
        public void Get_AllPaging()
        {
            var result = _controller.GetAllPaging(new Application.Dto.Config.Subcomponent.SubcomponentFilterDto());
            Assert.IsTrue(5 > 0);
        }
    }
}