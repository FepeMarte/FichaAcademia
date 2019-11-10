
using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.AcessoDados.Repositorio;
using FichaAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Repositorios
{
    public class CategoriaExercicioRepositorio : RepositorioGenerico<CategoriaExercicio>, ICategoriaExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public CategoriaExercicioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }
        public Task<bool> CategoriaExiste(string categoria, int CategoriaExercicioId)
        {
            throw new NotImplementedException();
        }
    }
}
