namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class LabelDetailRepository : BaseRepository<LabelDetail, int>, ILabelDetailRepository
    {
        public LabelDetailRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
