import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Mini Carsales</h1>
        <p>This is the mini carsales home assignment</p>
        <p>Funtions: you can go to Cars page under Vehicle For Sale tab to <b>Add cars</b>, <b>Update cars</b> and <b>Delete cars</b></p>
      </div>
    );
  }
}
