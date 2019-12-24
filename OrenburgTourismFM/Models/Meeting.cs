using Newtonsoft.Json;
using OrenburgTourismFM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrenburgTourismFM.Model
{
    public class Meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string PhotoSource { get; set; }

        [ForeignKey("Place")]
        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }

        public virtual IList<Account> Accounts { get; set; }

        public override string ToString()
        {
            return $"Название: {Name}\n" +
                $"Дата проведения: {Date}\n" +
                $"Описание мероприятия: {Description}\n" +
                $"Стоимость: {Cost}";
        }

    }
}
