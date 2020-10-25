using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Data.Models;
using Library.Domain.Service.Interface;

namespace Library.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibrary _library;
        private readonly IEditorial _editorial;
        public LibraryController(ILibrary library, IEditorial editorial)
        {
            _library = library;
            _editorial = editorial;
        }

        // GET: Library
        public IActionResult Index()
        {
            return View(_library.SelectAllLibrary());
        }


        // GET: Library/Details/5
        public IActionResult Details(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            var library= _library.GetLibrary((int)id);
            if (library == null)
            {
                response = NotFound();
            }
            response = View(library);
            return response;
        }

        // GET: Library/Create
        public IActionResult Create()
        {
            //ViewData["EditorialId"] = new SelectList(_context.Editorials, "Id", "Nombre");
            ViewData["EditorialId"] = new SelectList(_editorial.SelectAllEditorial(), "Id", "Nombre");
            return View();
        }

        // POST: Library/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,EditorialId,Fecha,Costo,PreciosSugerido,Autor")] Data.Models.Library library)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = await _library.InsertLibrary(library);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo crear el Libro");
                    response = View(library);
                }
            }
            else
            {
                response = View(library);
            }

            return response;
        }


        // GET: Library/Edit/5
        public IActionResult Edit(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            var library= _library.GetLibrary((int)id);
            if (library == null)
            {
                response = NotFound();
            }

            ViewData["EditorialId"] = new SelectList(_editorial.SelectAllEditorial(), "Id", "Nombre", library.EditorialId);
            response = View(library);
            return response;
        }

        // POST: Library/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,EditorialId,Fecha,Costo,PreciosSugerido,Autor")] Data.Models.Library library)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result =await _library.UpdateLibrary(library);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo editar el Libro");
                    response = View(library);
                }
            }
            else
            {
                response = View(library);
            }

            ViewData["EditorialId"] = new SelectList(_editorial.SelectAllEditorial(), "Id", "Nombre", library.EditorialId);
            
            return response;
        }

        // GET: Library/Delete/5
        public IActionResult Delete(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            var library = _library.GetLibrary((int)id);
            if (library == null)    
            {
                response = NotFound();
            }

            ViewData["EditorialId"] = new SelectList(_editorial.SelectAllEditorial(), "Id", "Nombre", library.EditorialId);
            response = View(library);
            return response;
        }

        // POST: Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            IActionResult response;
            bool result = await _library.DeleteLibrary(id);
            if (result)
            {
                response = RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No se pudo eliminar el Libro");
                response = RedirectToAction(nameof(Index));
            }
            return response;
        }

    }
}
