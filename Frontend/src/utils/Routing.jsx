import React, { useEffect } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Categories from "../pages/Admin/Categories";
import Request from "../pages/User/Request";
import RequestForm from "../pages/User/RequestForm";
import RequestsList from "../pages/RequestsList";
import MyRequests from "../pages/User/MyRequests";
import Subscriptions from "../pages/User/Subscriptions"
import { useAuth0 } from "@auth0/auth0-react";

const Router = () => {  const { 
  isAuthenticated, loginWithRedirect } = useAuth0();

  useEffect(() => {
    if (!isAuthenticated) {
      loginWithRedirect();
    }
  }, [isAuthenticated, loginWithRedirect]);

  return (
    isAuthenticated && (
      <BrowserRouter>
        <Routes>
            <Route exact path="/requests" element={<RequestsList />} />
            <Route exact path="/requests/:id" element={<Request />} />
            <Route exact path="/my-requests" element={<MyRequests />} />
            <Route exact path="/add-request" element={<RequestForm />} />
            <Route exact path="/categories" element={<Categories />} />
            <Route exact path="/subscriptions" element={<Subscriptions />} />
        </Routes>
      </BrowserRouter>
    )
  )
};

export default Router;
