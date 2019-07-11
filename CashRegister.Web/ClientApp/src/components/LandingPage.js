import React, { Component } from "react";
import { Link } from "react-router-dom"

export default class LandingPage extends Component{
    render() {
        return(
            <div>
                <Link to={{pathname: "/cash-register-select"}}>Pick cash register and employee</Link>
                <div>
                    EDIT ITEM
                    NABAVA STIGLA
                    POPIS RACUNA
                </div>
            </div>
        )
    }
}