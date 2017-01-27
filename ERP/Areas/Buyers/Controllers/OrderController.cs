using ERP.Entities;
using ERP.Entities.Models;
using ERP.Entities.SParams;
using ERP.Models;
using ERP.Services;
using ERP.Services.Masters;
using ERP.Services.Utilities;
using ERP.Servicess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Buyers.Controllers
{
    public class OrderController : Controller
    {
        IProductService _productService;
        ILoggerService _logService;
        IBuyerOrderItemService _orderItemService;
        IBuyerOrderService _orderService;
        IBuyerService _buyerService;
        IOrderStatusService _orderStatusService;
        IFinancialYearService _financialYearService;
        IStoredProcedureService _storedProcedures;
        IUnitOfMaterialService _unitOfMeasurmentService;
        IProductSKUService _productSKUService;
        public OrderController(IProductService productService,
            ILoggerService logService,
            IBuyerOrderService orderService,
            IBuyerOrderItemService orderItemService,
            IBuyerService buyerService,
            IOrderStatusService orderStatusSerice,
            IFinancialYearService financialYearService,
            IStoredProcedureService storedProcedures,
            IUnitOfMaterialService unitOfMeasurmentService,
            IProductSKUService productSKUService)
        {
            _productService = productService;
            _logService = logService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _buyerService = buyerService;
            _orderStatusService = orderStatusSerice;
            _financialYearService = financialYearService;
            _storedProcedures = storedProcedures;
            _unitOfMeasurmentService = unitOfMeasurmentService;
            _productSKUService = productSKUService;
        }

        // GET: Buyers/Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderPosting()
        {

            var productList = _productService.Query().Include(x => x.ProductSkus).Include(x => x.UOMMain).Select(x => x).ToList();
            productList = productList.Where(x => x.Status).ToList();
            List<OrderProductVM> _products = null;
            if (productList != null && productList.Count > 0)
            {
                _products = productList.Select(x => new OrderProductVM
                 {
                     Product = x
                 }).ToList();
            }
            var OrderInitialDetails = _storedProcedures.GetOrderDetails(new OrderDetailsParam { OrderId = 1 }).Result;
            OrderPostingVM masterOrderModel = new OrderPostingVM
            {
                OrderNumber = OrderInitialDetails.OrderNumber,
                OrderStatus = OrderInitialDetails.OrderStatus,
                Products = _products
            };
            return View(masterOrderModel);
        }

        [HttpPost]
        public JsonResult PlaceOrder(OrderPostingVM orderModel)
        {
            var buyer = _buyerService.Queryable().Where(x => x.BuyerId == 123456).FirstOrDefault();
            var orderStatus = _orderStatusService.Queryable().Where(x => x.ID == 1).FirstOrDefault();
            var finYear = _financialYearService.Queryable().Where(x => x.ID == 1).FirstOrDefault();

            #region Create Order
            BuyerOrder orderObject = new BuyerOrder
            {
                Buyer = buyer,
                OrderStatus = orderStatus,
                FinYear = finYear,

            };
            #endregion

            #region add items to order and map order to order items

            #endregion

            return Json(null);
        }

        [HttpPost]
        public JsonResult GetFreeQuantityOnOrder(GetFreeQuantityOnOrderParams param)
        {
            var response = _storedProcedures.GetFreeQuantityOnOrder(param).Result;
            return Json(response);
        }
        public ActionResult OrderScheduling()
        {
            return View();
        }
        public ActionResult OrderTracker()
        {
            return View();
        }
        public ActionResult OrderDetails()
        {
            return View();
        }
    }
}