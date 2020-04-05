using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]

        public string GameName { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        [DisplayName("Game Name")]
        public string GameCode { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Genre { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Genre")]
        public string Publisher { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Publisher")]
    }
}
