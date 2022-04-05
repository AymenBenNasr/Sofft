using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Dtos.Auth;

namespace Application.Interfaces
{
    public interface CandidatRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetOldUsers(int count);
        AuthResponse Authenticate(LoginDto login); 

        
    }
}
