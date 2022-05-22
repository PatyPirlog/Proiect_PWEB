import React, { useCallback, useEffect, useState } from "react";
import Layout from "../../utils/Layout";
import axiosInstance from "../../configs/Axios";
import { useAuth0 } from "@auth0/auth0-react";
import { routes } from "../../configs/Api";
import { Button, Container, Form, ListGroup, Card } from "react-bootstrap";
import jwt from "jwt-decode";
import { useNavigate } from "react-router-dom";

const Categories = () => {
	const { getAccessTokenSilently } = useAuth0();
	const [categories, setCategories] = useState([]);

	const [permissions, setPermissions] = useState("");
	const navigate = useNavigate();

	const getPermissions = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		const data = jwt(accessToken);
		setPermissions(data.permissions);
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getPermissions();
	}, []);

	const getAllCategories = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.get(routes.category.getAll, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setCategories(data);
			})
			.catch(() => {
				navigate(`/unauthorized`);
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
		axiosInstance
			.post(routes.category.add, apiPayload, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(() => {});
	};

	useEffect(() => {
		getAllCategories();
	}, [getAllCategories]);

	return (
		<>
			{permissions[0] === "admin" && (
				<Layout>
					<Container
						style={{ width: "40rem" }}
						className="mt-5 mb-5 justify-content-center"
					>
						<Card style={{ width: "100%" }}>
							<Card.Body>
								<Card.Title className="title">
									All categories
								</Card.Title>
								<Card.Text>
									<ListGroup variant="flush">
										<Form
											className="mt-4 text"
											onSubmit={onAdd}
										>
											<Form.Group className="mb-3">
												<div className="d-flex justify-content-between mr-3">
													<Form.Control
														className="col-9"
														placeholder="Enter category"
														id="name"
													/>
													<Button
														className="button button-info"
														type="submit"
													>
														Add category
													</Button>
												</div>
											</Form.Group>
										</Form>
										{categories.map((category) => (
											<ListGroup.Item className="d-flex justify-content-between text">
												{category.name}

												<Button
													className="button button-delete"
													id="button-delete-subscription"
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
