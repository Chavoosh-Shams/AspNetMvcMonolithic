using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        #region [- Create() -]

        #region [- Get -]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        #endregion

        #region [-Post-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.PostAsync(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            return View(postPersonDto);
        }
        #endregion

        #endregion

        #region [- Edit() -]
        public async Task<IActionResult> Edit(Guid Id)
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
            var putPersonDto = new PutPersonDto
            {
                FirstName = Person.FirstName,
                LastName = Person.LastName,
            };
            return View(putPersonDto);
        }
        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            return View(await _personApplicationService.GetAsync());
        }
        #endregion

        #region [- Details() -]
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
