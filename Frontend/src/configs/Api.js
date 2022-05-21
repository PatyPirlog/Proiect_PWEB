const base = "https://localhost:7074/api/v1/";
const routes = {
	request: {
		getAll: "Request/getAllRequests",
		get: (id) => `Request/getRequestDetails?id=${id}`,
		addRequest: "Request/addRequest",
		getRequestsForUser: "Request/getAllRequestsForUser",
	},
	subscription: {
		getSubscriptions: "Subscription/getAllSubscriptionsForUser",
		addSubscriptions: "Subscription/addMultipleSubscriptions",
		deleteSubscription: (id) => `Subscription/deleteSubscription?id=${id}`,
	},
	country: {
		getAll: "Country/getAllCountries",
		getAvailableCountries: "Country/getAvailableCountriesForUser",
	},
	category: {
		getAll: "Category/getAllCategories",
		add: "Category/addCategory",
		delete: (id) => `Category/deleteCategory?id=${id}`,
	},
	user: {
		addProfile: "User/addProfile",
	},
};

export { base, routes };
