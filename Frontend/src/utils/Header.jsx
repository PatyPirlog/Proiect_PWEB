import React from 'react';
import { Navbar, Nav, Container } from 'react-bootstrap';
import { useAuth0 } from "@auth0/auth0-react";
import { Link  } from "react-router-dom";

const Header = () => {
  const { logout, user } = useAuth0();

    return(
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
              <Nav.Link href="/add-request">Add request</Nav.Link>
              <Nav.Link href="/profile">Profile</Nav.Link>
            </Nav>
            <Link
              className="signout"
              to="/"
              onClick={() => {
                logout({ returnTo: window.location.origin });
              }}
            >
              Signout
            </Link>

          </Container>
        </Navbar>
        </>
    )  
}

export default Header;