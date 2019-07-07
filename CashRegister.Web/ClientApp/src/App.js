import React, { Component } from 'react';
import { Route } from 'react-router';
import CashRegisterSelect from "./components/CashRegisterSelect"
import CashierSelect from "./components/CashierSelect"
import CashRegister from "./components/CashRegister"

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div>
        <Route exact path='/' component={CashRegisterSelect} />
        <Route path='/cashier-select' component={CashierSelect} />
        <Route path='/cash-register' component={CashRegister} />
      </div>
    )
  }
}
