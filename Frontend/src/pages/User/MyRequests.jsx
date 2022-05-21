import React, { useCallback, useEffect, useState } from "react";
import Layout from "../../utils/Layout";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router-dom";
import axiosInstance from "../../configs/Axios";
import { routes } from "../../configs/Api";

const MyRequests = () => {
  const { isAuthenticated, user, getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  useEffect(() => {
    if (!isAuthenticated) {
      navigate('/requests');
    }
  }, [isAuthenticated]);


 
  const [myrequests, setMyrequests] = useState([]);

  const getUserRequests = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance.get(routes.request.getRequestsForUser, {
        headers: {
            Authorization: `Bearer ${accessToken}`,
          }
    }).then(({ data }) => {
        setMyrequests(data);
      })
  }, [getAccessTokenSilently]);

   useEffect(() => {
    getUserRequests();
  }, [getUserRequests]);
  return (
    <>
      <Layout>MyRequests</Layout>
      <p>{user.email}</p>
      {myrequests.map((request) => {
          return(
            <>
                <p>{request.id}</p>
                <p>{request.userEmail}</p>
                <p>{request.categoryName}</p>
                <p>{request.countryName}</p>
                <p>{request.address}</p>
                <p>{request.description}</p>
                <p>{request.name}</p>
                <p>{request.surname}</p>
                <p>{request.phone}</p>
            </>
          )
      })}

    </>
  );
};

export default MyRequests;