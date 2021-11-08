using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Viddly2.Models
{
    [Table("MembershipType")]
    public class MembershipType
    {
        public byte Id { get; set; }
        [Column(Order = 2)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}