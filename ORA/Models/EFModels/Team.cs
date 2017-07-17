using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Team {
        [Key]
        public int TeamID { get; set; }
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        [ForeignKey("CientID")]
        public Client Client { get; set; }
    }
}
