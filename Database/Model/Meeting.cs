using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("Account")]
        public Guid AccountID { get; set; }
        public Account Account { get; set; }

        public string Name { get; set; }
        public string Street { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}
