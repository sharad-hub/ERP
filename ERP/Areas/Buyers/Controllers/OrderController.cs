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
using ERP.Extensions;
using Repository.Pattern.UnitOfWork;
namespace ERP.Areas.Buyers.Controllers
{
    public class OrderController : BaseController
    {
        IProductService _productService;
        ILoggerService _logService;
        IBuyerOrderItemService _buyerOrderItemService;
        IBuyerOrderService _buyerOrderService;
        IBuyerService _buyerService;
        IOrderStatusService _orderStatusService;
        IFinancialYearService _financialYearService;
        IStoredProcedureService _storedProcedures;
        IUnitOfMaterialService _unitOfMeasurmentService;
        IProductSKUService _productSKUService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        public OrderController(IProductService productService,
            ILoggerService logService,
            IBuyerOrderService orderService,
            IBuyerOrderItemService orderItemService,
            IBuyerService buyerService,
            IOrderStatusService orderStatusSerice,
            IFinancialYearService financialYearService,
            IStoredProcedureService storedProcedures,
            IUnitOfMaterialService unitOfMeasurmentService,
            IProductSKUService productSKUService,
            IUnitOfWorkAsync unitOfWorkAsync)
        {
            _productService = productService;
            _logService = logService;
            _buyerOrderService = orderService;
            _buyerOrderItemService = orderItemService;
            _buyerService = buyerService;
            _orderStatusService = orderStatusSerice;
            _financialYearService = financialYearService;
            _storedProcedures = storedProcedures;
            _unitOfMeasurmentService = unitOfMeasurmentService;
            _productSKUService = productSKUService;
            _unitOfWorkAsync = unitOfWorkAsync;
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
            //TODO - move all logic to business rule -engile // PHASE 2 task
            var userType = User.Identity.GetUserType();
            if (userType == "BUYR")
            {
                int userId = 0;
                var tempId = User.Identity.GetUserID();
                Int32.TryParse(tempId, out userId);
                var userReferenceID = User.Identity.GetUserReferenceID();
                double buyerId = 0;
                double.TryParse(userReferenceID, out buyerId);
                var buyer = _buyerService.Queryable().Where(x => x.BuyerId == buyerId).FirstOrDefault();
                var orderStatus = _orderStatusService.Queryable().Where(x => x.TypeCode == "BY-ORD-ENTR").FirstOrDefault();
                var finYear = _financialYearService.Queryable().Where(x => x.FinYearName == "2016-2017").FirstOrDefault();

                #region Create Order
                BuyerOrder orderObject = new BuyerOrder
                {
                    //Buyer = buyer,
                    BuyerID=buyer.BuyerId,
                    OrderStatusId=orderStatus.ID,
                    //OrderStatus = orderStatus,
                    FinYear = finYear,
                    BuyerOrderNo = Guid.NewGuid().ToString(),
                    CreatedById = userId,
                    CreationDate = DateTime.Now,
                    FinYearId = finYear.ID,
                    LastModifiedById = userId,
                    LastmodifiedDate = DateTime.Now,
                    Remarks = orderModel.Remarks,
                    OrderDate = DateTime.Now, // orderModel.OrderDate,
                    TentativeOrderDate = DateTime.Now.AddDays(30) // to be entred from UI,                  

                };
                List<BuyerOrderItem> buyerOrderItems = new List<BuyerOrderItem>();

                _unitOfWorkAsync.BeginTransaction();
                try
                {
                    _logService.LogInfo(orderModel.ToJSON());
                    _buyerOrderService.Insert(orderObject);
                    _unitOfWorkAsync.SaveChanges();
                    foreach (OrderProductVM opr in orderModel.Products)
                    {
                        BuyerOrderItem obj = new BuyerOrderItem
                        {
                            BuyerOrderId = orderObject.ID,
                            MRP = opr.Product.MRP,
                            //Product =opr.Product ,
                            ProductSkuID = opr.SelectedProductSkuId,
                            Quintity = opr.TotalQuantity,
                            SchemeFreeQty = opr.SchemeQuantityValue,
                            ProductId = opr.SelectedProductId,
                            TaxAmount = opr.TaxAmount,
                            TotalOrderAmt = opr.TotalAmount,
                            TotalOrderCost = opr.TotalAmount,
                            FinYearId = finYear.ID,
                            TotalSchemeFreeAmt = opr.FreeQuantity,
                            TotalOrderQty = opr.TotalQuantity,
                            UnitPrice = opr.TotalUnitValue,
                        };
                        buyerOrderItems.Add(obj);
                    }
                    if (buyerOrderItems.Count>0)
                    _buyerOrderItemService.InsertRange(buyerOrderItems);
                    _unitOfWorkAsync.SaveChanges();
                    _unitOfWorkAsync.Commit();

                    Success(string.Format("<b>Order({0})</b> was successfully added.", orderModel.OrderNumber), true);

                }
                catch (Exception ex)
                {
                    _unitOfWorkAsync.Rollback();
                    _logService.LogError(ex.Message);
                    Danger("Looks like something went wrong. Please check your form.");
                     
                }
                #endregion
                
                #region add items to order and map order to order items

                #endregion
            }
            else
            {
                // UN AUTHORISED ACCESS --
            }
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
            int userId = 0;
            var tempId = User.Identity.GetUserID();
            Int32.TryParse(tempId, out userId);
            var userReferenceID = User.Identity.GetUserReferenceID();
            double buyerId = 0;

            var products = _buyerOrderService.Query().Include(x => x.OrderStatus).Select(x => x).Where(Y=>Y.BuyerID==buyerId).ToList();
            return View(products);
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