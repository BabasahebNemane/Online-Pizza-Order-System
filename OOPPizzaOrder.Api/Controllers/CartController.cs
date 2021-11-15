using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOPPizzaOrder.Api.Dtos;
using OOPPizzaOrder.Api.Helpers;
using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Repository.Abstract;
using OOPPizzaOrder.Api.Services.Abstract;

namespace OOPPizzaOrder.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private  ICartFileService _cartFileService;
        private  ICartService _cartService;
        private  IPizzaPriceCalculater _pizzaPriceCalculater;
        private  IPizzaTypeRepository _pizzaTypeRepository;
        private ISizeRepository _sizeRepository;
        private IPizzaToppingRepository _toppingRepository;

        public CartController(ICartFileService cartSessionService,
            ICartService cartService,
            IPizzaPriceCalculater pizzaPriceCalculater,
            IPizzaTypeRepository pizzaTypeRepository,
            ISizeRepository sizeRepository,
            IPizzaToppingRepository toppingRepository
            )
        {
            _cartFileService = cartSessionService;
            _cartService = cartService;
           _pizzaPriceCalculater = pizzaPriceCalculater;
           _pizzaTypeRepository = pizzaTypeRepository;
            _sizeRepository = sizeRepository;
            _toppingRepository = toppingRepository;
        }

        [HttpPost("addPizzaToCart")]
        public ActionResult AddToCart([FromBody]PizzaToAddCartDto  pizzaDto)
        {
            var cart = _cartFileService.GetCartFromFile();

            decimal pizzaTypePrice = _pizzaTypeRepository.GetPizzaTypePrice(pizzaDto.PizzaTypeId);
            decimal sizeMultiplier = _sizeRepository.GetSizeMultiplier(pizzaDto.SizeId);
            decimal price = _pizzaPriceCalculater.Calculate(sizeMultiplier,pizzaTypePrice,pizzaDto.EdgeTypeId,pizzaDto.NumberOfPizza);
            string pizzaName = _pizzaTypeRepository.GetPizzaTypeName(pizzaDto.PizzaTypeId);
            var toppings= _toppingRepository.GetAllToppings();
            if (toppings.Count>0)
            {
                foreach (var toppingId in pizzaDto.Toppings)
                {
                    var toppingPrice = toppings.Where(r => r.Id == toppingId).FirstOrDefault();
                    if(toppingPrice !=null)
                    price += toppingPrice.Price;
                }
               
            }
            if (pizzaDto.ExtraCheese)
                price += 50;

            PizzaToAddCart pizzaToAddCart = new PizzaToAddCart
            {
                Id = pizzaDto.PizzaTypeId,
                PizzaName = pizzaName,
                NumberOfPizza = pizzaDto.NumberOfPizza,
                Price = price,
                Toppings = pizzaDto.Toppings.ToList()
            };
            
            _cartService.AddTocart(cart,pizzaToAddCart, pizzaDto.CustomerId);

            _cartFileService.AddCartToFile(cart);

            var cartFromSession = _cartFileService.GetCartFromFile();
            int totalPizzas = cartFromSession.TotalQuantity;

            return Ok(totalPizzas);
        }

        [HttpGet("pizzas")]
        public ActionResult GetPizzasFromCart()
        {
            var cart= _cartFileService.GetCartFromFile();

            return Ok(cart);
        }

        [HttpGet("pizzas/totalQuantity")]
        public ActionResult GetTotalQuantity()
        {
            var cart = _cartFileService.GetCartFromFile();

            int totalQuantity = cart.TotalQuantity;

            return Ok(totalQuantity);
        }

        [HttpDelete("pizzas/{pizzaId}")]
        public ActionResult DeletePizzaFromCart(int pizzaId)
        {
            var cart = _cartFileService.GetCartFromFile();
            _cartService.RemoveFromCart(cart, pizzaId);

            _cartFileService.AddCartToFile(cart);
            var cartToReturn = _cartFileService.GetCartFromFile();

            return Ok(cartToReturn);
        }
    }
}