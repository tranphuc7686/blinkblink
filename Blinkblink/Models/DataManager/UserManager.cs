using Blinkblink.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Models.DataManager
{
    public class UserManager : IDataRepository<User>
    {
        readonly DBBlinkContext _dBBlinkContext;
        public UserManager(DBBlinkContext context)
        {
            _dBBlinkContext = context;
        }
        public void Add(User entity)
        {
            _dBBlinkContext.Users.Add(entity);
            _dBBlinkContext.SaveChanges();
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            _dBBlinkContext.Users.Remove(entity);
            _dBBlinkContext.SaveChanges();
        }

        public User Get(string id)
        {
            return _dBBlinkContext.Users
                .FirstOrDefault(e => e.Id.Equals(id));
        }

        public IEnumerable<User> GetAll()
        {
            return _dBBlinkContext.Users.ToList();
        }

        public void Update(User dbEntity, User entity)
        {

            _dBBlinkContext.SaveChanges();
        }
    }
}
