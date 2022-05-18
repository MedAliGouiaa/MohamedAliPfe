using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Demande
    {
        
        [Key]
        [Required]
        public int IdDemande { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public TypeDemande Type { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
  
        public string Description { get; set; }

        [Column("Date")]
        [Required]
       
        public DateTime Date { get; set; }

        [Column("Status")]
        [Required]
        public string etat { get; set; }

        [ForeignKey("Id")]
        public virtual User id { get; set; }
    }
}

