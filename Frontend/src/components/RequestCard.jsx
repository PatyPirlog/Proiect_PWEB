import React, { useCallback, useState, useEffect } from "react";
import { Card, Badge, Button } from "react-bootstrap";
import { useAuth0 } from "@auth0/auth0-react";
import jwt from 'jwt-decode';

const RequestCard = ({
    id,
    categoryName, 
    countryName, 
    title,
    description,
    userName, 
    userEmail, 
    userPhone,
    address,
    buttonName,
    onAction
}) => {

    const { getAccessTokenSilently } = useAuth0();

  const [permissions, setPermissions] = useState("");
  
  const getPermissions = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    const data = jwt(accessToken);
    setPermissions(data.permissions);
    console.log(data);

  }, [getAccessTokenSilently]);

  useEffect(() => {
    getPermissions()
  }, []);

    return (
        <Card style={{ width: '100%'}}>
        <Card.Body>
            <div className="d-flex justify-content-between">
                <div>
                    <Card.Title className="mb-2 text-muted">{title}</Card.Title>
                    <Card.Text className="mt-1 mb-1">
                        <Badge pill bg="info">{categoryName}</Badge>
                        {' '}{' '}{' '}{' '}
                        <Badge pill bg="info">{countryName}</Badge>
                    </Card.Text>
                    <Card.Text className="mt-1 mb-1"> Description: {description} </Card.Text>
                    {userName && 
                    <Card.Text className="mt-1 mb-1"> Name: {userName} </Card.Text>}
                    {userEmail && 
                    <Card.Text className="mt-1 mb-1"> Email: {userEmail} </Card.Text>}
                    {userPhone && 
                    <Card.Text className="mt-1 mb-1"> Phone: {userPhone} </Card.Text>}
                    {address && 
                    <Card.Text className="mt-1 mb-1"> Address: {address} </Card.Text>}
                </div>

                <div className="d-flex align-items-center" >
                    {permissions[0] !== "admin" &&
                    <Button variant="outline-info" size="md" onClick={onAction}>
                        {buttonName}
                    </Button>
                    }
                </div>
            </div>
        </Card.Body>
        </Card>
    )
};

export default RequestCard;