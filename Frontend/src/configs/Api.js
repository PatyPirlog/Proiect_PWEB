const base = "https://localhost:7074/api/v1/";
const routes = {
    request: {
        getAll: "Request/getAllRequests",
        get: (id) => `Request/getRequestDetails?id=${id}`,
        addRequest: "Request/addRequest",
        getRequestsForUser: "Request/getAllRequestsForUser"
    },
    subscription: {
        getSubscriptions: "Subscription/getAllSubscriptionsForUser",
        addSubscriptions: 'Subscription/addSubscriptions'
    
    },
    country: {
        getAll: "Country/getAllCountries"
    },
    category: {
        getAll: "Category/getAllCategories"

    },
    user: {
        addProfile: "User/addProfile"
    }
};

export { base, routes };