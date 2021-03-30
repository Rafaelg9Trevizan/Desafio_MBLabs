using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using TicketValidator;

namespace g9events.Models
{
    public class Ticket
    {
        [Key]
        public int id_ticket { get; set; }

        public float price { get; set; }

        public string type { get; set; }

        [ForeignKey("Event")]
        public int event_id { get; set; }
    }
}