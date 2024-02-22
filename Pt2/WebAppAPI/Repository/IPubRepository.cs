using WebAppAPI.Models.Dtos;

namespace WebAppAPI.Repository
{
    public interface IPubRepository
    {
        IEnumerable<PubDto> GetAllPubs();
    }
}
