using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using OOPPizzaOrder.Api.Extensions;
using OOPPizzaOrder.Api.Models;

namespace OOPPizzaOrder.Api.Helpers
{
    public class CartFileService : ICartFileService
    {
        private IHostingEnvironment _hostEnvironment;

        public CartFileService(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public Cart GetCartFromFile()
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath + "\\Carts\\", "cart.json");
            Cart cart = new Cart();
            var json = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(json))
            {
                var jsonObj = JObject.Parse(json);
                cart = Newtonsoft.Json.JsonConvert.DeserializeObject<Cart>(json);

            }
            return cart;
        }

        public void AddCartToFile(Cart cart)
        {

            try
            {
                string path = Path.Combine(_hostEnvironment.WebRootPath + "\\Carts\\", "cart.json");
                if (File.Exists(path))
                {
                    //string path = Path.Combine(Environment.CurrentDirectory, @"Carts\cart.json");
                    //var json = File.ReadAllText(path);
                    //// var jsonObj = JObject.Parse(json);
                    //// var experienceArrary = jsonObj.GetValue("experiences") as JArray;
                    ////var newCompany = JObject.Parse(newCompanyMember);
                    ////experienceArrary.Add(newCompany);

                    //// jsonObj["experiences"] = experienceArrary;
                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(cart,
                                           Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }

        }
    }
}
