using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Компьютерный;
using Компьютерный_клуб_сайт.Shared;

namespace Компьютерный_клуб_сайт.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            using (СайтдлякомпьютерногоклубаContext db = new СайтдлякомпьютерногоклубаContext())
            {
                Покупатель user1 = new Покупатель { Id = 1, Имя = "Кирилл", Фамилия = "Кирилл", Возраст = 78, ДеньРожденияСегодня = "Да" };
                Покупатель user2 = new Покупатель { Id = 2, Имя = "Некирилл", Фамилия = "Некирилл", Возраст = 87, ДеньРожденияСегодня = "Нет" };

                // Добавление
                db.Покупательs.Add(user1);
                db.Покупательs.Add(user2);
                db.SaveChanges();
            }
            return null;
            using (СайтдлякомпьютерногоклубаContext db = new СайтдлякомпьютерногоклубаContext())
            {
                Услуга usluga1 = new Услуга { UslugaId = 1, Стоимость = 750, ArendaId = 1, Id = 1 };
                Услуга usluga2 = new Услуга { UslugaId = 2, Стоимость = 500, ArendaId = 2, Id = 2 };

                db.Услугаs.Add(usluga1);
                db.Услугаs.Add(usluga2);
                db.SaveChanges();
            }
        }
    }

}
