import React, { Component } from 'react';
import { Route } from 'react-router';
import CashRegisterSelect from "./components/CashRegisterSelect"
import CashierSelect from "./components/CashierSelect"
import CashRegister from "./components/CashRegister"
import LandingPage from "./components/LandingPage"

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div>
        <Route exact path="/" component={LandingPage}/>
        <Route path='/cash-register-select' component={CashRegisterSelect} />
        <Route path='/cashier-select' component={CashierSelect} />
        <Route path='/cash-register' component={CashRegister} />
      </div>
    )
  }
}
