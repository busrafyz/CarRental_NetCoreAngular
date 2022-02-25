using CarRental.DataAccess;
using CarRental.Entities;
using CarRental.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Business
{
    public class CarController : Controller
    {
        Context c = new Context();
        CarRepository carRepository = new CarRepository();

        public IActionResult Index(int page = 1)
        {


            return View(carRepository.TList("Brand").ToList();
        }

        [HttpGet]
        public IActionResult AddFood()
        {

            List<SelectListItem> values = (from x in c.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BrandName,
                                               Value = x.BrandId.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {

            carRepository.TAdd(car);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            carRepository.TDelete(new Car { Id = id });
            return RedirectToAction("Index");
        }

        public IActionResult Get(int id)
        {
            var x = carRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.BrandName,
                                               Value = y.BrandId.ToString()
                                           }).ToList();
            ViewBag.value = values;
            Car car = new Car()
            {
                Id = x.Id,
                BrandId = x.BrandId,
                ColorId = x.ColorId,
                DailyPrice = x.DailyPrice,
                ModelYear = x.ModelYear,
                Description = x.Description,
                
            };
            return View(car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            var x = carRepository.TGet(car.Id);
            x.BrandId = car.BrandId;
            x.ModelYear = car.ModelYear;
            x.DailyPrice = car.DailyPrice;
            x.Description = car.Description;
            
            carRepository.TUpdate(x);
            return RedirectToAction("Index");
        }


    }
}