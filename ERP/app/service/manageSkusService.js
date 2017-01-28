angular.module("erpApp").service("manageSkusService", function ($http, RESOURCES, $resource) {
    $http.defaults.headers.common['Content-type'] = 'application/json';
    return $resource(null, null, {
        saveProductSkus: {
            isArray: false,
            method: 'POST',
            url: RESOURCES.saveProductSkus
        } 
    });
});