import React from 'react';
import { Link } from 'react-router-dom';
import { Nav, Navbar } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

export default props => (
    <Navbar bg="light" variant="light">
        <Navbar.Brand>
            <Link to={'/'}>NorthwindApp</Link>
        </Navbar.Brand>
        <Nav className="mr-auto">
            <LinkContainer to={'/'} exact>
                <Nav.Link>
                Home
            </Nav.Link>
                </LinkContainer>
            <LinkContainer to={'/northwind'}>
                <Nav.Link>
                    Northwind
                    </Nav.Link>
            </LinkContainer>
            <LinkContainer to={'/northwindReporting'}>
                <Nav.Link>
                    Reporting
                    </Nav.Link>
            </LinkContainer>
        </Nav>
    </Navbar>
);
