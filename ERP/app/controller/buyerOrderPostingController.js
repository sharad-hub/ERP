angular.module('erpApp').controller('buyerOrderPostingController', ['$scope', 'buyerOrderPostingService', function ($scope, buyerOrderPostingService) {
    $scope.format = 'dd-MMM-yyyy hh:mm:ss a';
    $scope.MasterObject = JSON.parse($("#hdnMasterObject").val());

    console.log($scope.MasterObject);
    $scope.MasterProductList = angular.copy($scope.MasterObject.Products);
    $scope.OrderList = [];
    $scope.addProductToTable = function () {
        var _selectedProduct = angular.copy($scope.MasterProductList);//Enumerable.From($scope.MasterProductList).Where(function (x) { return x.Product.ProductID == $scope.SelectedProductId }).FirstOrDefault());
        $scope.OrderList.push(_selectedProduct);
    };
    $scope.selectProduct = function (product, index, selectedProductId) {
        var _isValid = $scope.validateModelOnSave(index, selectedProductId, null);
        if (_isValid) {
            $scope.OrderList[index] = angular.copy(Enumerable.From($scope.MasterProductList).Where(function (x) { return x.Product.ProductID == selectedProductId }).FirstOrDefault());
            $scope.OrderList[index].SelectedProductId = selectedProductId;
            $scope.validateModel();
            $scope.calculateTotal();
        }
        else {
            $scope.OrderList[index].SelectedProductId = null;
        }


    };
    $scope.selectProductSku = function (product, index, selectedProductSkuId) {
        var selectedProdId = product.SelectedProductId;
        var _isValid = $scope.validateModelOnSave(index, selectedProdId, selectedProductSkuId);
        if (_isValid == true) {
            $scope.OrderList[index] = angular.copy(Enumerable.From($scope.MasterProductList).Where(function (x) { return x.Product.ProductID == product.SelectedProductId }).FirstOrDefault());
            $scope.OrderList[index].SelectedProductSkuId = selectedProductSkuId;
            $scope.OrderList[index].SelectedProductId = selectedProdId;
            $scope.validateModel();
            $scope.calculateTotal();
        }
        else {
            $scope.OrderList[index].SelectedProductSkuId = 0;
        }
    };
    $scope.getSchemeQuantityValue = function (product, index, selectedProductId) {
        var getFreeQuantityOnOrderSuccess = function (response) {
            $scope.OrderList[index].FreeQuantity = response.FreeQuantity;
            var skuProduct = Enumerable.From($scope.OrderList[index].Product.ProductSkus).Where(function (x) { return x.ID == $scope.OrderList[index].SelectedProductSkuId }).FirstOrDefault();
            if ($scope.OrderList[index].Product.IsMultipleSKUs) {

                $scope.OrderList[index].TotalUnitValue = $scope.OrderList[index].TotalQuantity * skuProduct.UnitPrice;
            }
            else {
                $scope.OrderList[index].TotalUnitValue = $scope.OrderList[index].TotalQuantity * $scope.OrderList[index].Product.UnitPrice;
            }
            if ($scope.OrderList[index].Product.IsMultipleSKUs) {
                $scope.OrderList[index].TotalUnitValue = $scope.OrderList[index].TotalQuantity * skuProduct.UnitPrice;
            }
            else {
                $scope.OrderList[index].TotalUnitValue = $scope.OrderList[index].TotalQuantity * $scope.OrderList[index].Product.UnitPrice;
            }

            $scope.OrderList[index].SchemeQuantityValue = $scope.OrderList[index].TotalQuantity * response.FreeQuantity;
            $scope.OrderList[index].TaxAmount = ($scope.OrderList[index].TotalUnitValue / 100) * $scope.OrderList[index].Product.TaxPercentage;
            $scope.OrderList[index].TotalAmount = $scope.OrderList[index].TotalUnitValue;
            $scope.calculateTotal();

        };
        var getFreeQuantityOnOrderError = function (error, xhr) {

        };

        var params = {
            ProductId: selectedProductId,
            ProductQuantity: $scope.OrderList[index].TotalQuantity
        }
        buyerOrderPostingService.getFreeQuantityOnOrder(null, params, getFreeQuantityOnOrderSuccess, getFreeQuantityOnOrderError);
    };
    $scope.deleteProduct = function (index) {
        $scope.OrderList.splice(index, 1);
        $scope.calculateTotal();
    };
    $scope.saveOrder = function () {
        if ($scope.checkRequired()) {
            var orderModel = {
                OrderNumber: $scope.MasterObject.OrderNumber,
                OrderDate: $scope.MasterObject.OrderDate,
                OrderStatus: $scope.MasterObject.OrderStatus,
                TotalOrderAmount: $scope.MasterObject.TotalOrderAmount,
                TotalSalesQuantity: $scope.MasterObject.TotalSalesQuantity,
                TotalFreeQuantity: $scope.MasterObject.TotalFreeQuantity,
                TotalUnitValue: $scope.MasterObject.TotalUnitValue,
                TotalSchemeQuantityValue: $scope.MasterObject.TotalSchemeQuantityValue,
                TotalTaxAmount: $scope.MasterObject.TotalTaxAmount,
                Remarks: $scope.MasterObject.Remarks,
                Products: $scope.OrderList,
            };
            var postBuyerOrderSuccess = function (response) {

            };
            var postBuyerOrderError = function (error, xhr) {

            };
            buyerOrderPostingService.postBuyerOrder(null, orderModel, postBuyerOrderSuccess, postBuyerOrderError);
        }
    };
    $scope.calculateTotal = function () {
        var totalSalesQuantity = 0;
        var totalFreeQuantity = 0;
        var totalUnitValue = 0;
        var totalSchemeQuantityValue = 0;
        var totalTaxAmount = 0;
        var totalOrderAmount = 0;
        $.each($scope.OrderList, function (index, item) {
            totalSalesQuantity += item.TotalQuantity;
            totalFreeQuantity = item.FreeQuantity;
            totalUnitValue += item.TotalUnitValue;
            totalSchemeQuantityValue += item.SchemeQuantityValue;
            totalTaxAmount += item.TaxAmount;
            totalOrderAmount += item.TotalAmount;
        });

        $scope.MasterObject.TotalSalesQuantity = totalSalesQuantity;
        $scope.MasterObject.TotalFreeQuantity = totalFreeQuantity;
        $scope.MasterObject.TotalUnitValue = totalUnitValue;
        $scope.MasterObject.TotalSchemeQuantityValue = totalSchemeQuantityValue;
        $scope.MasterObject.TotalTaxAmount = totalTaxAmount;
        $scope.MasterObject.TotalOrderAmount = totalOrderAmount;
    };
    $scope.validateModel = function () {
        var flag = true;
        $.each($scope.OrderList, function (index, item) {
            if (item.Product.IsMultipleSKUs) {
                if (item.SelectedProductId >= 0 && item.SelectedProductSkuId > 0) {
                    item.IsEnabled = true;
                }
                else {
                    item.IsEnabled = false;
                }
            }
            else {

                if (item.SelectedProductId >= 0) {
                    item.IsEnabled = true;
                }
                else {
                    item.IsEnabled = false;
                }
            }

        });
    };
    $scope.validateModelOnSave = function (index, selectedProductId, selectedProductSkuId) {
        var flag = true;
        if ($scope.OrderList.length > 1) {
            if (Enumerable.From($scope.MasterProductList).Where(function (x) { return (x.Product && x.Product.ProductID != undefined) && x.Product.ProductID == selectedProductId }).FirstOrDefault().Product.IsMultipleSKUs) {
                $.each($scope.OrderList, function (index, item) {
                    if (index <= $scope.OrderList.length - 2) {
                        if (item && item.SelectedProductId == selectedProductId && item.SelectedProductSkuId == selectedProductSkuId) {
                            flag = false;
                        }
                    }
                });
            }
            else {

                $.each($scope.OrderList, function (index, item) {
                    if (index < $scope.OrderList.length - 1) {
                        if (item && item.SelectedProductId == selectedProductId) {
                            flag = false;
                        }
                    }
                });
            }
        }
        if (!flag) {
            alert("Product already exists. Please select different product");
        }
        return flag;
    };
    $scope.checkRequired = function () {
        var flag = true;
        $.each($scope.OrderList, function (index, item) {
            if(!item.TotalQuantity || item.TotalQuantity<=0)
            {
                alert("Please fill all the information");
                flag = false;
            }

        });
        return flag;
    };
}]);