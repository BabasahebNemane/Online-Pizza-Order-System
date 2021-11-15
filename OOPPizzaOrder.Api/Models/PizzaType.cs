using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class PizzaType : CommonData
    {

        public string Description { get; set; }

        public bool IsPizza { get; set; }
    }
}
