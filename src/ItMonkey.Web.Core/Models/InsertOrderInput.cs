using System;
using System.Collections.Generic;
using System.Text;

namespace ItMonkey.Models
{
   public class InsertOrderInput
    {
        public string OpenId { get; set; }
        public int Price { get; set; }
        public string Product { get; set; }
    }
}
