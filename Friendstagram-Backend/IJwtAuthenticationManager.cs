using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
    }
}
