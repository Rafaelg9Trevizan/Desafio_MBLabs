using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using CreditCardValidator;

namespace g9events.Models
{
    public class CreditCard
    {
        [Key]
        [ForeignKey("event_id")]
        public int card_id { get; set; }

        [ForeignKey("Client")]
        public int client_id { get; set; }

        public string owner_cpf { get; set; }

        public string owner_name { get; set; }

        public string card_number { get; set; }

        public string cvv { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/YYYY}")]
        public DateTime card_validity { get; set; }
    }
}