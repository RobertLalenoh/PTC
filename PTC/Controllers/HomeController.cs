using PTCData;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PTC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            TrainingProductViewModel vm = new TrainingProductViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
               ModelState.Clear();
            }
            else
            {
                foreach(KeyValuePair<string,string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }


      
    }
}