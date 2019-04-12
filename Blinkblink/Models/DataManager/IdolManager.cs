using Blinkblink.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Models.DataManager
{ 
    public class IdolManager : IDataRepository<Idol>
    {
        readonly DBBlinkContext _dBBlinkContext;
        public IdolManager(DBBlinkContext context)
        {
            _dBBlinkContext = context;
        }
        public void Add(Idol entity)
        {
            _dBBlinkContext.Idols.Add(entity);
            _dBBlinkContext.SaveChanges();
            throw new NotImplementedException();
        }

        public void Delete(Idol entity)
        {
            _dBBlinkContext.Idols.Remove(entity);
            _dBBlinkContext.SaveChanges();
        }

        public Idol Get(string id)
        {
            return _dBBlinkContext.Idols
                .FirstOrDefault(e => e.Id.Equals(id));
        }

        public IEnumerable<Idol> GetAll()
        {
            return _dBBlinkContext.Idols.ToList();
        }

        public void Update(Idol dbEntity, Idol entity)
        {

            _dBBlinkContext.SaveChanges();
        }
    }
}
