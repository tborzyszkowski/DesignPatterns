using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using CarsCms.Validation;
using CarsCms.ViewModels;

namespace CarsCms.Controllers
{
    public class EngineController : Controller
    {
        private readonly IEngineRepository _engineRepository;

        public EngineController(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }
        // GET: Engine
        public ActionResult Index()
        {
            var viewModel = new VMEngine();
            viewModel.EngineList = _engineRepository.GetWhere(x => x.Id > 0);
            return View(viewModel);
        }

        // GET: Engine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new VMEngine();
            viewModel.Engine = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (viewModel.Engine == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Engine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMEngine model)
        {
            var validator = new EngineValidator();
            var result = validator.Validate(model.Engine);
            if (result.Errors.Any())
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.ErrorMessage);

            else
            {
                _engineRepository.Create(model.Engine);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Engine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new VMEngine();
            viewModel.Engine = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (viewModel.Engine == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Engine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMEngine model)
        {
            if (ModelState.IsValid)
            {
                _engineRepository.Update(model.Engine);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Engine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new VMEngine();
            viewModel.Engine = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (viewModel.Engine == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Engine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engine engine = _engineRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _engineRepository.Delete(engine);
            return RedirectToAction("Index");
        }


    }
}
