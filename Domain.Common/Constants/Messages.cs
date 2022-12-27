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
            public const string FieldNonEmpty = "El campo no puede estar vacio";
            public const string EmailAlreadyRegistered = "El Correo ingresado ya se encuentra registrado";
            public const string NameAlreadyRegistered = "El Nombre ingresado ya se encuentra registrado";
            public const string DescriptionAlreadyRegistered = "La descripcion ingresada ya se encuentra registrado";
            public const string PhoneAlreadyRegistered = "El Telefono ingresado ya se encuentra registrado";
            public const string MovilAlreadyRegistered = "El Movil ingresado ya se encuentra registrado";
            public const string CodeAlreadyRegistered = "El Código ingresado ya se encuentra registrado";
            public const string RangeDatesIsNotValid = "El intervalo de fechas ingresadas es incorrecta y/o existe en otros registros.";
        }

        public static class Level 
        {
            public const string FormulaAlreadyRegistered = "La formula ingresada ya se encuentra registrado";
        }

        public static class HierarchyComponent
        {
            public const string SumWeightIsGreater = "La suma de los componentes no puede ser mayor a 100.";
            public const string SomeComponentHasZeroWeight = "Algun componente tiene el peso en valor 0";
        }

        public static class Subcomponent
        {
            public const string AreaRequired = "El Area es requerida";
            public const string FormulaRequired = "La Formula es requerida";
        }

        public static class SubcomponentValue
        {
            public const string RelativeWeightOutRange = "El peso relativo debe tener un valor entre 1 y 100";
            public const string PercentageMinimumOutRange = "El % minimo debe tener un valor mayor a 0";
            public const string PercentageMaximumOutRange = "El % maximo debe tener un valor mayor a 0";
            public const string PercentageValidate = "El % minimo no debe ser mayor al % maximo";
        }

        public static class Collaborator
        {
            public const string ChargeRequired = "El Cargo es requerido";
        }

        public static class Hierarchy
        {
            public const string LevelRequired = "El nivel es requerido";
        }

        public static class Charge
        {
            public const string AreaRequired = "El área es requerida";
            public const string HierarchyRequired = "La jerarquía es requerida";
        }

    }
}
