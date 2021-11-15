using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Dtos
{
    public class PizzaToAddCartDto
    {
        public int PizzaTypeId { get; set; }

        public int SizeId { get; set; }

        public int[] Toppings { get; set; }

        public int EdgeTypeId { get; set; }

        public int NumberOfPizza { get; set; }

        public int CustomerId { get; set; }

        public bool ExtraCheese { get; set; }

    }
}
