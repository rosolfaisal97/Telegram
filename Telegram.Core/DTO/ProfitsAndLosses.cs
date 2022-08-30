using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class ProfitsAndLosses
    {
        //"Profit",sum(sr.Price)*0.1 as "Losse"
        //sum(sr.Price) as "Profit",sum(sr.Price)*0.1 as "Losse"
        public int Profit { set; get;}
        public double Losse { set; get; }
    }
}
