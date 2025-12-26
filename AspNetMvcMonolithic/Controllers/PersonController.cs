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

        #region [-Edit-]
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
            var personUpdate = new PersonUpdate
            {
                Id = Person.Id,
                FirstName = Person.FirstName,
                LastName = Person.LastName,
            };
            return View(personUpdate);
        }
        

        //public async Task<IActionResult> Edit(Guid Id, [Bind("Id,FirstName,LastName")] PersonUpdate personUpdate)
        //{
        //    if (Id != personUpdate.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _personApplicationService.UpdatePersonAsync(personUpdate);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(productUpdate.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        #endregion
    }
}
