namespace Application.Main.AutoMapper
{
    public static class AutoMapperConfiguracion
    {
        public static void Configure()
        {
            var configuration = new MapperConfiguration(x => { x.AddMaps(typeof(AutoMapperConfiguracion)); });
        }
    }
}
