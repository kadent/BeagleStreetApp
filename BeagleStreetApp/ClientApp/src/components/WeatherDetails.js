const WeatherDetails = ({ weatherData }) => {

    const timestampToTime = timestamp => {
        const date = new Date(timestamp * 1000);
        const hours = new String(date.getHours()).padStart(2, '0');
        const minutes = new String(date.getMinutes()).padStart(2, '0');

        return `${hours}:${minutes}`;
    };

    return (
        <>
            {weatherData &&
                <>
                <div className="details-grid">
                    <p>Sunrise: {timestampToTime(weatherData.sunDetails.sunrise)}</p>
                    <p>Pressure: {weatherData.weatherDetails.pressure} hPa</p>
                    <p>Sunset: {timestampToTime(weatherData.sunDetails.sunset)}</p>
                    <p>Humidity: {weatherData.weatherDetails.humidity}%</p>
                </div>
                </>
            }
        </>
    );
};

export default WeatherDetails;