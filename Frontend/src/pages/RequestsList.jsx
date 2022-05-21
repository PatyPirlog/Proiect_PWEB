import React, { useCallback, useState, useEffect } from "react";
import Layout from "../utils/Layout";
//import axiosInstance from "../../configs/Axios";
import RequestCard from "../components/RequestCard";
import { Container, Button } from "react-bootstrap";
import { routes } from "../configs/Api";
import axiosInstance from "../configs/Axios";
import SubscriptionModal from "../components/SubscriptionModal";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router-dom";

const RequestsList = () => {
  const [requests, setRequests] = useState([]);
  const [openedModal, setOpenedModal] = useState(false);
  const { getAccessTokenSilently } = useAuth0();
  
  const getAllRequests = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance
      .get(routes.request.getAll, {
        headers: {
          Authorization: `Bearer ${accessToken}`,
        },
      })
      .then(({ data }) => {
        setRequests(data)
      });
  }, [getAccessTokenSilently]);

  useEffect(() => {
    getAllRequests();
  }, [getAllRequests]);

  
  const navigate = useNavigate();
  const onHelp = (id) => {
    navigate(`/requests/${id}`);
  };

  return (
      <Layout>
        <SubscriptionModal
          modalIsOpen={openedModal}
          closeModal={() => {
            setOpenedModal(false);
          }}
          showSubscriptions={true}
        /> 
        
        <Container>
          
          {/* The Subscribe location button */}
          <div className="d-flex d-flex flex-row-reverse mt-4 mb-4">
            <Button variant="outline-info" size="md" onClick={() => setOpenedModal(true)}> 
              Subscribe location
            </Button>
          </div>

          {/* The requests list */}
          { requests.map((request, index) =>  
            <RequestCard key={index}  
              {...(({ 
                      id, 
                      categoryName, 
                      countryName, 
                      title, 
                      description, 
                  }) => ({ 
                      id, 
                      categoryName, 
                      countryName, 
                      title, 
                      description, 
                  }))(request)
              }
              onAction={() => onHelp(request.id)}
              buttonName="Help"
            />
          )}
        </Container>
      </Layout>
  );
};

export default RequestsList;
