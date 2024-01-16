using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models
{
    public class City

    {


        [Display(Name= "City Name : ")] 
        public string Name { get; set; } //Nom de la ville ciblée //

        [Display(Name = "Longitude géographique : ")]
        public float Lon { get; set; } //Nom de la ville ciblée //

        [Display(Name = "Largitude géographique : ")]
        public float Lar { get; set; } //Nom de la ville ciblée //


        [Display(Name = "Temperature : ")]  
        public float Temperature { get; set; } //Température//

        [Display(Name = "Humidity : ")] 
        public int Humidity { get; set; } //Humidité//

        [Display(Name = "Pressure : ")] 
        public int Pressure { get; set; } //Pression//

        [Display(Name = "Wind speed: ")]
        public float Wind { get; set; } //Vitesse de vent//

        [Display(Name = "Weather condition : ")]
        public string Weather { get; set; } //Conditions météorologiques//

        [Display(Name = "Country : ")]
        public string Country { get; set; } //Conditions météorologiques//

        [Display(Name = "Temp Min : ")]
        public float TempMin { get; set; } //Conditions météorologiques//

        [Display(Name = "Temp Max : ")]
        public float TempMax { get; set; } //Conditions météorologiques//

 

    }
}
