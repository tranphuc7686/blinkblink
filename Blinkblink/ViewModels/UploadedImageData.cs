using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.ViewModels
{
    public class UploadedImageData
    {
        [Required]
        public string Caption { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
