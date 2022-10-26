namespace Domain.Common.Constants
{
    public static class Messages
    {
        public static class MemoryCache
        {
            public const string UserEndpointLocked = "user-endpoint-locked-";
        }
        public static class Authentication
        {
            public const string EndpointForbidden = "Endpoint acceso prohibido";
            public const string NoAuthorize = "No Autorizado";
            public const string RoleNotAssigned = "El usuario no tiene algun rol asignado";
            public const string InvalidPassword = "La contraseña ingresada es incorrecta";
            public const string InvalidToken = "El token es invalido";
            public const string NotExpiredToken = "No se puede actualizar ya que el token no ha caducado";
            public const string ReLogging = "Debe volver a iniciar sesión";
        }

        public static class General
        {
            public const string ResourceNotFound = "El recurso no ha sido encontrado - ({0})";
            public const string NameNonEmpty = "El Nombre no puede estar vacio";
            public const string EmailAlreadyRegistered = "El Correo ingresado ya se encuentra registrado";
            public const string NameAlreadyRegistered = "El Nombre ingresado ya se encuentra registrado";
            public const string PhoneAlreadyRegistered = "El Telefono ingresado ya se encuentra registrado";
            public const string MovilAlreadyRegistered = "El Movil ingresado ya se encuentra registrado";
            public const string CodeAlreadyRegistered = "El Código ingresado ya se encuentra registrado";
            public const string RangeDatesIsNotValid = "El intervalo de fechas ingresadas es incorrecta y/o existe en otros registros.";
        }
    }
}
