using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcunMedyaRestaurantly.Entities
{
	public class Event
	{
        public int EventId { get; set; }
        public string Title { get; set; }
        public string ImageUrl {get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        
    }
}