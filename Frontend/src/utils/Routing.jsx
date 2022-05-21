import React, { useEffect, useCallback, useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Categories from "../pages/Admin/Categories";
import Profile from "../pages/User/Profile";
import UsersList from "../pages/Admin/UsersList";
import Request from "../pages/User/Request";
import RequestForm from "../pages/User/RequestForm";
import RequestsList from "../pages/RequestsList";
import MyRequests from "../pages/User/MyRequests";
import Unauthorized from "../pages/Unauthorized/Unauthorized";
import { useAuth0 } from "@auth0/auth0-react";
import { Link, useNavigate  } from "react-router-dom";
//import axios from "axios";
import jwt from 'jwt-decode'
import axiosInstance from "../configs/Axios";

const Router = () => { 
   const { isAuthenticated, loginWithRedirect, user, getAccessTokenSilently } = useAuth0();
 
  useEffect(() => {
    if (!isAuthenticated) {
      loginWithRedirect();
    }
    if(isAuthenticated) {

      async function getProfile() {
        console.log("e autentificat");

        const identityId = user['sub'].split("|")[1];
        const accessToken = await getAccessTokenSilently();

        axiosInstance
        .get(`https://localhost:7074/api/v1/user/getUserProfile?identityId=${identityId}`, {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          }
        })
        .then((response) => {
          //console.log(response);
        })
        .catch((response) => {
          console.log("pe catch");
           const payload = {};
           payload.identityId = identityId;
           payload.name = "";
           payload.surname = "";
           payload.email = user.email;
           payload.phone = "";

          axiosInstance.post("https://localhost:7074/api/v1/user/addProfile", payload, {
            headers: {
              Authorization: `Bearer ${accessToken}`,
            },
          }) 
         });
      }
      getProfile();
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
            <Route exact path="/my-requests" element={<MyRequests />} />
            <Route exact path="/unauthorized" element={<Unauthorized />} />
        </Routes>
      </BrowserRouter>
    )
  )
};

export default Router;
