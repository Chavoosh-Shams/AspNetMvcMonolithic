using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
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
        public async Task<IActionResult> Edit(GetProductForEdit getProductForEdit)
        {
            if (getProductForEdit.Id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await _productApplicationService.GetForEditAsync(getProductForEdit);
            if (product == null)
            {
                return NotFound();
            }
            var putProductDto = new PutProductDto()
            {
                Id = getProductForEdit.Id,
                Title = getProductForEdit.Title,
                DescriptionRecord = getProductForEdit.DescriptionRecord,
                UnitPrice = getProductForEdit.UnitPrice
            };
            return View(putProductDto);
        }
        #endregion

        #region [- Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutProductDto putProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.PutAsync(putProductDto);
                return RedirectToAction(nameof(Index));
            }
            return View(putProductDto);
        }
        #endregion

        #endregion

        #region [- Delete() -]

        #region [- Get -]
        public async Task<IActionResult> Delete(GetProductForDelete getProductForDelete)
        {
            if (getProductForDelete.Id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await _productApplicationService.GetForDeleteAsync(getProductForDelete);
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
        public async Task<IActionResult> DeleteConfirmed(DeleteProductDto deleteProductDto)
        {
            await _productApplicationService.DeleteAsync(deleteProductDto);
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
        public async Task<IActionResult> Details(ProductDetail productDetail)
        {
            if (productDetail.Id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await _productApplicationService.GetProductByIdAsync(productDetail);
            if ( product == null)
            {  
                return NotFound(); 
            }
            return View(product);
        }
        #endregion
    }
}
