const base = "https://localhost:7074/api/v1/";
const routes = {
    request: {
        getAll: "Request/getAllRequests",
        get: (id) => `Request/getRequestDetails?id=${id}`,
        addRequest: "Request/addRequest",
        getUserRequests: (id) => `Request/getAllRequestsForUser?id=${id}`
    },
    subscription: {
        getSubscriptions: (id) => `Subscription/getAllSubscriptionsForUser?id=${id}`,
        deleteSubscription: (id) => `Subscription/deleteSubscription?id=${id}`,
        addSubscriptions: 'Subscription/addSubscriptions'
    
    },
    country: {
        getAll: "Country/getAllCountries"
    },
    category: {
        getAll: "Category/getAllCategories",
        add: "Category/addCategory",
        delete: (id) => `Category/deleteCategory?id=${id}`
    }
};

export { base, routes };
