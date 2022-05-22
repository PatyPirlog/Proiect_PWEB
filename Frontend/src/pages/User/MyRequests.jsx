import React, { useCallback, useState, useEffect } from "react";
import Layout from "../../utils/Layout";
import RequestCard from "../../components/RequestCard";
import { Container } from "react-bootstrap";
import { routes } from "../../configs/Api";
import axiosInstance from "../../configs/Axios";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router-dom";

const MyRequests = () => {
	const { isAuthenticated, getAccessTokenSilently } = useAuth0();
	const navigate = useNavigate();

	const [requests, setRequests] = useState([]);

	useEffect(() => {
		if (!isAuthenticated) {
			navigate("/requests");
		}
	}, [isAuthenticated]);

	const getUserRequests = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.get(routes.request.getRequestsForUser, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setRequests(data);
			})
			.catch(() => {
				navigate(`/unauthorized`);
			});
	}, [getAccessTokenSilently]);

	const onDelete = useCallback(
		async (request) => {
			const accessToken = await getAccessTokenSilently();
			const apiPayload = {};
			apiPayload.id = request.id;
			console.log(apiPayload);

			axiosInstance
				.post(routes.request.deleteRequest, apiPayload, {
					headers: {
						Authorization: `Bearer ${accessToken}`,
					},
				})
				.then(() => {
					getUserRequests();
				});
		},
		[getAccessTokenSilently]
	);

	useEffect(() => {
		getUserRequests();
	}, [getUserRequests]);

	return (
		<Layout>
			<Container className="mt-5 mb-5 justify-content-center">
				{/* The requests list */}
				<h6 className="title mb-5">My requests</h6>
				{requests.map((request, index) => (
					<RequestCard
						key={index}
						{...(({
							id,
							categoryName,
							countryName,
							title,
							description,
							name,
							surname,
							userEmail,
							phone,
							address,
						}) => ({
							id,
							categoryName,
							countryName,
							title,
							description,
							name,
							surname,
							userEmail,
							phone,
							address,
						}))(request)}
						onAction={() => {
							onDelete(request);
						}}
						buttonName="Delete"
					/>
				))}
			</Container>
		</Layout>
	);
};

export default MyRequests;
