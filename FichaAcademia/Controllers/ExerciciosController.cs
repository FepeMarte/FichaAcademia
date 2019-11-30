using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FichaAcademia.AcessoDados;
using FichaAcademia.Dominio.Models;
using FichaAcademia.AcessoDados.Interfaces;

namespace FichaAcademia.Controllers
{
    public class ExerciciosController : Controller
    {
        private readonly IExercicioRepositorio _exercicioRepositorio;
        private readonly ICategoriaExercicioRepositorio _categoriaExercicioRepositorio;
        public ExerciciosController(IExercicioRepositorio exercicioRepositorio, ICategoriaExercicioRepositorio categoriaExercicioRepositorio)
        {
            _exercicioRepositorio = exercicioRepositorio;
            _categoriaExercicioRepositorio = categoriaExercicioRepositorio;
        }

        // GET: Exercicios
        public async Task<IActionResult> Index()
        {
            return View(await _exercicioRepositorio.PegarTodos());
        }

  
        // GET: Exercicios/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoriaExercicioId"] = new SelectList( _categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome");
            return View();
        }

        // POST: Exercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExercicioId,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
               await _exercicioRepositorio.Inserir(exercicio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        // GET: Exercicios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var exercicio = await _exercicioRepositorio.PegarPeloId(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        // POST: Exercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExercicioId,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (id != exercicio.ExercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _exercicioRepositorio.Atualizar(exercicio);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }



        // POST: Exercicios/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _exercicioRepositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<JsonResult> ExercicioExiste(string nome, int exercicioId)
        {
            if(exercicioId == 0)
            {
                if (await _exercicioRepositorio.ExercicioExiste(nome))
                    return Json("Exercico já cadastrado!");

                return Json("true");
            }
            else
            {
                if (await _exercicioRepositorio.ExercicioExiste(nome,exercicioId))
                    return Json("Exercico já cadastrado!");

                return Json("true");
            }
        }
    }
}
