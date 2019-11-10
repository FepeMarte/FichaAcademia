
using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.AcessoDados.Repositorio;
using FichaAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Repositorios
{
    public class CategoriaExercicioRepositorio : RepositorioGenerico<CategoriaExercicio>, ICategoriaExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public CategoriaExercicioRepositorio(Contexto contexto): base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> CategoriaExiste(string categoria)
        {
            return await _contexto.CategoriasExercicios.AnyAsync(c => c.Nome == categoria);
        }
        public async Task<bool> CategoriaExiste(string categoria, int CategoriaExercicioId)
        {
            return await _contexto.CategoriasExercicios.AnyAsync(c => c.Nome == categoria && c.CategoriaExercicioId != CategoriaExercicioId);
        }
    }
}
