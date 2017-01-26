angular.module("erpApp").service("buyerOrderPostingService", function ($http, RESOURCES, $resource) {
    $http.defaults.headers.common['Content-type'] = 'application/json';
    return $resource(null, null, {
        getFreeQuantityOnOrder: {
            isArray: false,
            method: 'POST',
            url: RESOURCES.GetFreeQuantityOnOrder
        },
        postBuyerOrder: {
            isArray: false,
            method: 'POST',
            url: RESOURCES.PostBuyerOrder
        }
    });
});