namespace Nulab.Backlog.Api
{
    public interface IBacklogClient
    {
        IUsers Users { get; }

        ISpace Space { get; }

        IProjects Projects { get; }
    }
}