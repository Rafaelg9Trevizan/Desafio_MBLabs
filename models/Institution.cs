using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using InstitutionValidator;

namespace g9events.Models
{
    public class Institution
    {
        [Key]
        [ForeignKey("institution_id")]
        public int id {get; set; }

        public string name {get; set; }

        public string cnpj {get; set; }

        public types tipo {get; set; }
    }

    public enum types
    {
        Empresa = 1,
        Universidade = 2
    }
}