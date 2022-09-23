namespace Api.Services.Ayudantes
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    public class ProducesResponseProvider : IApplicationModelProvider
    {
        public int Order => 3;

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            foreach (ControllerModel controller in context.Result.Controllers)
            {
                foreach (ActionModel action in controller.Actions)
                {
                    if (!controller.ControllerName.Contains("Autenticacion"))
                    {
                        action.Filters.Add(new ProducesResponseTypeAttribute(typeof(JsonErrorResult), StatusCodes.Status401Unauthorized));
                        action.Filters.Add(new ProducesResponseTypeAttribute(typeof(JsonErrorResult), StatusCodes.Status403Forbidden));
                    }

                    action.Filters.Add(new ProducesResponseTypeAttribute(typeof(JsonResult), StatusCodes.Status204NoContent));
                    action.Filters.Add(new ProducesResponseTypeAttribute(typeof(JsonErrorResult), StatusCodes.Status400BadRequest));                       
                    action.Filters.Add(new ProducesResponseTypeAttribute(typeof(JsonErrorResult), StatusCodes.Status404NotFound));
                    action.Filters.Add(new ProducesResponseTypeAttribute(typeof(JsonErrorResult), StatusCodes.Status500InternalServerError));
                }
            }
        }
    }
}
