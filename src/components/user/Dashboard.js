/** @format */

import React from "react";
import { Link } from "react-router-dom";

export default function Dashboard() {
    return ( <
        div style = { styles.container } >
        <
        header style = { styles.header } >
        <
        h1 > User Dashboard < /h1>{" "} < /
        header > { " " } <
        nav style = { styles.nav } >
        <
        ul style = { styles.navList } >
        <
        li style = { styles.navItem } >
        <
        Link to = "/order" > Orders < /Link>{" "} < /
        li > { " " } <
        li style = { styles.navItem } >
        <
        Link to = "/profile" > Profile < /Link>{" "} < /
        li > { " " } <
        li style = { styles.navItem } >
        <
        Link to = "/products" > Products < /Link>{" "} < /
        li > { " " } <
        /ul>{" "} < /
        nav > { " " } <
        main style = { styles.mainContent } >
        <
        h2 style = { styles.movingText } > Welcome to your Dashboard < /h2>

        <
        p > Select a section from the menu to view your information. < /p>{" "} < /
        main > { " " } <
        footer style = { styles.footer } >
        <
        p > ©2024 Your Company.All rights reserved. < /p>{" "} < /
        footer > { " " } <
        /div>
    );
}

const styles = {
    container: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        fontFamily: "Arial, sans-serif",
    },
    header: {
        backgroundColor: "#282c34",
        padding: "20px",
        color: "white",
        textAlign: "center",
        width: "100%",
    },
    nav: {
        margin: "20px 0",
        width: "100%",
        textAlign: "center",
    },
    navList: {
        listStyleType: "none",
        padding: 0,
        display: "flex",
        justifyContent: "space-around",
    },
    navItem: {
        fontSize: "18px",
    },
    mainContent: {
        backgroundColor: "#f9f9f9",
        padding: "20px",
        width: "80%",
        textAlign: "center",
        boxShadow: "0px 4px 6px rgba(0, 0, 0, 0.1)",
    },
    movingText: {
        color: "red",
        fontSize: "24px",
        animation: "moveText 10s linear infinite",
    },
    footer: {
        marginTop: "20px",
        textAlign: "center",
    },
};

// Define the keyframes for the animation
const styleSheet = document.styleSheets[0];
styleSheet.insertRule(`
@keyframes moveText {
    0% {
        transform: translateX(100%);
    }
    100% {
        transform: translateX(-100%);
    }
}`, styleSheet.cssRules.length);