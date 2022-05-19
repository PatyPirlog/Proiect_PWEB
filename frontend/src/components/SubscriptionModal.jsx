import React, { useCallback, useEffect, useState } from "react";
import { Button, CloseButton, Col, Form, ListGroup, Modal } from "react-bootstrap";
import axiosInstance from "../configs/Axios";
import { routes } from "../configs/Api";
import MultiSelect from "react-bootstrap-multiselect";
import DropdownMultiselect from "react-multiselect-dropdown-bootstrap";


const SubscriptionModal = ({ modalIsOpen, closeModal }) => {
    const [subscriptions, setSubscriptions] = useState([]);
    const [countries, setCountries] = useState([]);
   const [selectedCountries, setSelectedCountries] = useState([]);
   const [saved, setSaved] = useState(false);

    const userId = "A7C99B00-EF19-4A22-902C-09D312ACA551" //@todo
    
    const onSave = async () => {
        let apiPayload = [];
        for ( let id of selectedCountries) {
            apiPayload.push({
                "description": "",
                "userId": userId,
                "countryId": id
            })
        }

        // Update data, send request to the server
        //const accessToken = await getAccessTokenSilently();
        axiosInstance
            .post(routes.subscription.addSubscriptions, apiPayload, {
            headers: {
                //Authorization: `Bearer ${accessToken}`,
            },
            })
            .then(() => getAllSubscriptions());
        
        setSaved(true);
        //closeModal();
        setSelectedCountries([])
    };

    const getAllSubscriptions = useCallback(async () => {
    axiosInstance
      .get(routes.subscription.getSubscriptions(userId), {
        headers: {
          //Authorization: `Bearer ${accessToken}`,
        }
      })
      .then(({ data }) => {
        setSubscriptions(data)
      });
  }, [/*getAccessTokenSilently*/]);

  const getAllCountries = useCallback(async () => {
    axiosInstance
      .get(routes.country.getAll, {
        headers: {
          //Authorization: `Bearer ${accessToken}`,
        }
      })
      .then(({ data }) => {
        setCountries(data)
      });
  }, [/*getAccessTokenSilently*/]);


  useEffect(() => {
    getAllSubscriptions();
    getAllCountries();
  }, [getAllSubscriptions, getAllCountries]);

  return (
    <Modal show={modalIsOpen} onHide={closeModal}>

    <Modal.Header >
        <Modal.Title>Stay informed</Modal.Title>
        <CloseButton variant="white" onClick={closeModal}/>
    </Modal.Header>
    
    <Modal.Body>
    {/* Add subscriptions */}
        <h6>Add your favourite locations to stay tunned</h6>
        <DropdownMultiselect
            options={countries.map((country) => ({"key": country.id, "label": country.name}))}
            name="countries"
            handleOnChange={(key) => {
                setSelectedCountries(key);
                if (saved) {
                    setSaved(false);
                }
            }}
            key={saved}
            />
    
    </Modal.Body>
    <Modal.Body>
    {/* Your subscriptions */}
        <h6>Your subscriptions</h6>
        <ListGroup variant="flush">
        { subscriptions.map((subscription) =>  
            <ListGroup.Item>
                 {subscription.countryName}
            </ListGroup.Item>
          )}
        </ListGroup>
    </Modal.Body>
    
    <Modal.Footer>
      <Button variant="secondary" onClick={closeModal}>
        Close
      </Button>
      <Button variant="info" onClick={onSave}>
        Save Changes
      </Button>
    </Modal.Footer>
  </Modal>
  )
};

export default SubscriptionModal;
