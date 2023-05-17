using MVP.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVP.Date
{
    public class DBObjects
    {
        public static void Initial(AppDB content)
        {


            if (!content.DBStaff.Any())
                content.DBStaff.AddRange(Staff.Select(p => p.Value));

           

            content.SaveChanges();
        }

        public static Dictionary<string, Staff> _Staff;
        public static Dictionary<string, Staff> Staff
        {
            get
            {

                if (_Staff == null)
                {
                    var list = new Staff[]
                    {
                        new Staff {
                            code = "00",
                            name = "Прокопьев Сергей Михайлович",
                            divisionId = 1,
                            roleCod = "R01",
                            post = "Директор",
                            login = "ПрокопьевСМ",
                            passvord = "123456"
                        }
                    };
                    _Staff = new Dictionary<string, Staff>();
                    foreach (Staff el in list)
                    {
                        _Staff.Add(el.code, el);
                    }
                }
                return _Staff;
            }
        }


       
    }
}
