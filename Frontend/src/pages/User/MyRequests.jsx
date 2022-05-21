import React, { useCallback, useState, useEffect } from "react";
import Layout from "../../utils/Layout";
//import axiosInstance from "../../configs/Axios";
import RequestCard from "../../components/RequestCard";
import { Container } from "react-bootstrap";
import { routes } from "../../configs/Api";
import axiosInstance from "../../configs/Axios";
import { useAuth0 } from "@auth0/auth0-react";

const MyRequests = () => {
    const userId = "A7C99B00-EF19-4A22-902C-09D312ACA551" //@todo

  const [requests, setRequests] = useState([]);
  const { getAccessTokenSilently } = useAuth0();
  
  const getRequests = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance
      .get(routes.request.getUserRequests(userId), {
        headers: {
          Authorization: `Bearer ${accessToken}`,
        },
      })
      .then(({ data }) => {
        setRequests(data)
      });
  }, [getAccessTokenSilently]);

  useEffect(() => {
    getRequests();
  }, [getRequests]);

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
