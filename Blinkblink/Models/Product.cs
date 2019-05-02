using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Information { get; set; }

        //list image product
        public ICollection<ImageProduct> ImageProducts { get; set; }

        //get data
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
