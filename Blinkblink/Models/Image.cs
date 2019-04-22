using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Url { get; set; }
        public DateTime DateTime { get; set; }
        public int IsVideo { get; set; }
        public string IdImageRoot { get; set; }



        //get data
        public Idol Idol { get; set; }
        public User User { get; set; }
    }
}
