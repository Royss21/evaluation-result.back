namespace Application.Main.Servicios.Entidades
{
    using Application.Main.Services.General.Interfaces;
    using Domain.Common.Enums;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using SharedKernell.Mail;

    public class MailService : MailHelper, IMailService
    {

        private readonly ILogger<MailService> _logger;
        public MailService(
            IOptions<MailConfiguration> mailConfig,
            ILogger<MailService> logger
        ) : base(mailConfig)
        {
            _logger = logger;
        }

        public string UploadBodyMail<TModel>(MailTemplateEnum template, Controller context, TModel model) where TModel : class
        => template switch
        {
            MailTemplateEnum.EmailLeader => RenderViewToString(context, "~/Vistas/TemplateMailLeader.cshtml", model),
            MailTemplateEnum.EmailCollaboratorStageApproval => RenderViewToString(context, "~/Vistas/TemplateMailCollaboratorStageApproval.cshtml", model),
            _ => ""
        };



    }
}
