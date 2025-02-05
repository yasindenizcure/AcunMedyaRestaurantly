using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
    public class BookATable
    {
        public int BookATableId { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        public bool IsRead { get; set; }
        public int People { get; set; }
        public DateTime SendDate { get; set; }
        public string Message { get; set; }
    }
}