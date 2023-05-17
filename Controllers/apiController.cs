using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MVP.Date;
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
        private readonly AppDB _appDB;
        private readonly ITitle _title;

        public ApiController(AppDB appDB, ITitle title)
        {
            _appDB = appDB;
            _title = title;
          
        }

        // запрос на получение необходимого количества заголовков
        [HttpPost]
        public JsonResult GetEmployees([FromBody] string PostParam)
        {
            //// инициализируем массив выходных значений
            //List<string> titles = new List<string>();

            //// заполнение выходного массива необходимым количеством заголовков
            //foreach (var title in _title.GetTitles)
            //{
            //    titles.Add(title.title);
            //    if (titles.Count() == countTitles) break;
            //}

            // подготавливаем выходные данные для формата JSON
            var output = new 
            {
                // передаем значение
                titles = new List<string> { PostParam, "2"}
            };

            // возвращаем ответ
            return new JsonResult(new ObjectResult(output) { StatusCode = 200 });

        }
    }
}
