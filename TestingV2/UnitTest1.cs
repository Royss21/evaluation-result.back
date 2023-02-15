using Application.Dto.Config.Formula;
using Application.Dto.Config.Subcomponent;
using Application.Main.Services.Config.Interfaces;
using Moq;

namespace TestingV2
{
    public class UnitTest1
    {

        public UnitTest1()
        {
        }

        [Fact]
        public async Task GetSubcomponentById()
        {
            var id = new Guid("D38F679E-A6A5-403C-99F0-032F3528B534");
            var mock = new Mock<ISubcomponentService>();
            mock.Setup(s => s.GetByIdAsync(id))
                    .ReturnsAsync(new SubcomponentDto { 
                        Name = "Subcomponente 11 COMPETE"
                    });

            var response = await mock.Object.GetByIdAsync(id);


            Assert.Equal("Subcomponente 11 COMPETE", response.Name);
            Assert.IsType<SubcomponentDto>(response);
        }

        [Fact]
        public async Task CreateFormula()
        {
            var formulaCreate = new FormulaCreateDto
            {
                Description = "Formula de calculo",
                Name = "Nombre de la formula",
                FormulaQuery = "Formula conevtida en query",
                FormulaReal = "Formula real en base a funcion excel"
            };

            var mock = new Mock<IFormulaService>();
            mock.Setup(s => s.CreateAsync(formulaCreate))
                    .ReturnsAsync(new FormulaDto {
                        Id= new Guid("0FEF6000-AA34-40F1-AB47-1E42D750EF1E"),
                        Description = "Formula de calculo",
                        Name = "Nombre de la formula",
                        FormulaQuery = "Formula conevtida en query",
                        FormulaReal = "Formula real en base a funcion excel"
                    });

            var response = await mock.Object.CreateAsync(formulaCreate);


            Assert.NotNull(response);
            Assert.IsType<Guid>(response.Id);
            Assert.IsType<FormulaDto>(response);
        }

    }
}