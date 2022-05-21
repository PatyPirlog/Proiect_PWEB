import React, { useCallback, useEffect, useState, useRef } from "react";
import Layout from "../../utils/Layout";
import axiosInstance from "../../configs/Axios";
import { useAuth0 } from "@auth0/auth0-react";
import { routes } from "../../configs/Api";
import {
	Button,
	Container,
	CloseButton,
	Col,
	Form,
	ListGroup,
	Card,
} from "react-bootstrap";
import { authSettings } from "../../AuthSettings";
import { Link, useNavigate } from "react-router-dom";
import jwt from "jwt-decode";

const Categories = () => {
	const { getAccessTokenSilently } = useAuth0();
	const [categories, setCategories] = useState([]);

	const [permissions, setPermissions] = useState("");
	const navigate = useNavigate();

	const getPermissions = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		const data = jwt(accessToken);
		setPermissions(data.permissions);
		console.log(data);
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getPermissions();
	}, []);

	const getAllCategories = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		//console.log(user);
		axiosInstance
			.get(routes.category.getAll, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setCategories(data);
			});
	}, [getAccessTokenSilently]);

	const onDelete = async (category) => {
		const accessToken = await getAccessTokenSilently();
    const apiPayload = {};
    apiPayload.id = category.id;
		axiosInstance
			.post(routes.category.delete, apiPayload, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(() => getAllCategories());
	};

	const onAdd = async () => {
		const apiPayload = {};
		const accessToken = await getAccessTokenSilently();

		apiPayload.name = document.getElementById("name").value;
		console.log(apiPayload);
		axiosInstance
			.post(routes.category.add, apiPayload, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				}        
			})
			.then(() => {
				/** @todo after response?? */
			});
	};

	useEffect(() => {
		getAllCategories();
	}, [getAllCategories]);

	// de adaugat si permisions
	return (
		<>
			{permissions[0] === "admin" && (
				<Layout>
					<Container>
						<Card style={{ width: "70%" }}>
							<Card.Body>
								<Card.Title>All categories</Card.Title>
								<Card.Text>
									<ListGroup variant="flush">
										<Form className="mt-5" onSubmit={onAdd}>
											<Form.Group className="mb-3">
												<div className="d-flex justify-content-between mr-3">
													<Form.Control
														className="col-9"
														placeholder="Enter category"
														id="name"
													/>
													<Button
														variant="outline-success"
														size="sm"
														type="submit"
													>
														Add category
													</Button>
												</div>
											</Form.Group>
										</Form>
										{categories.map((category) => (
											<ListGroup.Item className="d-flex justify-content-between">
												{category.name}

												<Button
													variant="outline-danger"
													size="sm"
													onClick={() =>
														onDelete(category)
													}
												>
													Delete
												</Button>
											</ListGroup.Item>
										))}
									</ListGroup>
								</Card.Text>
							</Card.Body>
						</Card>
					</Container>
				</Layout>
			)}
		</>
	);
};

export default Categories;
