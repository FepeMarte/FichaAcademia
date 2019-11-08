using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FichaAcademia.Dominio.Models
{
    public class CategoriaExercicio
    {
        public int CategoriaExercicioId { get; set; }
        [Required(ErrorMessage = "Campo obrigatário!")]
        [StringLength(50,ErrorMessage ="Use menos caracteres!")]
        public string Nome { get; set; }

        public ICollection<Exercicio> Exercicios { get; set; }

    }
}
