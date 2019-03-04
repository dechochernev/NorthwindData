import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/NorthwindStore';

class TerritoriesForRegion extends Component {
    componentWillMount() {
        this.props.requestTerritoriesForRegion(this.props.match.params.regionId);
    }

    render() {
        return (
            <div>
                <h1>Territories for {GetRegionName(this.props)} region</h1>
                {renderTerritoriesTable(this.props)}
            </div>
        );
    }
}

function renderTerritoriesTable(props) {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {props.territories.map(territory =>
                    <tr key={territory.territoryId}>
                        <td>{territory.territoryDescription}</td>
                        <td>
                            <Link className='btn btn-default pull-left' to={`/employeesForTerritory/${territory.territoryId}`}> >> </Link>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

function GetRegionName(props) {
    if (props) {
        if (props.regions && props.regions.length) {
            const regions = props.regions;
            return regions.find(region => region.regionId == props.match.params.regionId).regionDescription;
        }
    }
    return '';

}

export default connect(
    state => state.northwindStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(TerritoriesForRegion);
