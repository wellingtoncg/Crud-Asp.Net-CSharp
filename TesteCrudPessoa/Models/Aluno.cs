﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCrudPessoa.Models
{
    public class Aluno
    {
        
        public int Id  { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }
        public DateTime DataNasc  { get; set; }
        
    }
}
