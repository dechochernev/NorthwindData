import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import CardColumns from 'react-bootstrap/CardColumns';
import Card from 'react-bootstrap/Card';
import FormControl from 'react-bootstrap/FormControl';
import InputGroup from 'react-bootstrap/InputGroup';
import { actionCreators } from '../store/NorthwindStore';

class EmployeesForTerritory extends Component {
    componentWillMount() {
        this.props.requestEmployeesForTerritory(this.props.match.params.territoryId);
    }

    render() {
        return (
            <div>
                <h1>Employees for {GetTerritoryName(this.props)} territory</h1>
                {renderEmployeesTable(this.props)}
            </div>
        );
    }
}

function renderEmployeesTable(props) {
    return (
        <CardColumns>
            {props.employees.map(employee =>
                <Card key={employee.employeeId}>
                    <Card.Img variant="top" src={"https://randomuser.me/api/portraits/women/54.jpg"} />
                    <Card.Body>
                        <Card.Title>{employee.titleOfCourtesy + ' ' + employee.firstName + ' ' + employee.lastName}</Card.Title>
                        <Card.Subtitle className="mb-2 text-muted">{employee.title}</Card.Subtitle>
                        <InputGroup>
                            <FormControl style={{ minHeight: '130px' }} as="textarea" aria-label="With textarea" defaultValue={employee.notes} onBlur={e => props.UpdateEmployeeNotes(employee.employeeId, e.target.value, props.match.params.territoryId)} />
                        </InputGroup>
                    </Card.Body>
                    <Card.Footer className="text-center">
                        <small className="text-muted">{employee.country}</small>
                    </Card.Footer>
                </Card>
            )}
        </CardColumns>
    );
}

function GetTerritoryName(props) {
    if (props) {
        if (props.territories && props.territories.length) {
            const territories = props.territories;
            return territories.find(t => t.territoryId == props.match.params.territoryId).territoryDescription;
        }
    }
    return '';

}

export default connect(
    state => state.northwindStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(EmployeesForTerritory);
