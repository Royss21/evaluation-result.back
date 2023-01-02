﻿namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;
    using Application.Main.Services.EvaResult.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/evaluation-collaborator")]
    [ApiController]
    public class EvaluationCollaboratorController : BaseController
    {
        private readonly IEvaluationCollaboratorService _evaluationCollaboratorService;
        private readonly ILogger<EvaluationCollaboratorController> _logger;

        public EvaluationCollaboratorController(IEvaluationCollaboratorService evaluationCollaboratorService, ILogger<EvaluationCollaboratorController> logger)
        {
            _evaluationCollaboratorService = evaluationCollaboratorService;
            _logger = logger;
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada colaboradores de la evaluacion",
        Description = "lista paginada colaboradores de la evaluacion",
        OperationId = "EvaluationCollaborator.GetAllPaging",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<EvaluationCollaboratorPagingDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _evaluationCollaboratorService.GetPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<EvaluationCollaboratorPagingDto>>(result));
        }

        [HttpGet("{id}/evaluation-result/{evaluationId}")]
        [SwaggerOperation(
        Summary = "Obtener datos de resultado de la evaluacion",
        Description = "obtener datos de resultado de la evaluacion",
        OperationId = "EvaluationCollaborator.GetEvaluationResultById",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationCollaboratorResultDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEvaluationResultById(Guid id, Guid evaluationId)
        {
            var result = await _evaluationCollaboratorService.GetEvaluationResultByIdAsync(evaluationId, id);
            return new OkObjectResult(new JsonResult<EvaluationCollaboratorResultDto>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Agregar Colaborador a Evaluacion",
        Description = "Agregar Colaborador a Evaluacion",
        OperationId = "EvaluationCollaborator.Create",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationCollaboratorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(EvaluationCollaboratorCreateDto request)
        {
            var result = await _evaluationCollaboratorService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<EvaluationCollaboratorDto>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Colaborador de la Evaluacion",
        Description = "Eliminar Colaborador de la Evaluacion",
        OperationId = "EvaluationCollaborator.Delete",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _evaluationCollaboratorService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar estado de etapa de la evaluacion",
        Description = "Actualizar estado de etapa de la evaluacion",
        OperationId = "EvaluationCollaborator.SaveCommentEvaluationStage",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveCommentEvaluationStage(CommentEvaluationDto request)
        {
            var result = await _evaluationCollaboratorService.SaveCommentEvaluationStageAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
