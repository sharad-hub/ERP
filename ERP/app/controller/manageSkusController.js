angular.module('erpApp').controller('manageSkusController', ['$scope', 'manageSkusService', function ($scope, manageSkusService) {
    $scope.MasterObject = JSON.parse($("#hdnMasterObject").val());
    console.log($scope.MasterObject);
    var ProductID = $scope.MasterObject.ProductID
    $scope.sku = {
        ProductId: ProductID,
        ID: 0
    };
    $scope.ProductSkusList = angular.copy($scope.MasterObject.ProductSKUs);
    if (!$scope.ProductSkusList)
    {
        $scope.ProductSkusList = [];
    }
    $scope.addProductToTable = function () {
        var _selectedProduct = angular.copy($scope.MasterProductList);//Enumerable.From($scope.MasterProductList).Where(function (x) { return x.Product.ProductID == $scope.SelectedProductId }).FirstOrDefault());
        $scope.OrderList.push(_selectedProduct);
    };
    
    $scope.deleteProductSku = function (index) {
        $scope.ProductSkusList.splice(index, 1);
        $scope.calculateTotal();
        $scope.currentIndex = 0;
    };
    $scope.addProductSku = function () {
        $scope.ProductSkusList.push(angular.copy($scope.sku));
        $scope.sku = {
            ProductId: ProductID,
            ID:0
        };
        $scope.currentIndex = 0;
        console.log($scope.ProductSkusList);
    }
    $scope.currentIndex = 0;
    $scope.editProductSku = function (item,$index) {
        $scope.sku = angular.copy(item);
        $scope.currentIndex=$index;
    }
    $scope.updateProductSku = function (index) {
        $scope.ProductSkusList[index] = angular.copy($scope.sku);
        $scope.currentIndex = 0;
        $scope.sku = {
            productId: ProductID,
            ID: 0
        };
    }
    $scope.cleanProductSku = function () {
        $scope.sku = { productId: ProductID };
        $scope.currentIndex = 0;
    }
    
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
    }

    $scope.saveProductSkus = function () {
        var skusModel = {
            ProductID: ProductID,
            ProductSKUs: $scope.ProductSkusList
        }
        //saveProductSkus
        var sucessHandler = function (response) {

        };
        var errorHandler = function (error, xhr) {

        };
        manageSkusService.saveProductSkus(null, skusModel, sucessHandler, errorHandler);
    }
}]);