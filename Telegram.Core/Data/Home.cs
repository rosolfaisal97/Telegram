using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Telegram.Core.Data
{
    public class Home
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string img { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
         ,ErrorMessage = "Please Enter Valid Email Address")]
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }



    }
}
