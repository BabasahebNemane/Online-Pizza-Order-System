using OOPPizzaOrder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Helpers
{
    public interface ICartFileService
    {
        Cart GetCartFromFile();

        void AddCartToFile(Cart cart);
    }
}
