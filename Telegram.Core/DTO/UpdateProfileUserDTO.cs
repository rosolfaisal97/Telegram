using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class UpdateProfileUserDTO
    {

        public int U_id { get; set; }
        public string U_first_name { get; set; }
        public string U_middle_name { get; set; }
        public string U_last_name { get; set; }
        public string U_image_path { get; set; }
        public string U_gender { get; set; }
        
        public string L_email { get; set; }
        public string L_phone { get; set; }
       
    }
}
