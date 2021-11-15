using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Concrete
{
    public class ToppingRepository : IPizzaToppingRepository
    {
        public List<CommonData> GetAllToppings()
        {
            List<CommonData> cData = new List<CommonData>
            {
               new CommonData(){Id=1, Name="Grilled Mushrooms", Price=40, Category="Veg"},
               new CommonData(){Id=2, Name="Onion", Price=40, Category="Veg"},
               new CommonData(){Id=3, Name="Crisp Capsicum", Price=40, Category="Veg"},
               new CommonData(){Id=4, Name="Fresh Tomato", Price=40 , Category="Veg"},
               new CommonData(){Id=5, Name="Paneer", Price=50 , Category="Veg"},
               new CommonData(){Id=6, Name="Jalapeno", Price=40 , Category="Veg"},
               new CommonData(){Id=7, Name="Golden Corn", Price=40 , Category="Veg"},
               new CommonData(){Id=8, Name="Black Olive", Price=40 , Category="Veg"}
              
            };

            return cData;
        }
     
    }
}

