/** @format */

import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Registration from "./Registration";
import Cart from "./user/Cart";
import Profile from "./user/Profile";
import Order from "./user/Order";
import Dashboard from "./user/Dashboard";
import Header from "./user/Header";
import AdminDashboard from "./admin/AdminDashboard";
import AdminHeader from "./admin/AdminHeader";
import AdminOrders from "./admin/AdminOrders";
import CustomerList from "./admin/CustomerList";
import Medicine from "./admin/Medicine";
import MedicineDisplay from "./user/MedicineDisplay";
import Home from "./Home";

export default function RouterPage() {
    return ( <
        Router >
        <
        Routes >
        <
        Route path = "/"
        element = { < Home / > }
        /> <
        Route path = "/login"
        element = { < Login / > }
        /> <
        Route path = "/registration"
        element = { < Registration / > }
        /> <
        Route path = "/order"
        element = { < Order / > }
        /> <
        Route path = "/profile"
        element = { < Profile / > }
        /> <
        Route path = "/cart"
        element = { < Cart / > }
        /> <
        Route path = "/dashboard"
        element = { < Dashboard / > }
        /> <
        Route path = "/products"
        element = { < MedicineDisplay / > }
        /> <
        Route path = "/header"
        element = { < Header / > }
        /> <
        Route path = "/admindisplay"
        element = { < AdminDashboard / > }
        /> <
        Route path = "/adminheader"
        element = { < AdminHeader / > }
        /> <
        Route path = "/adminorders"
        element = { < AdminOrders / > }
        /> <
        Route path = "/customerlist"
        element = { < CustomerList / > }
        /> <
        Route path = "/medicine"
        element = { < Medicine / > }
        /> < /
        Routes > <
        /Router>
    );
}