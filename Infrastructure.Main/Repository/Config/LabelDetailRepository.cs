namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class LabelDetailRepository : BaseRepository<LabelDetail, int>, ILabelDetailRepository
    {
        public LabelDetailRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
