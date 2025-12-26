using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        #region [-Private Fields-]
        private readonly IPersonApplicationService _personApplicationService;
        #endregion

        #region [-Ctor-]
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        #endregion

        #region [-Index-]
        public async Task<IActionResult> Index()
        {
            return View(await _personApplicationService.GetAllPersonAsync());
        }
        #endregion

        #region [-Details-]
        public async Task<IActionResult> Details(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            var Person = await _personApplicationService.GetPersonById(Id);
            if (Person == null)
            {
                return NotFound();
            }
            return View(Person);
        } 
        #endregion

    }
}
