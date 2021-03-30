using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using ClientValidator;

namespace g9events.Models
{   
    public class Client
    {
        [Key]
        [ForeignKey("Client_id")]
        public int id { get; set; }

        public string name { get; set; }

        public string cpf { get; set; }

        public categorias categories { get; set; }

        public string cellphone { get; set; }
    }

    public enum categorias
    {
        Nenhum = 0,
        Industria = 1,
        Startups = 2,
        Fintech = 3,
        Segurança = 4,
        Academico = 5,
        Biologia = 6,
        Matemática = 7,
        Física = 8,
        Química = 9,
        Computação = 10
    }
}