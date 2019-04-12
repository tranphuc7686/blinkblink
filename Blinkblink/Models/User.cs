using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumer { get; set; }
        //list image
        public ICollection<Image> Images { get; set; }

        public void Add(int a)
        {
            throw new NotImplementedException();
        }

        public void Add(string a)
        {
            throw new NotImplementedException();
        }
    }
}
