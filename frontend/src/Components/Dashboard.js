// src/Components/Dashboard.js
import React from 'react';

const Dashboard = () => {
    const handleLogout = () => {
        localStorage.removeItem('token');
        window.location.href = '/login'; // Redirect to login page
    };

    return (
        <div>
            <h2>Welcome to Dashboard</h2>
        </div>
    );
};

export default Dashboard;
