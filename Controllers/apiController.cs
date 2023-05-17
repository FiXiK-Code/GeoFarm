using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVP.Date;
using MVP.Date.Interfaces;
using MVP.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly AppDB _appDB;
        private readonly IStaff _staff;

        public ApiController(AppDB appDB, IStaff staff)
        {
            _appDB = appDB;
            _staff = staff;
          
        }

        [HttpGet]
        public JsonResult GetEmployees([FromQuery] string StaffParam)// список сотрудников
        {
            var staffs = _staff.StaffTable(roleSession.SessionRole, sessionCod).ToList();
            var StaffTable = new List<StaffOut>();

            foreach (var filter in StaffParam.filterPosts.Split(','))
            {
                if (filter != "" && filter != "Все должности")
                {
                    try
                    {
                        StaffTable.AddRange(staffs.Where(p => p.post == filter.Trim()).ToList());
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            foreach (var filter in StaffParam.filterStaffs.Split(','))
            {
                if (filter != "" && filter != "Все сотрудники")
                {
                    try
                    {
                        StaffTable.AddRange(staffs.Where(p => p.name == filter.Trim()).ToList());
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            if (StaffTable.Count() == 0) StaffTable = staffs;
            // составление списка сотрудников в подчинениии у того кто вошел в сессию
            List<string> staffNames = new List<string>();
            foreach (var task in StaffTable)
            {
                if (!staffNames.Contains(task.name)) staffNames.Add(task.name);
            }

            // список задач сотрудников из вышеупомянутого списка
            TasksTableReturnModels tasksTabbleFilter = _task.GetMoreTasks(staffNames, roleSession, "Мои задачи");


            var filterPosts = new List<string>();
            foreach (var staf in staffs)
            {
                if (!filterPosts.Contains(staf.post)) filterPosts.Add(staf.post);
            }
            var filterStaffs = new List<string>();
            foreach (var staf in staffs)
            {
                if (!filterStaffs.Contains(staf.name)) filterStaffs.Add(staf.name);
            }

            StaffTableReturnModelsNull output = new StaffTableReturnModelsNull
            {
                // список сотрудников
                staffs = staffs,
                // задачи на чегодня
                today = tasksTabbleFilter.today,
                // выполненные задачи
                completed = tasksTabbleFilter.completed,
                // будущие задачи 
                future = tasksTabbleFilter.future,

                filters = new
                {
                    filterTasks = new List<string>() { "Мои задачи", "Все задачи" },
                    filterPosts = filterPosts,
                    filterStaffs = filterStaffs
                }
            };

            // возвращает список сотрудников в подчинении у залогиненного пользователя
            return new JsonResult(new ObjectResult(output) { StatusCode = 200 });

        }
    }
}
