using Blinkblink.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinkblink.Services
{
    public class HomeHelper
    {
        private DBBlinkContext _dBBlinkContext;
        public HomeHelper(DBBlinkContext dBBlinkContext)
        {
            _dBBlinkContext = dBBlinkContext;
        }
        public void AddPathFilesProcess(string caption,string filePath, Idol idol,User user , int typeData)
        {
            Image image = new Image { Id = RandomId(16, true), Name = caption, DateTime = DateTime.Now, IdolId = idol.Id, UserId = user.Id, Url = filePath, IsVideo = typeData, IdImageRoot = "" };
            _dBBlinkContext.Images.Add(image);
            _dBBlinkContext.SaveChanges();

        }
        public string RandomId(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
   
   
}
