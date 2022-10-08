namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Collaborator.Interfaces;

    public class ChargeRepository : BaseRepository<Charge, int>, IChargeRepository
    {
        public ChargeRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
