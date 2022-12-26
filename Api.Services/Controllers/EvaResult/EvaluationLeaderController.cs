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

    [Route("api/evaluation-leader")]
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

       
        [HttpPost("import-leaders")]
        [SwaggerOperation(
        Summary = "Importar Masivo Evaluacion Lideres ",
        Description = "Importar EvaluationLeader",
        OperationId = "EvaluationLeader.ImportLeaders",
        Tags = new[] { "EvaluationLeaderService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ImportLeaders([FromForm]EvaluationLeaderFileDto request)
        {           
            var result = await _evaluationLeaderService.ImportLeadersAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }


        [HttpGet("component/{componentId}/download-template")]
        [SwaggerOperation(
        Summary = "Descargar plantilla de importacion",
        Description = "Descargar Plantilla",
        OperationId = "EvaluationLeader.DownloadTemplate",
        Tags = new[] { "EvaluationLeaderService" })]
        public IActionResult DownloadTemplate(int componentId)
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

        [HttpGet("{id}/collaborators")]
        [SwaggerOperation(
        Summary = "Lista de collaboradores asignados al lider",
        Description = "Lista de collaboradores asignados al lider",
        OperationId = "EvaluationLeader.GetAllCollaboratorByLeader",
        Tags = new[] { "EvaluationLeaderService" })]
        [ProducesResponseType(typeof(JsonResult<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCollaboratorByLeader(int id, [FromQuery] LeaderCollaboratorsFilterDto filter)
        {
            var result = await _evaluationLeaderService.GetAllCollaboratorByLeaderAsync(id, filter);
           
            return new OkObjectResult(new JsonResult<object>(new { countTotal = result.Item2, collaborators = result.Item1 }));
        }

        [HttpGet("component/{componentId}/exists-previous-import")]
        [SwaggerOperation(
        Summary = "Existe importacion previa",
        Description = "Existe importacion previa",
        OperationId = "EvaluationLeader.ExistsPreviousImport",
        Tags = new[] { "EvaluationLeaderService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExistsPreviousImport(int componentId)
        {
            var result = await _evaluationLeaderService.ExistsPreviousImportAsync(componentId);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
