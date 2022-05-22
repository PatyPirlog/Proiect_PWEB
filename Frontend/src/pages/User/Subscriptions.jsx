import React, { useCallback, useEffect, useState } from "react";
import { Button, Container, ListGroup, Card } from "react-bootstrap";
import axiosInstance from "../../configs/Axios";
import { routes } from "../../configs/Api";
import { useAuth0 } from "@auth0/auth0-react";
import Layout from "../../utils/Layout";
import SubscriptionModal from "../../components/SubscriptionModal";
import { useNavigate } from "react-router-dom";
import "../../styling/global.css";
import "../../styling/user.css";

function Subscriptions() {
	const [subscriptions, setSubscriptions] = useState([]);
	const { getAccessTokenSilently } = useAuth0();
	const [openedModal, setOpenedModal] = useState(false);
	const navigate = useNavigate();

	const getAllSubscriptions = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.get(routes.subscription.getSubscriptions, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setSubscriptions(data);
			})
			.catch(() => {
				navigate(`/unauthorized`);
			});
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getAllSubscriptions();
	}, [getAllSubscriptions]);

	const onSubscriptionDelete = async (subscription) => {
		const accessToken = await getAccessTokenSilently();
		const apiPayload = {};
		apiPayload.id = subscription.id;
		axiosInstance
			.post(routes.subscription.deleteSubscription, apiPayload, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(() => getAllSubscriptions());
	};

	return (
		<Layout>
			<SubscriptionModal
				modalIsOpen={openedModal}
				closeModal={() => {
					setOpenedModal(false);
				}}
				showSubscriptions={false}
			/>
			<Container
				className="mt-5 mb-5 justify-content-center"
				style={{ width: "30rem" }}
			>
				<div className="d-flex d-flex flex-row mt-4 mb-4 justify-content-md-center">
					<Button
						className="button button-info"
						onClick={() => setOpenedModal(true)}
					>
						Add new subscription
					</Button>
				</div>
				<Card style={{ width: "100%" }}>
					<Card.Body>
						<Card.Title className="title">
							Your subscriptions
						</Card.Title>
						<Card.Text className="text">
							<ListGroup variant="flush">
								{subscriptions.map((subscription) => (
									<ListGroup.Item className="d-flex justify-content-between">
										{subscription.countryName}

										<Button
											className="button button-delete"
											id="button-delete-subscription"
											onClick={() =>
												onSubscriptionDelete(
													subscription
												)
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
	);
}

export default Subscriptions;
