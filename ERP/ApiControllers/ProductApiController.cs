using ERP.Entities;
using ERP.Entities.DTO;
using ERP.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ERP.ApiControllers
{
    public class ProductApiController : ApiController
    {
        IUnitOfMaterialService _unitOfMaterialService;
        IProductGroupService _productGroupService;
        IProductService _productService;
        IProductSubGroupService _productSubGroupService;
        IProductColorService _productColorService;
        IProductTypeService _productTypeService;
        IProductSKUService _productSKUService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        IGodownService _godownService;
        IColorService _colorService;
        ITariffService _tariffService;
        ILoggerService _logservice;

        public ProductApiController(IProductGroupService productGroupService, IProductService productService,
             IProductSubGroupService productSubGroupService, IProductColorService productColorService,
             IProductTypeService productTypeService, IProductSKUService productSKUService, IUnitOfWorkAsync unitOfWorkAsync
            , IUnitOfMaterialService unitOfMaterialService, ILoggerService logservice
            , IGodownService godownService, IColorService colorService, ITariffService tariffService)
        {
            _unitOfMaterialService = unitOfMaterialService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _productGroupService = productGroupService;
            _productService = productService;
            _productSubGroupService = productSubGroupService;
            _productTypeService = productTypeService;
            _productSKUService = productSKUService;
            _logservice = logservice;
            _colorService = colorService;
            _tariffService = tariffService;
            _godownService = godownService;
        }
        // GET: Administration/Product
        //private WebApplication1.DB.demodataEntities db = new WebApplication1.DB.demodataEntities();

        public IQueryable<ProductDTO> GetProducts(int pageSize = 10
                        , Int32? ProductSubGroupId = null
                        , Int32? ProductTypeId = null
                        , Int32? UOMMainId = null
                        , Int32? ColorId = null
                        , Int32? TariffCodeId = null
                        , Int32? GodownId = null
                        , Int32? ProductCategoryID = null
                )
        {
            var model = _productService.Queryable();
            if (ProductSubGroupId != null)
            {
                model = model.Where(m => m.ProductSubGroupId == ProductSubGroupId.Value);
            }
            if (ProductTypeId != null)
            {
                model = model.Where(m => m.ProductTypeId == ProductTypeId.Value);
            }
            if (UOMMainId != null)
            {
                model = model.Where(m => m.UOMMainId == UOMMainId.Value);
            }
            if (ColorId != null)
            {
                model = model.Where(m => m.ColorId == ColorId.Value);
            }
            if (TariffCodeId != null)
            {
                model = model.Where(m => m.TariffCodeId == TariffCodeId.Value);
            }
            if (GodownId != null)
            {
                model = model.Where(m => m.GodownId == GodownId.Value);
            }
            if (ProductCategoryID != null)
            {
                model = model.Where(m => m.ProductCategoryID == ProductCategoryID.Value);
            }

            return model.Select(ProductDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProduct(long id)
        {
            var model = GetProductDTO(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProduct(long id, Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProductID)
            {
                return BadRequest();
            }
            _productService.Insert(model);   
            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.Update(model);

            await _unitOfWorkAsync.SaveChangesAsync();
            var ret =  GetProductDTO(model.ProductID);
            return CreatedAtRoute("DefaultApi", new { id = model.ProductID }, model);
        }

        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> DeleteProduct(long id)
        {
             Product model = await _productService.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _productService.Delete(model);
            await _unitOfWorkAsync.SaveChangesAsync();
            var ret = GetProductDTO(model.ProductID);
            return Ok(ret);
        }       

        private bool ProductExists(long id)
        {
            return _productService.Queryable().Count(e => e.ProductID == id) > 0;
        }
        private ProductDTO GetProductDTO(long id)
        {
            return _productService.Queryable().Select(ProductDTO.SELECT).FirstOrDefault(x => x.ProductID == id);
        }



        #region DEPENDENT ENTITIES


        #endregion
    }
}
