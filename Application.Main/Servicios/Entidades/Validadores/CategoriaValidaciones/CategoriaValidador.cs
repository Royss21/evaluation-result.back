
namespace Domain.Main.Validadores.CategoriaValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class CategoriaCrearValidador : ValidadorBase<Categoria>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaCrearValidador(ICategoriaRepositorio categoriaRepositorio) : base()
        {
            _categoriaRepositorio = categoriaRepositorio;

            RuleFor(x => x)
                .MustAsync((categoria, cancel) => CategoriaValidadorCompartido.NombreUnico(_categoriaRepositorio, categoria))
                .WithMessage(Mensajes.General.NombreYaRegistrado);

             RuleFor(x => x)
                .MustAsync((categoria, cancel) => CategoriaValidadorCompartido.AbreviaturaUnico(_categoriaRepositorio, categoria))
                .WithMessage(Mensajes.General.AbreviaturaYaRegistrado);
        }
    }

    public class CategoriaActualizarValidador : ValidadorBase<Categoria>
    {
        private ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaActualizarValidador(ICategoriaRepositorio categoriaRepositorio) : base()
        {
            _categoriaRepositorio = categoriaRepositorio;

            RuleFor(x => x)
                .MustAsync((categoria, cancel) => CategoriaValidadorCompartido.NombreUnico(_categoriaRepositorio, categoria))
                .WithMessage(Mensajes.General.NombreYaRegistrado);

            RuleFor(x => x)
                .MustAsync((categoria, cancel) => CategoriaValidadorCompartido.AbreviaturaUnico(_categoriaRepositorio, categoria))
                .WithMessage(Mensajes.General.AbreviaturaYaRegistrado);
        }
    }

    public static class CategoriaValidadorCompartido
    {

        public static async Task<bool> NombreUnico(ICategoriaRepositorio categoriaRepositorio, Categoria categoria)
        {

            var predicado = PredicateBuilder.New<Categoria>(true);

            if (categoria.Id != 0)
                predicado.And(p => p.Id != categoria.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), categoria.Nombre.ToLower().Trim()));

            //if (categoria.Id != 0)
            //    filter.Add(new ColumnsFilter { Field = "Id", Value = categoria.Id.ToString(), Operator = FiltroModoCoincidenciaConst.NotEquals });

            //filter.Add(new ColumnsFilter { Field = "Nombre", Value = categoria.Nombre.ToString(), Operator = FiltroModoCoincidenciaConst.Equals });
            //var filtro = LambdaManager.ConvertToLambda<Categoria>(filter);

            var resultado = await categoriaRepositorio
                .Find(predicado)
                .FirstOrDefaultAsync();

            return resultado is null ;
        }

        public static async Task<bool> AbreviaturaUnico(ICategoriaRepositorio categoriaRepositorio, Categoria categoria)
        {

            if (string.IsNullOrWhiteSpace(categoria.Codigo))
                return true;

            var predicado = PredicateBuilder.New<Categoria>(true);

            if (categoria.Id != 0)
                predicado.And(p => p.Id != categoria.Id);

            predicado.And(x => EF.Functions.Like(x.Codigo.ToLower().Trim(), categoria.Codigo.ToLower().Trim()));

            var resultado = await categoriaRepositorio
                .Find(predicado)
                .FirstOrDefaultAsync();

            return resultado is null;
        }
    }
}
