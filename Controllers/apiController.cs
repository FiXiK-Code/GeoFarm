using Microsoft.AspNetCore.Mvc;
using MVP.Date.Api;
using MVP.Date.Interfaces;
using MVP.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVP.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ITitle _title;

        public ApiController(ITitle title)
        {
            _title = title;
        }


        // запрос на получение необходимого количества заголовков
        [HttpPost]
        public JsonResult GetTitles([FromBody] QueryParam PostParam)
        {
            // получаем данные с базы
            List<Title> arrayTitles = new List<Title>();

            // проверка на запрос получения количества записей начиная с определенного id
            if (PostParam.countTitles != -1)
            {
                arrayTitles = _title.GetTitles.Where(p => p.id >= PostParam.startId && p.id < PostParam.startId + PostParam.countTitles).ToList();
            }
            else
            {
                arrayTitles = _title.GetTitles.Where(p => p.id >= PostParam.startId && p.id <= PostParam.endId).ToList();
            }

            // формируем массив ответа
            List<string> outArray = new List<string>();
            foreach (var elem in arrayTitles)
            {
                outArray.Add(elem.title);
            }

            // формируем выходные данные для формата JSON
            var output = new 
            {
                // передаем значение
                titles = outArray
            };

            // возвращаем ответ
            return new JsonResult(new ObjectResult(output) { StatusCode = 200 });

        }
    }
}
