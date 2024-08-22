/** @format */

import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { baseUrl } from "./constant";

export default function Registration() {
    const [FirstName, setFirstName] = useState("");
    const [LastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleRegistration = async() => {
        try {
            const response = await axios.post(`${baseUrl}/auth/register`, {
                FirstName,
                LastName,
                email,
                password,
            });
            console.log(response.data); // Handle registration success
        } catch (error) {
            console.error("Registration failed", error);
        }
    };

    return ( <
        div >
        <
        h1 > Registration < /h1>{" "} <
        input type = "text"
        value = { FirstName }
        onChange = {
            (e) => setFirstName(e.target.value) }
        placeholder = "FirstName" /
        >
        <
        input type = "text"
        value = { LastName }
        onChange = {
            (e) => setLastName(e.target.value) }
        placeholder = "LastName" /
        >
        <
        input type = "email"
        value = { email }
        onChange = {
            (e) => setEmail(e.target.value) }
        placeholder = "Email" /
        >
        <
        input type = "password"
        value = { password }
        onChange = {
            (e) => setPassword(e.target.value) }
        placeholder = "Password" /
        >
        <
        button onClick = { handleRegistration } > Register < /button>{" "} <
        /div>
    );
}