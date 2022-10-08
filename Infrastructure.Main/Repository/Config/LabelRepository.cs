namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class LabelRepository : BaseRepository<Label, int>, ILabelRepository
    {
        public LabelRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
