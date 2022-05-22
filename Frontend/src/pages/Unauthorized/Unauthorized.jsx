import React, { useEffect } from "react";
import Layout from "../../utils/Layout";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router-dom";

const UnauthorizedPage = () => {
	const { isAuthenticated } = useAuth0();
	const navigate = useNavigate();

	useEffect(() => {
		if (!isAuthenticated) {
			navigate("/requests");
		}
	}, [isAuthenticated]);

	return (
		<>
			<Layout>Unauthorized</Layout>
		</>
	);
};

export default UnauthorizedPage;
