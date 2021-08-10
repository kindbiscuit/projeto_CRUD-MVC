using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Consultas
    {
        [Display(Name="#")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Data e hora são obrigatórios.")]
        [Display(Name ="Data e Hora")]
        public DateTime? DataHora { get; set; }

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage ="Consulta deve possuir paciente")]
        [Display(Name ="Paciente")]
        public int? pacienteId { get; set; }
        public Paciente paciente { get; set; }
    }
}
