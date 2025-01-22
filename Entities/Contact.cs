﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [StringLength(250)]
        public string Subject { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
        public string Message { get; set; }
    }
}