import React, { useCallback, useState, useEffect } from "react";
import Layout from "../../utils/Layout";
//import axiosInstance from "../../configs/Axios";
import RequestCard from "../../components/RequestCard";
import { Container } from "react-bootstrap";
import { routes } from "../../configs/Api";
import axiosInstance from "../../configs/Axios";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router-dom";

const MyRequests = () => {
  const { isAuthenticated, user, getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const [requests, setRequests] = useState([]);

  useEffect(() => {
    if (!isAuthenticated) {
      navigate('/requests');
    }
  }, [isAuthenticated]);


  const getUserRequests = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance.get(routes.request.getRequestsForUser, {
        headers: {
            Authorization: `Bearer ${accessToken}`,
          }
    }).then(({ data }) => {
        setRequests(data);
      })
  }, [getAccessTokenSilently]);

   useEffect(() => {
    getUserRequests();
  }, [getUserRequests]);

  return (
      <Layout>        
        <Container>
          {/* The requests list */}
          { requests.map((request, index) =>
            <RequestCard
                key={index}  
                {...(({ 
                        id, 
                        categoryName, 
                        countryName, 
                        title, 
                        description, 
                        userName, 
                        userEmail, 
                        userPhone,
                        address
                    }) => ({ 
                        id, 
                        categoryName, 
                        countryName, 
                        title, 
                        description, 
                        userName, 
                        userEmail, 
                        userPhone,
                        address 
                    }))(request)
                }
                onAction={() => {
                  console.log('Delete')
                }}
                buttonName="Delete"
            />
          )}
        </Container>
      </Layout>
  );
};

export default MyRequests;
