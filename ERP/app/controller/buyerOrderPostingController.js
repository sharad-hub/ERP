angular.module('erpApp').controller('buyerOrderPostingController', ['$scope', 'buyerOrderPostingService', function ($scope, buyerOrderPostingService) {

    $scope.MasterObject = JSON.parse($("#hdnMasterObject").val());
    $scope.MasterProductList = angular.copy($scope.MasterObject.Products);
    $scope.OrderList = [];
    $scope.addProductToTable = function () {
        var _selectedProduct = angular.copy($scope.MasterProductList);//Enumerable.From($scope.MasterProductList).Where(function (x) { return x.Product.ProductID == $scope.SelectedProductId }).FirstOrDefault());
        $scope.OrderList.push(_selectedProduct);
    };
    $scope.selectProduct = function (product, index, selectedProductId) {
        if (selectedProductId || selectedProductId == 0) {
            $scope.OrderList[index] = angular.copy(Enumerable.From($scope.MasterProductList).Where(function (x) { return x.Product.ProductID == selectedProductId }).FirstOrDefault());
            $scope.OrderList[index].SelectedProductId = selectedProductId;
            $scope.calculateTotal();
        }
    };
    $scope.getSchemeQuantityValue = function (product, index, selectedProductId) {
        var getFreeQuantityOnOrderSuccess = function (response) {
            $scope.OrderList[index].FreeQuantity = response.FreeQuantity;
            $scope.OrderList[index].TotalUnitValue = $scope.OrderList[index].TotalQuantity * $scope.OrderList[index].Product.UnitPrice;
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
    }
}]);