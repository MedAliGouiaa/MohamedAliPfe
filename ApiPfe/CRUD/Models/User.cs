using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Nom { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Prenom { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string Motpasse { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public Role Role { get; set; }

        
    }
}

