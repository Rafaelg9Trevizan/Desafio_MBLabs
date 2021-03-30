using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using ClientValidator;

namespace g9events.Models
{
    public class Event
    {
        [Key]
        public int id_event { get; set; }

        public string event_name { get; set; }

        public string local { get; set; }

        public string description { get; set; }

        public categories categories { get; set; }

        [ForeignKey("Institution")]
        public int institution_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime event_date { get; set; }
    }

    public enum categories
    {
        Industria = 1,
        Startups = 2,
        Fintech = 3,
        Seguran�a = 4,
        Academico = 5,
        Biologia = 6,
        Matem�tica = 7,
        F�sica = 8,
        Qu�mica = 9,
        Computa��o = 10
    }
}