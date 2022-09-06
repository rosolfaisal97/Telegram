using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Telegram.Core.Data
{
    public class Visa
    {

        [Key]
        public int id { get; set; }
        public string  Name { get; set; }
        public string SecrtNum { get; set; }
        public int Balance { get; set; }
    }
}
