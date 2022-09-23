namespace Application.Main.Servicios.Entidades
{
    using Application.Main.Servicios.Generico.Interfaces;
    using Domain.Common.Enums;
    using SharedKernell.Email;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class CorreoServicio : EmailHelper, ICorreoServicio
    {

        private readonly ILogger<CorreoServicio> _logger;
        public CorreoServicio(
            IOptions<EmailConfiguracion> emailConfiguracion,
            ILogger<CorreoServicio> logger
        ) : base(emailConfiguracion)
        {
            _logger = logger;
        }

        public string CargarCuerpoCorreo<TModel>(CorreoTemplateEnum template, Controller context, TModel model) where TModel : class
        => template switch
        {
            CorreoTemplateEnum.CorreoPrueba => RenderizarVistaAString(context, "~/Vistas/CorreoPrueba.cshtml", model),
             _=> ""
        };



    }
}
