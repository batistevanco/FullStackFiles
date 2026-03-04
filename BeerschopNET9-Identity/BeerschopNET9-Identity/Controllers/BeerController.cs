
using AutoMapper;
using BeerschopNET9_Identity.Extensions;
using BeerschopNET9_Identity.ViewModels;
using BeerShop.Domain.Entities;
using BeerShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace BeerschopNET9_Identity.Controllers
{
    [Authorize(Roles = "User")]
    public class BeerController : Controller
    {
        private IService<Beer> beerService;
   

        private readonly IMapper _mapper;

        public BeerController(IMapper mapper, IService<Beer> beerservice)
        {
            _mapper = mapper;
    
            beerService = beerservice;
    

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()  
        {
            var list = await beerService.GetAllAsync();
            List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(list);
            return View(listVM);
        }

        public async Task<IActionResult> Select(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Beer? beer = await beerService.FindByIdAsync(id.Value);
            if (beer == null)
            {
                return NotFound();
            }

            ShoppingCartVM shoppingCartVM =HttpContext.Session.
                GetObject<ShoppingCartVM>("shoppingCart") ?? new ShoppingCartVM { Carts = new List<CartVM>() };

            var existingItem = shoppingCartVM?.Carts?.
                FirstOrDefault(x => x.BeerNumber == id);

            if (existingItem != null)
            {
                existingItem.Count += 1;
            }
            else
            {
                shoppingCartVM?.Carts?.Add(new CartVM
                {
                    BeerNumber = beer.Biernr,
                    Count = 1,
                    Price = 15.00,
                    DateCreated = DateTime.Now,
                    Name = beer.Naam
                });
            }
            HttpContext.Session.SetObject("shoppingCart", shoppingCartVM);
            return RedirectToAction("Index", "shoppingCart");
        }
    }
}
