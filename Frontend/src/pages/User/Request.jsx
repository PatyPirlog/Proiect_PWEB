import React, { useCallback, useState, useEffect } from "react";
import Layout from "../../utils/Layout";
import { routes } from "../../configs/Api";
import { useAuth0 } from "@auth0/auth0-react";
import axiosInstance from "../../configs/Axios";
import { useParams } from "react-router-dom";
import { Card, Container } from "react-bootstrap";
import "../../styling/global.css";
import "../../styling/user.css";

const Request = () => {
	const [request, setRequest] = useState([]);
	const { id } = useParams();
	const { getAccessTokenSilently } = useAuth0();
	const getRequest = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.get(routes.request.get(id), {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setRequest(data);
			});
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getRequest();
	}, [getRequest]);

	return (
		<Layout>
			<Container
				className="mt-5 mb-5 justify-content-center"
				style={{ maxWidth: "80%" }}
			>
				<div className="d-flex row justify-content-center">
					<Card className="md-6 ml-2 mr-2" style={{ width: "30rem" }}>
						<Card.Body>
							<Card.Title className="subtitle">
								{request.title}
							</Card.Title>
							<Card.Text className="text">
								{request.description}
							</Card.Text>
							<Card.Text className="text">
								Posted by {request.surname + " " + request.name}
							</Card.Text>
							<Card.Text className="text">
								Category: {request.categoryName}
							</Card.Text>
						</Card.Body>
					</Card>
					<Card className="md-6 ml-2 mr-2" style={{ width: "30rem" }}>
						<Card.Body>
							<Card.Title className="subtitle">
								Contact
							</Card.Title>
							<Card.Text className="text">
								Country: {request.countryName}
							</Card.Text>
							<Card.Text className="text">
								Address: {request.address}
							</Card.Text>
							<Card.Text className="text">
								Phone: {request.phone}
							</Card.Text>
							<Card.Text className="text">
								Email: {request.userEmail}
							</Card.Text>
						</Card.Body>
					</Card>
				</div>
			</Container>
		</Layout>
	);
};

export default Request;
