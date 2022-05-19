import React, { useCallback, useEffect, useState, useRef } from "react";
import Layout from "../../utils/Layout";
import axiosInstance from "../../configs/Axios";
import { routes } from "../../configs/Api";
import { useAuth0 } from "@auth0/auth0-react";
import { Container, Form, Button } from "react-bootstrap";

const RequestForm = () => {
  const userId = "A7C99B00-EF19-4A22-902C-09D312ACA551" //@todo
  const { getAccessTokenSilently } = useAuth0();

  const [countries, setCountries] = useState([]);
  const [categories, setCategories] = useState([]);
  // const titleRef = useRef();
  // const categoryRef = useRef();
  // const descriptionRef = useRef();
  // const countryRef = useRef();
  // const adressRef = useRef();
 
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

    apiPayload.userId = userId;
    apiPayload.title = document.getElementById("title").value;
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
            //.then(() => /* @todo after done*/);
  }
  return (
    <Layout>
      <Container>
        <Form className="mt-5" onSubmit={onAddRequest} >
          <Form.Group className="mb-3">
            <Form.Label>Title</Form.Label>
            <Form.Control placeholder="Enter Title" id="title"/>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Country</Form.Label><br />
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
            <Form.Label>Adress</Form.Label>
            <Form.Control placeholder="Enter Adress" id="address"/>
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
