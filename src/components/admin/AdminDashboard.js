/** @format */
import React from "react";
import { useNavigate } from "react-router-dom";

export default function AdminDashboard() {
    const navigate = useNavigate();

    const buttonStyle = {
        padding: "12px 24px",
        backgroundColor: "#4CAF50", // Green background
        color: "white", // White text
        border: "none",
        borderRadius: "8px", // Rounded corners
        cursor: "pointer",
        fontSize: "16px",
        fontWeight: "bold",
        transition: "background-color 0.3s ease", // Smooth hover transition
        boxShadow: "0 4px 6px rgba(0, 0, 0, 0.1)", // Subtle shadow
    };

    const buttonHoverStyle = {
        backgroundColor: "#45a049", // Darker green on hover
    };

    const handleHover = (e, hover) => {
        e.target.style.backgroundColor = hover ?
            buttonHoverStyle.backgroundColor :
            buttonStyle.backgroundColor;
    };

    return ( <
        div style = {
            { textAlign: "center", marginTop: "50px" } } >
        <
        h1 > Admin Dashboard < /h1> <
        div style = {
            {
                display: "flex",
                justifyContent: "center",
                gap: "20px", // Adds spacing between buttons
                marginTop: "20px",
            }
        } >
        <
        button style = { buttonStyle }
        onMouseEnter = {
            (e) => handleHover(e, true) }
        onMouseLeave = {
            (e) => handleHover(e, false) }
        onClick = {
            () => navigate("/placeorder") } >
        Place Order <
        /button> <
        button style = { buttonStyle }
        onMouseEnter = {
            (e) => handleHover(e, true) }
        onMouseLeave = {
            (e) => handleHover(e, false) }
        onClick = {
            () => navigate("/adminorders") } >
        View Orders <
        /button> <
        button style = { buttonStyle }
        onMouseEnter = {
            (e) => handleHover(e, true) }
        onMouseLeave = {
            (e) => handleHover(e, false) }
        onClick = {
            () => navigate("/customerlist") } >
        Customer List <
        /button> <
        button style = { buttonStyle }
        onMouseEnter = {
            (e) => handleHover(e, true) }
        onMouseLeave = {
            (e) => handleHover(e, false) }
        onClick = {
            () => navigate("/medicine") } >
        Manage Medicine <
        /button> <
        /div> <
        /div>
    );
}