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
                <blockquote className='blockquote'>
                    <p className='mb-0'>Top 10 most expensive products</p>
                </blockquote>
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
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>
                {props.mostExpensiveProducts.map(product =>
                    <tr key={product.productId}>
                        <td>{product.productName}</td>
                        <td>{product.unitPrice}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

export default connect(
    state => state.northwindStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(NorthwindReporting);
