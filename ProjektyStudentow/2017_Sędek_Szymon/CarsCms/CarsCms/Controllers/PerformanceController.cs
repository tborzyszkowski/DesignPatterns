using System.Threading.Tasks;
using System.Web.Mvc;
using CarsCms.ApiConsumer.Interfaces;

namespace CarsCms.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly IPerformanceClient _performanceClient;

        public PerformanceController(IPerformanceClient performanceClient)
        {
            _performanceClient = performanceClient;
        }
        // GET: Performance
        public async Task<ActionResult> Index()
        {
         
            var models = await _performanceClient.GetAll();
            return View(models);
        }

        // GET: Performance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Performance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Performance/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
              

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Performance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            { 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Performance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
