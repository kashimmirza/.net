/** @format */
import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "./Home.css"; // Import the CSS for styling
import medicineImage1 from "../assets/medicine1.jpeg";
import medicineImage2 from "../assets/medicine2.jpeg"; // Example image path

export default function Home() {
    const [isUser, setIsUser] = useState(true);
    const navigate = useNavigate();

    // Slider state
    const images = [medicineImage1, medicineImage2];
    const [currentImageIndex, setCurrentImageIndex] = useState(0);

    // Slider effect to change the image every few seconds
    useEffect(() => {
        const interval = setInterval(() => {
            setCurrentImageIndex((prevIndex) => (prevIndex + 1) % images.length);
        }, 5000); // Change image every 5 seconds

        return () => clearInterval(interval);
    }, [images.length]);

    const handleToggle = () => {
        setIsUser(!isUser);
        if (isUser) {
            navigate("/admindisplay");
        } else {
            navigate("/dashboard");
        }
    };

    return ( <
        div className = "home-container" >
        <
        header className = "home-header" >
        <
        h1 className = "animate-slide-up" > Welcome to MediShop < /h1> <
        p className = "animate-slide-up" > Your trusted online medicine store < /p> <
        div className = "slider-container" >
        <
        img src = { images[currentImageIndex] }
        alt = "Medicine"
        className = "home-graphic animate-fade-in" /
        >
        <
        /div> < /
        header > <
        div className = "home-buttons" >
        <
        button className = "toggle-btn animate-pulse"
        onClick = { handleToggle } > { isUser ? "Switch to Admin" : "Switch to User" } <
        /button> <
        button className = "primary-btn animate-bounce"
        onClick = {
            () => navigate("/login")
        } >
        Login <
        /button> <
        button className = "primary-btn animate-bounce"
        onClick = {
            () => navigate("/registration")
        } >
        Registration <
        /button> < /
        div > <
        /div>
    );
}