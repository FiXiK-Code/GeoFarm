using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MVP.Date;
using MVP.Date.Api;
using MVP.Date.Interfaces;
using MVP.Date.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ITitle _title;

        public ApiController(AppDB appDB, ITitle title)
        {
            _title = title;
        }

        // запрос на получение необходимого количества заголовков
        [HttpPost]
        public JsonResult GetEmployees([FromBody] QueryParam PostParam)
        {
            // получаем данные с базы
            List<Title> arrayTitles = _title.GetTitles.Where(p => p.id >= PostParam.startId && p.id <= PostParam.endId).ToList();

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
