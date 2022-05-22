import React, { useCallback, useEffect, useState } from "react";
import { Button, Container, ListGroup, Modal } from "react-bootstrap";
import axiosInstance from "../configs/Axios";
import { routes } from "../configs/Api";
import DropdownMultiselect from "react-multiselect-dropdown-bootstrap";
import { useAuth0 } from "@auth0/auth0-react";
import "../styling/global.css";

const SubscriptionModal = ({ modalIsOpen, closeModal, showSubscriptions }) => {
	const [subscriptions, setSubscriptions] = useState([]);
	const [countries, setCountries] = useState([]);
	const [selectedCountries, setSelectedCountries] = useState([]);
	const [saved, setSaved] = useState(false);
	const { getAccessTokenSilently, user } = useAuth0();

	const onSave = async () => {
		const accessToken = await getAccessTokenSilently();
		const identityId = user["sub"].split("|")[1];
		let apiPayload = [];
		for (let id of selectedCountries) {
			apiPayload.push({
				identityId: identityId,
				email: user.email,
				countryId: id,
			});
		}

		// Update data, send request to the server
		axiosInstance
			.post(routes.subscription.addSubscriptions, apiPayload, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(() => {
				getAllSubscriptions();
				if (!showSubscriptions) {
					closeModal();
				}
			});

		setSaved(true);
		setSelectedCountries([]);
	};

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

	const getAvailableCountries = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		axiosInstance
			.get(routes.country.getAvailableCountries, {
				headers: {
					Authorization: `Bearer ${accessToken}`,
				},
			})
			.then(({ data }) => {
				setCountries(data);
			});
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getAllSubscriptions();
		getAvailableCountries();
	}, [getAllSubscriptions, getAvailableCountries]);

	return (
		<>
			<Modal show={modalIsOpen} onHide={closeModal}>
				<Container>
					<Modal.Header>
						<Modal.Title className="title">
							Stay informed
						</Modal.Title>
					</Modal.Header>

					<Modal.Body>
						{/* Add subscriptions */}
						<h6 className="subtitle">
							Add your favourite locations to stay tunned
						</h6>
						<DropdownMultiselect
							className="text"
							options={countries.map((country) => ({
								key: country.id,
								label: country.name,
							}))}
							name="countries"
							handleOnChange={(key) => {
								setSelectedCountries(key);
								if (saved) {
									setSaved(false);
								}
							}}
							key={saved}
						/>
					</Modal.Body>
					{showSubscriptions && (
						<Modal.Body className="text">
							{/* Your subscriptions */}
							<h6 className="subtitle">Your subscriptions</h6>
							<ListGroup variant="flush">
								{subscriptions.map((subscription) => (
									<ListGroup.Item>
										{subscription.countryName}
									</ListGroup.Item>
								))}
							</ListGroup>
						</Modal.Body>
					)}
					<Modal.Footer>
						<Button className="button-close" onClick={closeModal}>
							Close
						</Button>
						<Button className="button-info" onClick={onSave}>
							Save Changes
						</Button>
					</Modal.Footer>
				</Container>
			</Modal>
		</>
	);
};

export default SubscriptionModal;
