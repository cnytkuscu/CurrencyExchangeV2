using Common;
using Common.DTOs;
using Common.Entities;
using RegisterService.Interfaces;

namespace RegisterService.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext _context;

        public RegisterRepository(AppDbContext context)
        {
            _context = context;
        }
         
    }
}
