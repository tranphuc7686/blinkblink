using Blinkblink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Services
{
    public class UserHepler
    {
        
        private DBBlinkContext _dBBlinkContext;
        public UserHepler(DBBlinkContext dBBlinkContext)
        {
            _dBBlinkContext = dBBlinkContext;
        }
        public bool IsAuthenticated(string username, string password)
        {
            return _dBBlinkContext.Users.Any(e => e.Id.Equals(username) && e.Password.Equals(password));
        }
    }
}
