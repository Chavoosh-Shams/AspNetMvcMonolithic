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
    }
}
