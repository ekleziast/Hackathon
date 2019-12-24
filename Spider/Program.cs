using OrenburgTourismFM;
using OrenburgTourismFM.Model;
using OrenburgTourismFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var meetings = Meetings.GetMeetings();
                using (Context db = new Context())
                {
                    int count = 0;
                    foreach(Meeting meeting in meetings)
                    {
                        if(db.Meetings.Where(m => 
                        m.Name == meeting.Name && 
                        m.Date == meeting.Date && 
                        m.Cost == meeting.Cost
                        ).Any())
                        {
                            continue;
                        }
                        else
                        {
                            Place place = db.Places.Where(pl => pl.Name == meeting.Place.Name && pl.Street == meeting.Place.Street).FirstOrDefault();
                            if(place != null)
                            {
                                meeting.PlaceID = place.ID;
                                meeting.Place = null;
                            }
                            db.Meetings.Add(meeting);
                            db.SaveChanges();
                            Console.WriteLine($"Добавлено: {meeting.Name}");
                            count++;
                        }
                    }
                    Console.WriteLine($"Новых записей: {count}");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Работа программы завершена.\nНажмите любую клавишу... ");
            Console.ReadKey();
        }
    }
}
