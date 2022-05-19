const base = "https://localhost:7074/api/v1/";
const routes = {
    request: {
        getAll: "Request/getAllRequests",
        get: (id) => `Request/getRequestDetails?id=${id}`,
        addRequest: "Request/addRequest"
    },
    subscription: {
        getSubscriptions: (id) => `Subscription/getAllSubscriptionsForUser?id=${id}`,
        addSubscriptions: 'Subscription/addSubscriptions'
    
    },
    country: {
        getAll: "Country/getAllCountries"
    },
    category: {
        getAll: "Category/getAllCategories"

    }
};

export { base, routes };