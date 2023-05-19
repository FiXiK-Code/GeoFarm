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
                        new Title
                        {
                            title = "Зеленый листок."
                        },
                        new Title
                        {
                            title = "Желтое яблоко."
                        },
                        new Title
                        {
                            title = "Голубое море."
                        },
                        new Title
                        {
                            title = "Коричневый ежик."
                        },
                        new Title
                        {
                            title = "Фиолетовый цветок."
                        },
                        new Title
                        {
                            title = "Белый ледышка."
                        },
                        new Title
                        {
                            title = "Серый камень."
                        },
                        new Title
                        {
                            title = "Синий океан."
                        },
                        new Title
                        {
                            title = "Розовая роза."
                        },
                        new Title
                        {
                            title = "Красный перец."
                        },
                        new Title
                        {
                            title = "Молочный коктейль."
                        },
                        new Title
                        {
                            title = "Маленький мячик."
                        },
                        new Title
                        {
                            title = "Уютный домик."
                        },
                        new Title
                        {
                            title = "Прозрачный лед."
                        },
                        new Title
                        {
                            title = "Темный лес."
                        },
                        new Title
                        {
                            title = "Яркая солнцево луны."
                        },
                        new Title
                        {
                            title = "Быстрый трамвай."
                        },
                        new Title
                        {
                            title = "Густой дым."
                        },
                        new Title
                        {
                            title = "Теплый свитерок."
                        },
                        new Title
                        {
                            title = "Золотые украшения."
                        },
                        new Title
                        {
                            title = "Брызги воды."
                        },
                        new Title
                        {
                            title = "Резкий звук."
                        },
                        new Title
                        {
                            title = "Узкий проход."
                        },
                        new Title
                        {
                            title = "Тонкий листок."
                        },
                        new Title
                        {
                            title = "Гладкий камень."
                        },
                        new Title
                        {
                            title = "Приятный аромат."
                        },
                        new Title
                        {
                            title = "Круглый торт."
                        },
                        new Title
                        {
                            title = "Острые когти."
                        },
                        new Title
                        {
                            title = "Любимый мультфильм."
                        },
                        new Title
                        {
                            title = "Спокойный листопад."
                        },
                        new Title
                        {
                            title = "Аккуратный нож."
                        },
                        new Title
                        {
                            title = "Тяжелый груз."
                        },
                        new Title
                        {
                            title = "Сырой бетон."
                        },
                        new Title
                        {
                            title = "Короткая стрижка."
                        },
                        new Title
                        {
                            title = "Широкая дорога."
                        },
                        new Title
                        {
                            title = "Сладкий арбуз."
                        },
                        new Title
                        {
                            title = "Мягкий плюшевый мишка."
                        },
                        new Title
                        {
                            title = "Сосновый лес."
                        },
                        new Title
                        {
                            title = "Грязная лужа."
                        },
                        new Title
                        {
                            title = "Смешной клоун."
                        },
                        new Title
                        {
                            title = "Невысокий забор."
                        },
                        new Title
                        {
                            title = "Светлая улыбка."
                        },
                        new Title
                        {
                            title = "Задумчивый взгляд."
                        },
                        new Title
                        {
                            title = "Сильный ветер."
                        },
                        new Title
                        {
                            title = "Бумажный самолетик."
                        },
                        new Title
                        {
                            title = "Сложный проект."
                        },
                        new Title
                        {
                            title = "Умелый рукодельник."
                        },
                        new Title
                        {
                            title = "Счастливый момент."
                        },
                        new Title
                        {
                            title = "Громкий звук."
                        },
                        new Title
                        {
                            title = "Темный оттенок."
                        },
                        new Title
                        {
                            title = "Легкий бриз."
                        },
                        new Title
                        {
                            title = "Милая улитка."
                        },
                        new Title
                        {
                            title = "Модный наряд."
                        },
                        new Title
                        {
                            title = "Седая мышка."
                        },
                        new Title
                        {
                            title = "Прочный металл."
                        },
                        new Title
                        {
                            title = "Жареный насекомый."
                        },
                        new Title
                        {
                            title = "Сладкий мед."
                        },
                        new Title
                        {
                            title = "Базарный торговец."
                        },
                        new Title
                        {
                            title = "Коричный кофе."
                        },
                        new Title
                        {
                            title = "Жирный банан."
                        },
                        new Title
                        {
                            title = "Бесшумный полет."
                        },
                        new Title
                        {
                            title = "Густой суп."
                        },
                        new Title
                        {
                            title = "Яркий макияж."
                        },
                        new Title
                        {
                            title = "Вкусный пирожок."
                        },
                        new Title
                        {
                            title = "Мелкий камушек."
                        },
                        new Title
                        {
                            title = "Глубокая яма."
                        },
                        new Title
                        {
                            title = "Многослойный торт."
                        },
                        new Title
                        {
                            title = "Волшебный колодец."
                        },
                        new Title
                        {
                            title = "Хит рейтингов."
                        },
                        new Title
                        {
                            title = "Привлекательный актер."
                        },
                        new Title
                        {
                            title = "Тихий уголок."
                        },
                        new Title
                        {
                            title = "Сладкий мандарин."
                        },
                        new Title
                        {
                            title = "Медленный поток."
                        },
                        new Title
                        {
                            title = "Увлекательная игра."
                        },
                        new Title
                        {
                            title = "Новая машина."
                        },
                        new Title
                        {
                            title = "Приятный сюрприз."
                        },
                        new Title
                        {
                            title = "Огненный шар."
                        },
                        new Title
                        {
                            title = "Светлый берег."
                        },
                        new Title
                        {
                            title = "Новенькая джинсовка."
                        },
                        new Title
                        {
                            title = "Просторный дом."
                        },
                        new Title
                        {
                            title = "Стройные ноги."
                        },
                        new Title
                        {
                            title = "Модный стиль."
                        },
                        new Title
                        {
                            title = "Пышный букет."
                        },
                        new Title
                        {
                            title = "Летящая птица."
                        },
                        new Title
                        {
                            title = "Лучший друг."
                        },
                        new Title
                        {
                            title = "Бешеный танец."
                        },
                        new Title
                        {
                            title = "Опасный маршрут."
                        },
                        new Title
                        {
                            title = "Верный пес."
                        },
                        new Title
                        {
                            title = "Крепкий чай."
                        },
                        new Title
                        {
                            title = "Живописный закат."
                        },
                        new Title
                        {
                            title = "Строгий начальник."
                        },
                        new Title
                        {
                            title = "Любимый актер."
                        },
                        new Title
                        {
                            title = "Голодный зверь."
                        },
                        new Title
                        {
                            title = "Радужный цвет."
                        },
                        new Title
                        {
                            title = "Клетчатый шарф."
                        },
                        new Title
                        {
                            title = "Мимолетный взгляд."
                        },
                        new Title
                        {
                            title = "Чистый лист бумаги."
                        },
                        new Title
                        {
                            title = "Острый нож."
                        },
                        new Title
                        {
                            title = "Мелкий дождик."
                        },
                        new Title
                        {
                            title = "Тонкий дух."
                        }
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
