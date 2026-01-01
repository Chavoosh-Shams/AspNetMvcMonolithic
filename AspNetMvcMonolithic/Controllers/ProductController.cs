using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.ApplicationServices.Services;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        #region [- Private Fields -]
        private readonly IProductApplicationService _productApplicationService;
        #endregion

        #region [- Ctor -]
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
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
        public async Task<IActionResult> Create(PostProductDto postProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.PostAsync(postProductDto);
                return RedirectToAction(nameof(Index));
            }
            return View(postProductDto);
        }
        #endregion

        #endregion

        #region [- Edit() -]

        #region [- Get -]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await _productApplicationService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var putProductDto = new PutProductDto()
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                ProductDescription = product.ProductDescription,
            };
            return View(putProductDto);
        }
        #endregion

        #region [- Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PutProductDto putProductDto)
        {
            if (id != putProductDto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _productApplicationService.PutAsync(putProductDto);
                }
                catch (Exception)
                {
                    if (!ProductExists(putProductDto.Id))
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
            return View(putProductDto);
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
            var product = await _productApplicationService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        #endregion

        #region [- Post -]
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _productApplicationService.GetProductByIdAsync(id);
            if(product != null)
            {
                var deleteProductDto = new DeleteProductDto()
                {
                    Id = product.Id
                };
                await _productApplicationService.DeleteAsync(deleteProductDto);
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #endregion

        #region [- Index() -]

        public async Task<IActionResult> Index()
        {
            return View(await _productApplicationService.GetAsync());
        }
        #endregion

        #region [- Details() -]

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await _productApplicationService.GetProductByIdAsync(id);
            if( product == null)
            {  
                return NotFound(); 
            }
            return View(product);
        }

        #endregion

        private bool ProductExists(Guid id)
        {
            return _productApplicationService.Equals(id);
        }
    }
}
