namespace Infrastructure.Main.Repository.Employee
{
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class ChargeRepository : BaseRepository<Charge, int>, IChargeRepository
    {
        public ChargeRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
