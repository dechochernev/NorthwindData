import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Northwind from './components/Northwind';
import TerritoriesForRegions from './components/TerritoriesForRegion';
import EmployeesForTerritory from './components/EmployeesForTerritory';
import NorthwindReporting from './components/NorthwindReporting';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/northwind' component={Northwind} />
        <Route path='/territoriesForRegion/:regionId?' component={TerritoriesForRegions} />
        <Route path='/employeesForTerritory/:territoryId?' component={EmployeesForTerritory} />
        <Route path='/northwindReporting' component={NorthwindReporting} />
    </Layout>
);
