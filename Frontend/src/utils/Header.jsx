import React, { useEffect, useState, useCallback } from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import { useAuth0 } from "@auth0/auth0-react";
import jwt from "jwt-decode";

const Header = () => {
	const { logout, getAccessTokenSilently } = useAuth0();
	const [permissions, setPermissions] = useState("");

	const getPermissions = useCallback(async () => {
		const accessToken = await getAccessTokenSilently();
		const data = jwt(accessToken);
		setPermissions(data.permissions);
	}, [getAccessTokenSilently]);

	useEffect(() => {
		getPermissions();
	}, []);

	return (
		<>
			<Navbar bg="dark" variant="dark">
				<Container className="d-flex justify-content-between">
					<Navbar.Brand href="/requests">
						<img
							src={require("../assets/logo3.png")}
							width="30"
							height="30"
							className="d-inline-block align-top"
							alt="Logo"
						/>
					</Navbar.Brand>
					<Nav className="me-auto">
						<Nav.Link href="/requests">Requests</Nav.Link>
						{permissions[0] === "admin" ? (
							<Nav.Link href="/categories">Categories</Nav.Link>
						) : (
							<>
								<Nav.Link href="/add-request">
									Add request
								</Nav.Link>
								<Nav.Link href="/my-requests">
									My requests
								</Nav.Link>
								<Nav.Link href="/subscriptions">
									My subscriptions
								</Nav.Link>
							</>
						)}
						<Nav.Link
							className="signout"
							href="/"
							onClick={() => {
								logout({
									returnTo: window.location.origin,
								});
							}}
						>
							Signout
						</Nav.Link>
					</Nav>
				</Container>
			</Navbar>
		</>
	);
};

export default Header;
