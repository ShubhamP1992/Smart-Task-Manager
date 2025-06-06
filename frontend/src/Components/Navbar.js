// src/Components/Navbar.js
import React from 'react';
import { Link, useNavigate } from 'react-router-dom';

const Navbar = () => {
    const navigate = useNavigate();
    const isLoggedIn = !!localStorage.getItem('token');

    const handleLogout = () => {
        localStorage.removeItem('token');
        navigate('/login');
    };

    return (
        <nav style={{ padding: '10px', background: '#f0f0f0' }}>
            <Link to="/" style={{ marginRight: '10px' }}>Home</Link>
            {!isLoggedIn && <Link to="/login" style={{ marginRight: '10px' }}>Login</Link>}
            {!isLoggedIn && <Link to="/register" style={{ marginRight: '10px' }}>Register</Link>}
            {isLoggedIn && <Link to="/dashboard" style={{ marginRight: '10px' }}>Dashboard</Link>}
            {isLoggedIn && <button onClick={handleLogout}>Logout</button>}
        </nav>
    );
};

export default Navbar;
