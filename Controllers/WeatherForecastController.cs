using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Models;
using WeatherForecastApp.OpenWeatherMapModel;
using WeatherForecastApp.Repositories;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WForecastRepository;

        public WeatherForecastController(IWForecastRepository WForecastRepository)
        {
            _WForecastRepository = WForecastRepository;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model) {
        
            if(ModelState.IsValid) {

                return RedirectToAction("City", "WeatherForecast", new { city = model.CityName });

            }
            return View(model);
        
        }

        [HttpGet]
     
        public IActionResult City(string city)
        {
            WeatherResponse weatherReponse = _WForecastRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherReponse != null)
            {
                viewModel.Name = weatherReponse.Name;
                viewModel.Lon = weatherReponse.Coord.Lon;
                viewModel.Lar = weatherReponse.Coord.Lat;
                viewModel.Temperature = weatherReponse.Main.Temp;
                viewModel.Humidity = weatherReponse.Main.Humidity;
                viewModel.Pressure = weatherReponse.Main.Pressure;
                viewModel.Wind = weatherReponse.Wind.Speed;

                // Vérifier si la liste Weathers n'est pas null et contient au moins un élément
                if (weatherReponse.Weathers != null && weatherReponse.Weathers.Any())
                {
                    // Accéder au premier élément de la liste
                    viewModel.Weather = weatherReponse.Weathers[0].Main;
                }
                else
                {
                    // Gérer le cas où la liste Weathers est vide
                    viewModel.Weather = "N/A";
                }
            }
            viewModel.Country = weatherReponse.Sys.Country;
            viewModel.TempMin = weatherReponse.Main.Temp_Min;
            viewModel.TempMax = weatherReponse.Main.Temp_Max;
           

            return View(viewModel);
        }


    }
}