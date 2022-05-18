using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fileManager.Models
{
    public class QRcode
    {

        [Key]
        public int IdQr { get; set; }

        public string name { get; set; }

        public string url { get; set; }

        [ForeignKey("Id")]
        public FileData id { get; set; }
    }
}
