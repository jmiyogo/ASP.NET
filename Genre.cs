using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Viddly2.Models
{
    [Table("Genre")]
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}