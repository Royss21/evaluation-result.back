namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.Color;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;

    public class ImagenServicio : BaseServicio, IImagenServicio
    {
        public ImagenServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        { }


        Task<IEnumerable<ImagenDto>> IImagenServicio.ObtenerTodoAsync()
        {
            throw new NotImplementedException();
        }

        Task<PaginacionResultadoDto<ImagenDto>> IImagenServicio.ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CrearAsync(ImagenCrearDto request)
        {
            var ext = (Path.GetExtension(request.Archivo.FileName) ?? "").ToLower();
            var nombreArchivo = $"{request.Archivo.FileName.Replace(" ", "_").Replace(ext, "")}_{DateTime.UtcNow.ObtenerFechaPeru():dd_MM_yyyy_hh_mm_ss_ffffff}{ext}";

            using (var ms = new MemoryStream())
            {
                request.Archivo.CopyTo(ms);
                await StorageBlobHelper.SubirAsync(_configuration.GetSection("ConnectionStrings:AzureDefaultConnection").Value,
                    "chloeatelier",
                    nombreArchivo,
                    Convert.ToBase64String(ms.ToArray()));
            }

            var imagen = new Imagen
            {
                Contenedor = "chloeatelier",
                Nombre = request.Archivo.FileName,
                NombreArchivo = nombreArchivo,
                RutaImagen = ""
            };

            await _unitOfWorkApp.Repositorio.ImagenRepositorio.AddAsync(imagen);
            await _unitOfWorkApp.SaveChangesAsync();

            return imagen.Id;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var imagen = await _unitOfWorkApp.Repositorio.ImagenRepositorio.GetAsync(id);

            if (imagen is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            var seEliminoBlob = await StorageBlobHelper.EliminarAsync(_configuration.GetSection("ConnectionStrings:AzureDefaultConnection").Value,
                   "chloeatelier",
                   imagen.NombreArchivo);

            if (!seEliminoBlob)
                throw new AdvertenciaExcepcion("No se pudo eliminar el archivo del contenedor");

            await _unitOfWorkApp.Repositorio.ImagenRepositorio.DeleteAsync(imagen);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
    }
}
