using ExamenTest.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTest.Controllers
{
    public class GenericController : Controller
    {
        public void Index()
        {
            DataStore<string> cities = new DataStore<string>();
            cities.AddOrUpdate(0, "Mumbai");
            cities.AddOrUpdate(1, "Chicago");
            cities.AddOrUpdate(2, "New York");


            DataStore<int> empIds = new DataStore<int>();
            empIds.AddOrUpdate(0, 50);
            empIds.AddOrUpdate(1, 65);
            empIds.AddOrUpdate(2, 89);

        }
    }
}
