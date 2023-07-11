import React, { useState, useEffect, useRef } from 'react';

export const Forecasts: React.FC = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [isError, setIsError] = useState(false);
    const [forecasts, setForecasts] = useState(Array<any>);
    const shouldFetch = useRef(true);

    useEffect(() => {
        async function fetchForecasts() {
            const response = await fetch('weatherforecast');
            const data = await response.json();
            setForecasts(data);
            setIsLoading(false);
                    }

        if (shouldFetch.current) {
            shouldFetch.current = false;
            fetchForecasts().catch((error) => {
                setIsError(true);
            });
        }
    }, []);

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (isError || !forecasts) {
        return <div>ERROR - Are you running the back end?</div>;
    }

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};