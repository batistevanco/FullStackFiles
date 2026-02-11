using AutoMapper;
using ExamenTest.Domain.EntitiesDB;
using ExamenTest.Services.Interfaces;
using ExamenTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTest.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IService<Breweries2> _breweryService;
        private readonly IMapper _mapper;

        public BeerController(IBeerService beerService, IService<Breweries2> breweryService, IMapper mapper)
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
