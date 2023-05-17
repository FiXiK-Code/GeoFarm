using MVP.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVP.Date
{
    public class DBObjects
    {
        public static void Initial(AppDB content)
        {


            if (!content.DBTitle.Any())
                content.DBTitle.AddRange(Title.Select(p => p.Value));

           

            content.SaveChanges();
        }

        public static Dictionary<string, Title> _Title;
        public static Dictionary<string, Title> Title
        {
            get
            {

                if (_Title == null)
                {
                    var list = new Title[]
                    {
                        new Title {
                           title = "Первый заголовок"
                        },
                        new Title {
                           title = "Первый заголовок"
                        },
                        new Title {
                           title = "Первый заголовок"
                        },
                        new Title {
                           title = "Первый заголовок"
                        },
                        new Title {
                           title = "Первый заголовок"
                        },
                        new Title {
                           title = "Первый заголовок"
                        },
                    };
                    _Title = new Dictionary<string, Title>();
                    foreach (Title el in list)
                    {
                        _Title.Add(el.title, el);
                    }
                }
                return _Title;
            }
        }


       
    }
}
