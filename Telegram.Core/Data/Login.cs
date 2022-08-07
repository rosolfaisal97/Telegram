using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Login
    {
       
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|]).{8,32}$", ErrorMessage = "Please Enter Valid Password")]
        public string password { get; set; }
        public string phone { get; set; }
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
          , ErrorMessage = "Please Enter Valid Email Address")]
        public string email { get; set; }
        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Role role  { get; set; }

        public ICollection<User> Users { get; set; }
    }
}


//Password

//At least one digit [0-9]
//At least one lowercase character [a-z]
//At least one uppercase character [A-Z]
//At least one special character [*.!@#$%^&(){}[]:;<>,.?/~_+-=|\]
//At least 8 characters in length, but no more than 32.