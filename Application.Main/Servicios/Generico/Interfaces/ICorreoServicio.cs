
namespace Application.Main.Servicios.Generico.Interfaces
{
    using Domain.Common.Enums;
    using SharedKernell.Email;
    using Microsoft.AspNetCore.Mvc;

    public interface ICorreoServicio : IEmailHelper
    {
        string CargarCuerpoCorreo<TModel>(CorreoTemplateEnum template, Controller context, TModel model) where TModel : class;
    }
}
