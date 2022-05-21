import React, { useCallback, useEffect, useState } from "react";
import {
	Button,
	Container,
	CloseButton,
	Col,
	Form,
	ListGroup,
	Card,
} from "react-bootstrap";
import axiosInstance from "../../configs/Axios";
import { routes } from "../../configs/Api";
import DropdownMultiselect from "react-multiselect-dropdown-bootstrap";
import { useAuth0 } from "@auth0/auth0-react";
import Layout from "../../utils/Layout";
import SubscriptionModal from "../../components/SubscriptionModal";

const Subscriptions = () => {
	const [subscriptions, setSubscriptions] = useState([]);
	const [countries, setCountries] = useState([]);
	const [selectedCountries, setSelectedCountries] = useState([]);
	const [saved, setSaved] = useState(false);
	const { getAccessTokenSilently } = useAuth0();
	const [openedModal, setOpenedModal] = useState(false);

	const userId = "A7C99B00-EF19-4A22-902C-09D312ACA551"; //@todo

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
			});
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getAllSubscriptions();
	}, [getAllSubscriptions]);

	const onSubscriptionDelete = async (subscription) => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.post(routes.subscription.deleteSubscription(subscription.id), {
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
				<Card style={{ width: "100%" }}>
					<Card.Body>
						<Card.Title>Your subscriptions</Card.Title>
						<Card.Text>
							<ListGroup variant="flush">
								{subscriptions.map((subscription) => (
									<ListGroup.Item className="d-flex justify-content-between">
										{subscription.countryName}

										<Button
											variant="outline-danger"
											size="sm"
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

				<div className="d-flex d-flex flex-row mt-4 mb-4 justify-content-md-center">
					<Button
						variant="outline-info"
						size="md"
						onClick={() => setOpenedModal(true)}
					>
						Add new subscription
					</Button>
				</div>
			</Container>
		</Layout>
	);
};

export default Subscriptions;
