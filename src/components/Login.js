/** @format */

import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { baseUrl } from "./constant";

export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [successMessage, setSuccessMessage] = useState("");
    const navigate = useNavigate();

    const handleLogin = async() => {
        try {
            const response = await axios.post(`${baseUrl}/api/Users/login`, {
                email,
                password,
            });
            console.log(response.data); // Handle login success (e.g., storing tokens)
            setSuccessMessage("Login successful! Redirecting...");
            setTimeout(() => {
                navigate("/dashboard"); // Redirect to the dashboard or another page upon successful login
            }, 2000); // Delay to show success message
        } catch (error) {
            if (error.response.status === 401) {
                setError("Invalid credentials. Please check your email and password.");
            } else if (error.response.status === 404) {
                setError("User not found. Redirecting to registration...");
                setTimeout(() => {
                    navigate("/registration"); // Redirect to registration page if user is not registered
                }, 2000); // Delay to show error message
            } else {
                setError("An unexpected error occurred. Please try again later.");
            }
        }
    };

    const handlePasswordReset = () => {
        // Handle password reset logic here
        // Redirect to password reset page or show a modal for resetting password
        navigate("/password-reset");
    };

    return ( <
            div >
            <
            h1 > Login < /h1>{" "} <
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
            button onClick = { handleLogin } > Login < /button>{" "} {
                error && < p style = {
                    { color: "red" } } > { error } < /p>}{" "} {
                    successMessage && < p style = {
                            { color: "green" } } > { successMessage } < /p>}{" "} <
                        p >
                        Forgot your password ? { " " } <
                        button onClick = { handlePasswordReset } > Reset Password < /button>{" "} <
                        /p>{" "} <
                        /div>
                );
            }