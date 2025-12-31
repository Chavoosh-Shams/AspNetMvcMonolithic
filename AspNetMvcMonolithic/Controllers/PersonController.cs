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
            var putPersonDto = new PutPersonDto()
            {
                FirstName = Person.FirstName,
                LastName = Person.LastName,
            };
            return View(putPersonDto);
        }
        #endregion

        #region [ - Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, PutPersonDto putPersonDto)
        {
            if (Id != putPersonDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _personApplicationService.PutAsync(putPersonDto);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(putPersonDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(putPersonDto);
        }
        #endregion

        #endregion

        #region [- Delete() -]

        #region [- Get -]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var person = await _personApplicationService.GetPersonById(id);
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
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var person = await _personApplicationService.GetPersonById(id);

            if (person != null)
            {
                var deletePersonDto = new DeletePersonDto()
                {
                    Id = id
                };
                await _personApplicationService.DeleteAsync(deletePersonDto);
            }
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

        private bool PersonExists(Guid id)
        {
            return _personApplicationService.Equals(id);
        }

    }
}
