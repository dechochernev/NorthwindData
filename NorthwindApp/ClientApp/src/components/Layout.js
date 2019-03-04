import React from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import NavMenu from './NavMenu';

export default props => (
    <Container fluid>
        <NavMenu />
        <Row></Row>
    <Row>
      <Col sm={1}>
      </Col>
      <Col sm={11}>
        {props.children}
      </Col>
    </Row>
  </Container>
);
