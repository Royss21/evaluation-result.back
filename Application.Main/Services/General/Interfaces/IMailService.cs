
namespace Application.Main.Services.General.Interfaces
{
    using Domain.Common.Enums;
    using Microsoft.AspNetCore.Mvc;
    using SharedKernell.Mail;

    public interface IMailService : IMailHelper
    {
        string UploadBodyMail<TModel>(MailTemplateEnum template, Controller context, TModel model) where TModel : class;
    }
}
