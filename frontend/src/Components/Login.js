import React, { useState } from 'react';

export default function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async e => {
        e.preventDefault();
        const response = await fetch('/api/authentication/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password }),
        });

        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token);
            alert('Login successful!');
            // Redirect to dashboard
            window.location.href = '/Dashboard';
        } else {
            alert('Login failed');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Login</h2>
            <label>Email:</label><br />
            <input type="email" value={email} onChange={e => setEmail(e.target.value)} required /><br />
            <label>Password:</label><br />
            <input type="password" value={password} onChange={e => setPassword(e.target.value)} required /><br />
            <button type="submit">Login</button>
        </form>
    );
}
