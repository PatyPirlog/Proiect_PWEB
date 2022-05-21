import React, { useCallback, useEffect, useState, useRef }  from "react";
import Layout from "../../utils/Layout";
import axiosInstance from "../../configs/Axios";
import { useAuth0 } from "@auth0/auth0-react";
import { routes } from "../../configs/Api";
import { Button, Container, CloseButton, Col, Form, ListGroup, Card } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { authSettings } from "../../AuthSettings";

const Categories = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [categories, setCategories] = useState([]);
  const { user } = useAuth0();
  const navigate = useNavigate();

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
    getAllCategory();
  }, [getAllCategory]);

  const onDelete = async (category) => {
    const accessToken = await getAccessTokenSilently();
    axiosInstance
    .post(routes.subscription.deleteSubscription(category.id), {
    headers: {
        Authorization: `Bearer ${accessToken}`,
    },
    })
    .then(() => getAllCategory());    
  }

  const onAdd = async () => {
    const apiPayload = {}
    const accessToken = await getAccessTokenSilently();

    apiPayload.name = document.getElementById("name").value;

    axiosInstance
      .post(routes.category.add, apiPayload, {
      headers: {
          Authorization: `Bearer ${accessToken}`,
      },
      })
      .then(() => { /** @todo after response?? */ });
  }
 
  return (
    <Layout>
    <Container>

    <Card style={{ width: '70%'}}>
        <Card.Body>
            <Card.Title>All categories</Card.Title>
            <Card.Text>
                
                <ListGroup variant="flush">

                <Form className="mt-5" onSubmit={onAdd} >
          <Form.Group className="mb-3">
            <div className="d-flex justify-content-between mr-3">
            <Form.Control className="col-9" placeholder="Enter category" id="name"/>
            <Button variant="outline-success" size="sm"  type="submit">
          Add category
          </Button>
            </div>
          </Form.Group>
          </Form>
                {categories.map((category) =>  
                    <ListGroup.Item className="d-flex justify-content-between">
                        {category.name}
                    
                        <Button variant="outline-danger" size="sm" onClick={() => onDelete(category)}>
                        Delete
                        </Button>
                    </ListGroup.Item>
                )}
                </ListGroup>
            </Card.Text>
        </Card.Body>

        
    </Card>
    
    </Container>
</Layout>
  );
};

export default Categories;
