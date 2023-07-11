import React, { useState } from 'react';

export const Counter: React.FC = () => {

    const [currentCount, setCurrentCount] = useState(0);

    function incrementCount() {
        setCurrentCount(currentCount + 1);
    }

    return (
        <>
            <h1>Counter</h1>
            <p role="status">Current count: {currentCount}</p>
            <button className="btn btn-primary" onClick={incrementCount}>Click me</button>
        </>
    );
};