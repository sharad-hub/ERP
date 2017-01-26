angular.module('erpApp', ["ngResource"]).constant('RESOURCES', (function () {
	var resource = "http://"+location.host;
	return {
		USERS_DOMAIN: resource,
		GetFreeQuantityOnOrder: resource + "/buyers/order/GetFreeQuantityOnOrder",
        PostBuyerOrder:resource+"/buyers/order/PlaceOrder"
	}
})());