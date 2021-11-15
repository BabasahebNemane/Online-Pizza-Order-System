using OOPPizzaOrder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Abstract
{
   public interface IPizzaToppingRepository
    {
        List<CommonData> GetAllToppings();
    }
}
