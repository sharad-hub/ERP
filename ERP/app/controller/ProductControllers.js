 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('Product');
    angular.module('Product', ['ngRoute', 'ui.bootstrap','ngDialog'])
    .controller('ProductListController', ['$scope', '$http', function ($scope, $http) {

        $http.get('/Api/ProductApi/')
        .then(function(response){$scope.data = response.data;});
    }])
    .controller('ProductDetailsController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {

        $http.get('/Api/ProductApi/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
    }])
//angular.module('erpApp').controller('productController', ['$scope', 'productService', function ($scope, productService) {
     .controller('ProductCreateController', ['$scope', '$http', '$routeParams', '$location','ngDialog', function ($scope, $http, $routeParams, $location,ngDialog) {
         $scope.data = {};
         $scope.boolArray = [{ Id: 0, Value: false, selected: true }, { Id: 1, Value: true, selected: false }];
         $http.get('/api/commonApi/GetColors/')
        .then(function(response){$scope.ColorId_options = response.data;});
         $http.get('/api/commonApi/GetGodowns/')
        .then(function(response){$scope.GodownId_options = response.data;});
         $http.get('/api/commonApi/GetProductCategories/')
        .then(function(response){$scope.ProductCategoryID_options = response.data;});
         $http.get('/api/commonApi/GetProductSubGroups/')
        .then(function(response){$scope.ProductSubGroupId_options = response.data;});
         $http.get('/api/commonApi/GetProductTypes/')
        .then(function(response){$scope.ProductTypeId_options = response.data;});
         $http.get('/api/commonApi/GetTariffs/')
        .then(function(response){$scope.TariffCodeId_options = response.data;});
         $http.get('/api/commonApi/GetUnitOfMeasurements/')
        .then(function(response){$scope.UOMMainId_options = response.data;});
        
        $scope.save = function(){
            $http.post('/Api/ProductApi/', $scope.data)
            .then(function(response){ $location.path("Product"); });
        }

        /// Modal
        $scope.openSkuModalhh = function () {
            
            $scope.showSkuModal = true;

            $modal.open({
                templateUrl: '/Administration/Product/Modal_ProductSku',
            });
        };

        $scope.okSkuModal = function () {
            $scope.showSkuModal = false;
        };

        $scope.cancelSkuModal = function () {
            $scope.showSkuModal = false;
        };
        //$scope.productSKUs = [];
        $scope.openSkuModal = function () {
            console.log("fff");
            $scope.sku = {};
            var modal = ngDialog.open({
                template: '/app/views/Product/addProductSKUs.html',
                className: 'ngdialog-theme-default',
                scope: $scope.$new()
            });
        };
        $scope.closeDialog = function () {
            ngDialog.closeAll();
        }
        $scope.addProductSku = function () {
            $scope.data.ProductSkus.push($scope.sku);
            $scope.sku = {};
        }
        $scope.cleanProductSku = function () {
            $scope.sku = {};
        }
        //ngdialog - close
    }])
    .controller('productEditController', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.boolArray = [{ Id: 0, Value: false, selected: true }, { Id: 1, Value: true, selected: false }];
        $http.get('/Api/Product/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
                $http.get('/Api/Color/')
        .then(function(response){$scope.ColorId_options = response.data;});
                $http.get('/Api/Godown/')
        .then(function(response){$scope.GodownId_options = response.data;});
                $http.get('/Api/ProductCategory/')
        .then(function(response){$scope.ProductCategoryID_options = response.data;});
                $http.get('/Api/ProductSubGroup/')
        .then(function(response){$scope.ProductSubGroupId_options = response.data;});
                $http.get('/Api/ProductType/')
        .then(function(response){$scope.ProductTypeId_options = response.data;});
                $http.get('/Api/Tariff/')
        .then(function(response){$scope.TariffCodeId_options = response.data;});
                $http.get('/Api/UnitOfMeasurement/')
        .then(function(response){$scope.UOMMainId_options = response.data;});
        
        $scope.save = function(){
            $http.put('/Api/ProductApi/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Product"); });
        }

    }])
    .controller('productDeleteController', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){
        $http.get('/Api/ProductApi/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/ProductApi/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Product"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/Product', {
                title: 'Product - List',
                templateUrl: '/Administration/Product/Product_List',
                controller: 'ProductListController'
            })
            .when('/Product/Create', {
                title: 'Product - Create',
                templateUrl: '/Administration/Product/Product_Edit',
                controller: 'ProductCreateController'
            })
            .when('/Product/Edit/:id', {
                title: 'Product - Edit',
                templateUrl: '/Administration/Product/Product_Edit',
                controller: 'ProductEditController'
            })
            .when('/Product/Delete/:id', {
                title: 'Product - Delete',
                templateUrl: '/Administration/Product/Product_Delete',
                controller: 'ProductDeleteController'
            })
            .when('/Product/:id', {
                title: 'Product - Details',
                templateUrl: '/Administration/Product/Product_Details',
                controller: 'ProductDetailsController'
            })
    }])
;

})();
