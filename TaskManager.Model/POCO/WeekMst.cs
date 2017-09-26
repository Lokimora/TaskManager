using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model.POCO
{
    [Table("Week_Mst", Schema = "Ru")]
    class WeekMst
    {
        [Key]
        public int Id { get; set; }
        public string BASE_YMD { get; set; }
        public string BASE_YW { get; set; }
    }
}
