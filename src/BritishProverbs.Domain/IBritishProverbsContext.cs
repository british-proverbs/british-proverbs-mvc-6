using System.Threading.Tasks;
using BritishProverbs.Domain.Models;

namespace BritishProverbs.Domain
{
    public interface IBritishProverbsContext
    {
        Task<ProverbModel> GetRandomAsync();
        Task RecordVisitAsync(string ipAddress);
    }
}