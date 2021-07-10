namespace Nulab.Backlog.Api
{
    using Nulab.Backlog.Api.Data.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBacklogClient
    {
        IUsers Users { get; }

        ISpace Space { get; }

        IProjects Projects { get; }

        Task<BacklogResponse<List<Priority>>> GetPrioritiesAsync();
    }
}