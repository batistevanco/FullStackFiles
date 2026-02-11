
using AutoMapper;
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
    }
}
