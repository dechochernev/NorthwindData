import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/NorthwindStore';

class NorthwindReporting extends Component {
    componentWillMount() {
        this.props.requestMostExpensiveProducts();
    }

    render() {
        return (
            <div>
                <h1>Northwind reporting</h1>
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
               <div>test</div>
            </tbody>
        </table>
    );
}

export default connect(
    state => state.northwindStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(NorthwindReporting);
