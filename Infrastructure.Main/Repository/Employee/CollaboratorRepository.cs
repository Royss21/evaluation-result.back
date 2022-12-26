namespace Infrastructure.Main.Repository.Employee
{
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class CollaboratorRepository : BaseRepository<Collaborator, Guid>, ICollaboratorRepository
    {
        public CollaboratorRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
