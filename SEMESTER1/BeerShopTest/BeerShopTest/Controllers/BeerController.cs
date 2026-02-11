using AutoMapper;
using BeerShopTest.Domain.EntitiesDB;
using BeerShopTest.Services.Interfaces;
using BeerShopTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerShopTest.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IService<Brewery2> _breweryService;
        private readonly IMapper _mapper;

        public BeerController(IBeerService beerService, IService<Brewery2> breweryService, IMapper mapper)
        {
            _beerService = beerService;
            _breweryService = breweryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _beerService.GetAllAsync();
                List<BeerVM> vm = _mapper.Map<List<BeerVM>>(list);
                return View(vm);
            }
            catch (Exception ex)
            {
                // Log de foutmelding (ex) indien nodig
            }
            return View();
        }
    }
}
