import React, { useEffect } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Categories from "../pages/Admin/Categories";
import Profile from "../pages/User/Profile";
import UsersList from "../pages/Admin/UsersList";
import Request from "../pages/User/Request";
import RequestForm from "../pages/User/RequestForm";
import RequestsList from "../pages/RequestsList";
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
            <Route exact path="/add-request" element={<RequestForm />} />
            <Route exact path="/requests/:id" element={<Request />} />
            <Route exact path="/users" element={<UsersList />} />
            <Route exact path="/profile" element={<Profile />} />
            <Route exact path="/categories" element={<Categories />} />
        </Routes>
      </BrowserRouter>
    )
  )
};

export default Router;
