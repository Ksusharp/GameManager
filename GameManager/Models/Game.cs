using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameManager.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Developer { get; set; } = string.Empty;
        [MaxLength(100)]
        public string ReleaseDate { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Platform { get; set; } = string.Empty;
    }
}