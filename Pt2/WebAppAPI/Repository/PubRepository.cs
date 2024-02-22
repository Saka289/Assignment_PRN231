using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Data;
using WebAppAPI.Models.Dtos;

namespace WebAppAPI.Repository
{
    public class PubRepository : IPubRepository
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;
        public PubRepository(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<PubDto> GetAllPubs()
        {
            try
            {
                var result = _context.Publishers.ToList();
                IEnumerable<PubDto> bookDtos = _mapper.Map<IEnumerable<PubDto>>(result);
                return bookDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
