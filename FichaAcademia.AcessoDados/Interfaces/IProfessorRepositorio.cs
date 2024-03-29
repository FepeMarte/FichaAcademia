﻿using FichaAcademia.AcessoDados.Repositorio;
using FichaAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Interfaces
{
    public interface IProfessorRepositorio: IRepositorioGenerico<Professor>
    {
        Task<bool> ProfessorExiste(string nome);
        Task<bool> ProfessorExiste(string nome, int professorId);
    }
}
