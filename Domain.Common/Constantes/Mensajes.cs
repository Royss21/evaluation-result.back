namespace Domain.Common.Constantes
{
    public static class Mensajes
    {
        public static class MemoriaCache
        {
            public const string UsuarioEndpointsBloqueados = "endpoints-bloqueados-usuario-";
        }
        public static class Autenticacion
        {
            public const string EndpointProhibido = "Endpoint acceso prohibido";
            public const string NoAutorizado = "No Autorizado";
            public const string ContraseniaIncorrecta = "La contraseña ingresada es incorrecta";
            public const string RolNoAsignado = "El usuario no tiene algun rol asignado";
            public const string TokenInvalido = "El token es invalido";
            public const string TokenNoCaducado = "No se puede actualizar ya que el token no ha caducado";
            public const string IniciarSesion = "Debe volver a iniciar sesión";
        }

        public static class General
        {
            public const string RecursoNoEncontrado = "El recurso no ha sido encontrado - ({0})";
            public const string NombreYaRegistrado = "El Nombre ingresado ya se encuentra registrado";
            public const string NombreNoVacio = "El Nombre no puede estar vacio";
            public const string CorreoYaRegistrado = "El Correo ingresado ya se encuentra registrado";
            public const string TelefonoYaRegistrado = "El Telefono ingresado ya se encuentra registrado";
            public const string MovilYaRegistrado = "El Movil ingresado ya se encuentra registrado";
            public const string AbreviaturaYaRegistrado = "La Abreviatura ingresada ya se encuentra registrado";
        }
    }
}
