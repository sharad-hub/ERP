using ERP.Entities;
using ERP.Entities.DTO;
using ERP.Entities.Models;
using ERP.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.ApiControllers
{
    [RoutePrefix("api/commonApi")]
    public class CommonApiController : ApiController
    {
        IUnitOfMaterialService _unitOfMaterialService;
        IProductGroupService _productGroupService;
        IProductService _productService;
        IProductSubGroupService _productSubGroupService;
        IProductColorService _productColorService;
        IProductTypeService _productTypeService;
        IProductCategoryService _productCategoryService;
        IProductSKUService _productSKUService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        IGodownService _godownService;
        IColorService _colorService;
        ITariffService _tariffService;
        ILoggerService _logservice;

        public CommonApiController(IProductGroupService productGroupService, IProductService productService,
             IProductSubGroupService productSubGroupService, IProductColorService productColorService,
             IProductTypeService productTypeService, IProductSKUService productSKUService, IUnitOfWorkAsync unitOfWorkAsync
            , IUnitOfMaterialService unitOfMaterialService, ILoggerService logservice, IProductCategoryService productCategoryService,
              IGodownService godownService, IColorService colorService, ITariffService tariffService)
        {
            _unitOfMaterialService = unitOfMaterialService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _productGroupService = productGroupService;
            _productService = productService;
            _productSubGroupService = productSubGroupService;
            _productTypeService = productTypeService;
            _productCategoryService = productCategoryService;
            _productSKUService = productSKUService;
            _logservice = logservice;
            _colorService = colorService;
            _tariffService = tariffService;
            _godownService = godownService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IQueryable<Product> GetProducts()
        {
            return _productService.Queryable();
        }
        [HttpGet]
        [Route("GetColors")]
        public IQueryable<SelectItemDTO> GetColors()
        {
            return _colorService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.Name
            });
        }
        [HttpGet]
        [Route("GetProductCategories")]
        public IQueryable<SelectItemDTO> GetProductCategories()
        {
            return _productCategoryService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.ProductCategoryName
            });
        }
        [HttpGet]
        [Route("GetProductSubGroups")]
        public IQueryable<SelectItemDTO> GetProductSubGroups()
        {
            return _productSubGroupService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.ProductSubGroupName
            });
        }
        [HttpGet]
        [Route("GetProductTypes")]
        public IQueryable<SelectItemDTO> GetProductTypes()
        {
            return _productTypeService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.TypeName
            });
        }
        [HttpGet]
        [Route("GetGodowns")]
        public IQueryable<SelectItemDTO> GetGodowns()
        {
            return _godownService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.GodownName
            });
        }
        [HttpGet]
        [Route("GetTariffs")]
        public IQueryable<SelectItemDTO> GetTariffs()
        {
            return _tariffService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.TariffName
            });
        }
        [HttpGet]
        [Route("GetUnitOfMeasurements")]
        public IQueryable<SelectItemDTO> GetUnitOfMeasurements()
        {
            return _unitOfMaterialService.Queryable().Select(x => new SelectItemDTO
            {
                Id = x.ID,
                Name = x.UOM
            });
        }

        [HttpPost]
        [Route("SaveProductSkus")]
        public IHttpActionResult SaveProductSkus(SaveSkusDTO modal)
        {
            var skusToUpdate = modal.ProductSKUs.Where(x =>  x.ID != 0);
            var skusToAdd = modal.ProductSKUs.Where(x =>  x.ID == 0);
            _productSKUService.InsertRange(skusToAdd);
            _unitOfWorkAsync.SaveChanges();
            foreach(var sku in skusToUpdate){
                try
                {
                    _productSKUService.Update(sku);
                    _unitOfWorkAsync.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logservice.LogError("Error Occoured " + ex.Message);
                    
                }
               
            }
           
            //return _unitOfMaterialService.Queryable().Select(x => new SelectItemDTO
            //{
            //    Id = x.ID,
            //    Name = x.UOM
            //});
            return Ok();
        }
    }
}
