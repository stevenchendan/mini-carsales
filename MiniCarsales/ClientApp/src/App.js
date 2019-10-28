import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { CarsManagement } from './components/CarsManagement';
import 'antd/dist/antd.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
      <Route exact path='/' component={Home} />
        <Route path='/cars' component={CarsManagement} />
      </Layout>
  );
}
}
