import React from "react";
import { Card, Badge, Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const RequestCard = ({
    id,
    categoryName, 
    countryName, 
    title, 
    address, 
    description
}) => {
    const navigate = useNavigate();
    
    const handleClick = (id) => {
        navigate(`/requests/${id}`);
    };

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
                    <Card.Text className="mt-1 mb-1"> Adress: {address} </Card.Text>
                    <Card.Text className="mt-1 mb-1"> Description: {description} </Card.Text>
                </div>
                <div className="d-flex align-items-center" >
                <Button variant="outline-info" size="md" onClick={() => handleClick(id)}>
                    Help
                </Button>
                </div>
            </div>
        </Card.Body>
        </Card>
    )
};

export default RequestCard;