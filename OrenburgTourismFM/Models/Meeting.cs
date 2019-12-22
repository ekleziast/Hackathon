using OrenburgTourismFM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrenburgTourismFM.Model
{
    public class Meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        
        public DateTime MeetingDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual Place Place { get; set; }
        public virtual IList<Account> Accounts { get; set; }

    }
}
