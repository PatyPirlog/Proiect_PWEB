import React, { useCallback, useState, useEffect } from "react";
import Layout from "../utils/Layout";
import RequestCard from "../components/RequestCard";
import { Container, Button } from "react-bootstrap";
import { routes } from "../configs/Api";
import axiosInstance from "../configs/Axios";
import SubscriptionModal from "../components/SubscriptionModal";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router-dom";
import jwt from "jwt-decode";
import "../styling/global.css";

const RequestsList = () => {
	const [requests, setRequests] = useState([]);
	const [openedModal, setOpenedModal] = useState(false);
	const { getAccessTokenSilently } = useAuth0();
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

	const getAllRequests = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.get(routes.request.getAll, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setRequests(data);
			});
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getAllRequests();
	}, [getAllRequests]);

	const onHelp = (id) => {
		navigate(`/requests/${id}`);
	};

	return (
		<Layout>
			<SubscriptionModal
				modalIsOpen={openedModal}
				closeModal={() => {
					setOpenedModal(false);
				}}
				showSubscriptions={true}
			/>
			<Container className="mt-5 mb-5 justify-content-center">
				{/* The Subscribe location button */}
				<div className="d-flex d-flex justify-content-between mt-4">
					<h6 className="title mb-1">People in need of help</h6>
					{permissions[0] !== "admin" && (
						<Button
							className="button button-info"
							onClick={() => setOpenedModal(true)}
						>
							Subscribe location
						</Button>
					)}
				</div>

				{/* The requests list */}
				{requests.map((request, index) => (
					<RequestCard
						key={index}
						{...(({
							id,
							categoryName,
							countryName,
							title,
							description,
						}) => ({
							id,
							categoryName,
							countryName,
							title,
							description,
						}))(request)}
						onAction={() => onHelp(request.id)}
						buttonName="Help"
					/>
				))}
			</Container>
		</Layout>
	);
};

export default RequestsList;
