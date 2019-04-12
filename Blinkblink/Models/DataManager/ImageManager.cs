using Blinkblink.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Models.DataManager
{
    public class ImageManager : IDataRepository<Image>
    {
        readonly DBBlinkContext _dBBlinkContext;
        public ImageManager(DBBlinkContext context)
        {
            _dBBlinkContext = context;
        }
        public void Add(Image entity)
        {
            _dBBlinkContext.Images.Add(entity);
            _dBBlinkContext.SaveChanges();
            throw new NotImplementedException();
        }

        public void Delete(Image entity)
        {
            _dBBlinkContext.Images.Remove(entity);
            _dBBlinkContext.SaveChanges();
        }

        public Image Get(string id)
        {
            return _dBBlinkContext.Images
                .FirstOrDefault(e => e.Id.Equals(id));
        }

        public IEnumerable<Image> GetAll()
        {
            return _dBBlinkContext.Images.ToList();
        }

        public void Update(Image dbEntity, Image entity)
        {

            _dBBlinkContext.SaveChanges();
        }
    }
}
