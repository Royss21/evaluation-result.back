namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.Config.EvaluationLeader;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Dto.Pagination;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Microsoft.AspNetCore.Mvc;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationLeaderController : BaseController
    {
        private readonly IEvaluationLeaderService _evaluationLeaderService;
        private readonly ILogger<EvaluationController> _logger;

        public EvaluationLeaderController(IEvaluationLeaderService evaluationLeaderService, ILogger<EvaluationController> logger)
        {
            _evaluationLeaderService = evaluationLeaderService;
            _logger = logger;
        }

       
        [HttpPost("ImportFileLeaders")]
        [SwaggerOperation(
        Summary = "Importar Masivo Evaluacion Lideres ",
        Description = "Importar EvaluationLeader",
        OperationId = "EvaluationLeader.ImportBulk",
        Tags = new[] { "EvaluationLeaderService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ImportBulk([FromForm]EvaluationLeaderFileDto request)
        {           
            var result = await _evaluationLeaderService.ImportBulkAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }



        [HttpGet("DownloadTemplate/{componentId}")]
        [SwaggerOperation(
        Summary = "Descargar plantilla de importacion",
        Description = "Descargar Plantilla",
        OperationId = "EvaluationLeader.DownloadTemplate",
        Tags = new[] { "EvaluationLeaderService" })]
        public IActionResult DescargarPlantillaCompetencia(int componentId)
        {
            var rutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
            var ruta = @$"{rutaArchivo}/{GeneralConstants.Component.FileNameTemplates[componentId]}";
            var contenidoArchivo = new FileContentResult(System.IO.File.ReadAllBytes(ruta), "applicaction/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            contenidoArchivo.FileDownloadName = GeneralConstants.Component.FileNameTemplates[componentId];

            return contenidoArchivo;
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Lideres",
        Description = "lista paginada de Lideres",
        OperationId = "EvaluationLeader.GetAllPaging",
        Tags = new[] { "EvaluationLeaderService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<EvaluationLeaderDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] EvaluationLeaderFilterDto filter)
        {
            var result = await _evaluationLeaderService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<EvaluationLeaderDto>>(result));
        }
    }
}
