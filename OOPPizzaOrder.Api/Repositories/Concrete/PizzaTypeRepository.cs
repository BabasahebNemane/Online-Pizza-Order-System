using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Concrete
{
    public class PizzaTypeRepository : IPizzaTypeRepository
    {
        public List<PizzaType> GetAllPizzas()
        {
            List<PizzaType> pizzas = new List<PizzaType>
            {
               new PizzaType(){Id=1, Name="Margherita", Price=199, Category="Pizza", IsPizza=true,  Description=  "Classic delight with 100% real mozzarella cheese"},
               new PizzaType(){Id=2, Name="Fresh Veggie", Price=399, Category="Pizza", IsPizza=true, Description=  "Delightful combination of onion, capsicum"},
               new PizzaType(){Id=3, Name="Peppy Paneer", Price=399, Category="Pizza", IsPizza=true, Description=  "Flavorful trio of juicy paneer, crisp capsicum with spicy red paprika"},
               new PizzaType(){Id=4, Name="Veg Extravaganza", Price=409, Category="Pizza", IsPizza=true, Description=  "Black olives, capsicum, onion, grilled mushroom, corn, tomato, jalapeno & extra cheese"},
               new PizzaType(){Id=5, Name="Veggie Paradise", Price=419, Category="Pizza", IsPizza=true, Description=  "The awesome foursome! Golden corn, black olives, capsicum, red paprika"},
               new PizzaType(){Id=6, Name="Cheese n Corn", Price=320, Category="Pizza", IsPizza=true, Description=  "A delectable combination of sweet & juicy golden corn"},
               new PizzaType(){Id=7, Name="Mexican Green Wave", Price=399, Category="Pizza", IsPizza=true, Description=  "Mexican herbs sprinkled on onion, capsicum, tomato & jalapeno"},

               new PizzaType(){Id=10, Name="Choco Lava", Price=99, Category="Other", IsPizza=false, Description=  "Chocolate lovers delight! Indulgent, gooey molten lava inside chocolate cake"},
               new PizzaType(){Id=11, Name="Cheesy Dip", Price=25, Category="Other", IsPizza=false, Description=  "An all-time favorite with your Garlic Breadsticks & Stuffed Garlic Bread for a Cheesy indulgence"},
               new PizzaType(){Id=12, Name="Garlic Breadsticks", Price=99, Category="Other", IsPizza=false, Description=  "Baked to perfection. Your perfect pizza partner! Tastes best with dip"},
               new PizzaType(){Id=13, Name="Tomato Ketchup", Price=1, Category="Other", IsPizza=false, Description=  "Goodness of Tomato Ketchup in mini sachets"},
               new PizzaType(){Id=14, Name="Pepsi (500ml)", Price=60, Category="Other", IsPizza=false, Description=  "Sparkling and Refreshing Beverage"},
               new PizzaType(){Id=15, Name="Mirinda (500ml)", Price=60, Category="Other", IsPizza=false, Description=  "Delicious Orange Flavoured beverage"},
               //new PizzaType(){Id=8, Name="Chicken Golden Delight", Price=359, Category="Non-Veg", Description=  "Double pepper barbecue chicken, golden corn and extra cheese, true delight"},
               //new PizzaType(){Id=9, Name="Chicken Pepperoni", Price=429, Category="Non-Veg", Description=  "A classic American taste! Relish the delectable flavor of Chicken Pepperoni, topped with extra cheese"},
               //new PizzaType(){Id=10, Name="Chicken Fiesta", Price=449, Category="Non-Veg", Description=  "Grilled chicken rashers, peri-peri chicken, onion & capsicum, a complete fiesta"},
               //new PizzaType(){Id=11, Name="Chicken Dominator", Price=299, Category="Non-Veg", Description=  "Loaded with double pepper barbecue chicken, peri-peri chicken, chicken tikka & grilled chicken rashers"},
               //new PizzaType(){Id=12, Name="Indi Chicken Tikka", Price=579, Category="Non-Veg",  Description=  "The wholesome flavour of tandoori masala with Chicken tikka, onion, red paprika & mint mayo"},
               //new PizzaType(){Id=13, Name="Pepper Barbecue Chicken & Onion", Price=399, Category="Non-Veg", Description=  "A classic favourite with pepper barbecue chicken & onion"}
            };


            return pizzas;
        }

        public List<CommonData> GetOtherItems()
        {
            List<CommonData> otherItems = new List<CommonData>
            {
               new CommonData(){Id=1, Name="Choco Lava Cake", Price=20, Category="Cake"},
               new CommonData(){Id=2, Name="Garlic BreadStiks", Price=20, Category="Bread"},
               new CommonData(){Id=3, Name="Tomato Ketchup", Price=20, Category=""},
               new CommonData(){Id=4, Name="Cheesy Deep", Price=20, Category=""},
               new CommonData(){Id=5, Name="Brownie Fantacy", Price=20, Category=""},
               new CommonData(){Id=6, Name="Pepsi(500)", Price=20, Category="Colddrinx"},
            };


            return otherItems;
        }

        public string GetPizzaTypeName(int pizzaTypeId)
        {
            string name = GetAllPizzas()
                 .Where(pt => pt.Id == pizzaTypeId)
                 .Select(pt => pt.Name)
                 .SingleOrDefault();

            return name;
        }

        public decimal GetPizzaTypePrice(int pizzaTypeId)
        {
            decimal price = GetAllPizzas()
                 .Where(pt => pt.Id == pizzaTypeId)
                 .Select(pt => pt.Price)
                 .SingleOrDefault();

            return price;
        }
    }
}
