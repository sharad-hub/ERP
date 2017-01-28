
using ERP.Entities.DTO;
using ERP.Entities.Models;
using ERP.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ERP.ApiControllers
{
    public class ProductSKUController : ApiController
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

        public ProductSKUController(IProductGroupService productGroupService, IProductService productService,
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

        public IQueryable<ProductSKUDTO> GetProductSKUs(int pageSize = 10
                        ,System.Int64? ProductId = null
                )
        {
            var model =_productSKUService.Queryable();
                                if(ProductId != null){
                        model = model.Where(m=> m.ProductId == ProductId.Value);
                    }
                        
            return model.Select(ProductSKUDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProductSKUDTO))]
        public async Task<IHttpActionResult> GetProductSKU(int id)
        {
            var model = GetProductSKU(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProductSKU(int id, ProductSKU model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ID)
            {
                return BadRequest();
            }

            //db.Entry(model).State = EntityState.Modified;
            _productSKUService.Update(model);
            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSKUExists(id))
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

        [ResponseType(typeof(ProductSKUDTO))]
        public async Task<IHttpActionResult> PostProductSKU(ProductSKU model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productSKUService.Insert(model);
            await _unitOfWorkAsync.SaveChangesAsync();
            var ret = GetProductDTO(model.ID);
            return CreatedAtRoute("DefaultApi", new { id = model.ID }, model);
        }

        [ResponseType(typeof(ProductSKUDTO))]
        public async Task<IHttpActionResult> DeleteProductSKU(int id)
        {
            ProductSKU model = await _productSKUService.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _productSKUService.Delete(model);
            await _unitOfWorkAsync.SaveChangesAsync();
            var ret = GetProductDTO(model.ID);// db.ProductSKUs.Select(ProductSKUDTO.SELECT).FirstOrDefaultAsync(x => x.ID == model.ID);
            return Ok(ret);
        }        

        private bool ProductSKUExists(int id)
        {
            return _productSKUService.Queryable().Count(e => e.ID == id) > 0;
        }        
        private ProductSKUDTO GetProductDTO(long id)
        {
            return _productSKUService.Queryable().Select(ProductSKUDTO.SELECT).FirstOrDefault(x => x.ID == id);
        }
    }
}