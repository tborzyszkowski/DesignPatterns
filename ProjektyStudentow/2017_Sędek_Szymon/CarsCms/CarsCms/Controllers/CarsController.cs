using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarsCms.ApiConsumer.Interfaces;
using CarsCms.Enums;
using CarsCms.Interfaces;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using CarsCms.Service;
using CarsCms.ViewModels;

namespace CarsCms.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsRepository _carsRepository;
        private readonly ICarBusinessLogic _businessLogic;
        private readonly IEmailAdapter _emailAdapter;
        private readonly ICarVMBuilder _carVmBuilder;


        public CarsController(
            ICarsRepository carsRepository,
            ICarBusinessLogic businessLogic,
            IEmailAdapter emailAdapter,
            ICarVMBuilder carVmBuilder

            )
        {
            _carsRepository = carsRepository;
            _businessLogic = businessLogic;
            _emailAdapter = emailAdapter;
            _carVmBuilder = carVmBuilder;

        }
        // GET: Cars
        public ActionResult Index()
        {
            var carVM = _carVmBuilder
                    .Initialize()
                    .SetAllCars()
                    .SetEnableAllCars()
                    .GetProduct();

            return View(carVM);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = _carVmBuilder
                .Initialize()
                .SetSingleCar(id)
                .SetEnableAllCars()
                .GetProduct();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VMCars carEntity)
        {
            if (ModelState.IsValid)
            {
                carEntity.Car.ModPerson = _businessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Create(carEntity.Car);
                var model = new Email().CreateEmailModel(carEntity.Car.ModPerson.Contains("Niezalogowany")
                    ? EmailType.OtherUser
                    : EmailType.UserAuth);
                
                await _emailAdapter.SendEmail(model);
                return RedirectToAction("Index");
            }

            return View(carEntity);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = _carVmBuilder
                .Initialize()
                .SetSingleCar(id)
                .SetEnableAllCars()
                .GetProduct();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMCars carEntity)
        {
            if (ModelState.IsValid)
            {
                carEntity.Car.ModPerson = _businessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Update(carEntity.Car);
                return RedirectToAction("Index");
            }
            return View(carEntity);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = _carVmBuilder
                .Initialize()
                .SetSingleCar(id)
                .SetEnableAllCars()
                .GetProduct();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarEntity carEntity = _carsRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _carsRepository.Delete(carEntity);
            return RedirectToAction("Index");
        }


        public ActionResult Clone(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carMain = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            CarEntity clone = Copy.Clone(carMain);
            clone.Id = 0;
            _carsRepository.Create(clone);

            return RedirectToAction("Index");
        }
    }
}
