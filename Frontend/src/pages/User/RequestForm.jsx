import React, { useCallback, useEffect, useState, useRef } from "react";
import Layout from "../../utils/Layout";
import axiosInstance from "../../configs/Axios";
import { routes } from "../../configs/Api";
import { useAuth0 } from "@auth0/auth0-react";
import { Container, Form, Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const RequestForm = () => {
  const userId = "A7C99B00-EF19-4A22-902C-09D312ACA551" //@todo
  const { getAccessTokenSilently, user } = useAuth0();
  const navigate = useNavigate();

  const [countries, setCountries] = useState([]);
  const [categories, setCategories] = useState([]);
 
  const getAllCountries = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance
      .get(routes.country.getAll, {
        headers: {
          Authorization: `Bearer ${accessToken}`,
        }
      })
      .then(({ data }) => {
        setCountries(data)
      });
  }, [getAccessTokenSilently]);

  const getAllCategory = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance
      .get(routes.category.getAll, {
        headers: {
          Authorization: `Bearer ${accessToken}`,
        }
      })
      .then(({ data }) => {
        setCategories(data)
      });
  }, [getAccessTokenSilently]);

  useEffect(() => {
    getAllCountries();
    getAllCategory();
  }, [getAllCountries, getAllCategory]);

  const onAddRequest = async (event) => {
    const apiPayload = {}
    let selectedIndex;
    const accessToken = await getAccessTokenSilently();
    const identityId = user["sub"].split("|")[1];

    apiPayload.identityId = identityId;
    apiPayload.title = document.getElementById("title").value;
    apiPayload.name = document.getElementById("name").value;
    apiPayload.surname = document.getElementById("surname").value;
    apiPayload.phone = document.getElementById("phone").value;
    apiPayload.address = document.getElementById("address").value;
    apiPayload.description = document.getElementById("description").value;

    // category
    selectedIndex = document.getElementById("category").selectedIndex;
    apiPayload.categoryId = document.getElementById("category")[selectedIndex].getAttribute('data-key');

    // country
    selectedIndex = document.getElementById("country").selectedIndex;
    apiPayload.countryId = document.getElementById("country")[selectedIndex].getAttribute('data-key');
    
    // send the new request to server
    axiosInstance
      .post(routes.request.addRequest, apiPayload, {
      headers: {
          Authorization: `Bearer ${accessToken}`,
      },
      })
      .then(() => { /** @todo after response?? */ });
            
    navigate('/my-requests');
  }
  return (
    <Layout>
      <Container>
        <Form className="mt-5" onSubmit={onAddRequest} >
          <Form.Group className="mb-3">
            <Form.Label>Request Title</Form.Label>
            <Form.Control placeholder="Enter Title" id="title"/>
          </Form.Group>

          
          <Form.Group className="mb-3">
            <Form.Label>Name</Form.Label>
            <Form.Control placeholder="Enter Name" id="name"/>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Surname</Form.Label>
            <Form.Control placeholder="Enter Surname" id="surname"/>
          </Form.Group>
          
          <Form.Group className="mb-3">
            <Form.Label>Phone</Form.Label>
            <Form.Control placeholder="Enter Phone" id="phone"/>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Category</Form.Label><br />
            <Form.Select id="category">
              {categories.map((category) => {
                return(
                  <option key={category.id} data-key={category.id} value={category.name}> {category.name} </option>
                )
              })}
            </Form.Select>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Description</Form.Label>
            <Form.Control placeholder="Enter Description" id="description"/>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Country</Form.Label><br />
            <Form.Select id="country">
            {countries.map((country) => {
              return(
                <option key={country.id} data-key={country.id} value={country.name}> {country.name} </option>
              )
            })}
            </Form.Select>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Address</Form.Label>
            <Form.Control placeholder="Enter Address" id="address"/>
          </Form.Group>

          <Button variant="info" type="submit">
            Add Request
          </Button>
        </Form>
      </Container>
    </Layout>
  );
};

export default RequestForm;
