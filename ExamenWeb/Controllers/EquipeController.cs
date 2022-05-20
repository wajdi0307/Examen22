using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWeb.Controllers
{
    public class EquipeController : Controller
    {
        // GET: EquipeController
        IServiceEquipe se;
        IServiceTrophee st;
        public EquipeController( IServiceEquipe se1, IServiceTrophee st1)
        {
            se = se1;
            st = st1;
        }
        public ActionResult Index(String filter)
        {
            if (filter != null)
            {
                return View(se.GetMany(p => p.NomEquipe.Contains(filter) || p.AdresseLocal.Contains(filter)));

            }
            else
            {
                return View(se.GetMany());
            }
        }

        // GET: EquipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public ActionResult Create(Equipe e, IFormFile file)
        {
            e.Logo = file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            se.Add(e);
            se.Commit();
            return RedirectToAction("Index");
        }
        // GET: ProductController/Create
        public ActionResult CreateTrophee()
        {
            ViewBag.EquipeFK = new SelectList(se.GetMany(), "EquipeId", "NomEquipe");
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrophee(Trophee e)
        {
         
            
            st.Add(e);
            st.Commit();
            return RedirectToAction("Index");
        }
        // GET: EquipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
