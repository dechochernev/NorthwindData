import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/NorthwindStore';

class Northwind extends Component {
    componentWillMount() {
        this.props.requestRegions();
    }

    render() {
        return (
            <div>
                <h1>Northwind regions</h1>
                {renderRegionsTable(this.props)}
            </div>
        );
    }
}

function renderRegionsTable(props) {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {props.regions.map(region =>
                    <tr key={region.regionId}>
                        <td>{region.regionDescription}</td>
                        <td>
                            <Link className='btn btn-default pull-left' to={`/territoriesForRegion/${region.regionId}`}> >> </Link>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

export default connect(
    state => state.northwindStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Northwind);
