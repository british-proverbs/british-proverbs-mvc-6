using System.Threading.Tasks;
using BritishProverbs.Domain.Models;

namespace BritishProverbs.Domain
{
    public interface IBritishProverbsContext
    {
        Task<ProverbModel> GetRandomAsync();
        Task<int> GetVisitsCountAsync();
        Task RecordVisitAsync(string ipAddress);
    }
}