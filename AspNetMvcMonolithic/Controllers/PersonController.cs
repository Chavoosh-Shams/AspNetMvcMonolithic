using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;
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
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region [- Post -]
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

        #region [ - Get -]
        public async Task<IActionResult> Edit(GetPersonForEdit getPersonForEdite)
        {
            if (getPersonForEdite.Id == Guid.Empty)
            {
                return NotFound();
            }
            var person = await _personApplicationService.GetForEditAsync(getPersonForEdite);
            if (person == null)
            {
                return NotFound();
            }
            var putPersonDto = new PutPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return View(putPersonDto);
        }
        #endregion

        #region [ - Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutPersonDto putPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.PutAsync(putPersonDto);
                return RedirectToAction(nameof(Index));
            }
            return View(putPersonDto);
        }
        #endregion

        #endregion

        #region [- Delete() -]

        #region [- Get -]
        public async Task<IActionResult> Delete(GetPersonForDelete getPersonForDelete)
        {
            if (getPersonForDelete.Id == Guid.Empty)
            {
                return NotFound();
            }
            var person = await _personApplicationService.GetForDeleteAsync(getPersonForDelete);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        #endregion

        #region [- Post -]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DeletePersonDto deletePersonDto)
        {
            await _personApplicationService.DeleteAsync(deletePersonDto); 
            return RedirectToAction(nameof(Index));
        }  
        #endregion

        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            return View(await _personApplicationService.GetAsync());
        }
        #endregion

        #region [- Details() -]
        public async Task<IActionResult> Details(PersonDetail personDetail)
        {
            if (personDetail.Id == Guid.Empty)
            {
                return NotFound();
            }
            var personViewModel = await _personApplicationService.GetPersonById(personDetail);
            if (personViewModel == null)
            {
                return NotFound();
            }
            return View(personViewModel);
        }
        #endregion

    }
}
