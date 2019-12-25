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
            var meetings = Meetings.GetMeetings(16);
            using (Context db = new Context())
            {
                db.Meetings.ToList().ForEach(o => o.PhotoSource = o.PhotoSource.Replace("_w100_h140", ""));
                db.SaveChanges();
                //db.PlaceTypes.ToList().ForEach(o => db.PlaceTypes.Remove(o));
                //db.Places.ToList().ForEach(o => db.Places.Remove(o));
                //db.Meetings.ToList().ForEach(o => db.Meetings.Remove(o));
                //db.SaveChanges();
                int count = 0;
                foreach(Meeting meeting in meetings)
                {
                    try
                    {
                        if (db.Meetings.Where(m =>
                         m.Name == meeting.Name &&
                         m.Date == meeting.Date &&
                         m.Cost == meeting.Cost
                        ).Any())
                        {
                            continue;
                        }
                        else
                        {
                            PlaceType placeType = db.PlaceTypes.Where(type => type.Name == meeting.Place.PlaceType.Name).FirstOrDefault();
                            if (placeType != null)
                            {
                                meeting.Place.PlaceType = null;
                                meeting.Place.PlaceTypeID = placeType.ID;
                            }
                            Place place = db.Places.Where(pl => pl.Name == meeting.Place.Name && pl.Street == meeting.Place.Street).FirstOrDefault();
                            if (place != null)
                            {
                                meeting.PlaceID = place.ID;
                                meeting.Place = null;
                            }
                            db.Meetings.Add(meeting);
                            db.SaveChanges();
                            Console.WriteLine($"Добавлено: {meeting.Name}");
                            count++;
                        }
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine($"Новых записей: {count}");
            }
            Console.Write("Работа программы завершена.\nНажмите любую клавишу... ");
            Console.ReadKey();
        }
    }
}
