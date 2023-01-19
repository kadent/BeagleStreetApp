import { useEffect, useState } from 'react';
import Heading from './components/Heading';
import WeatherDetails from './components/WeatherDetails';
import LocationForm from './components/LocationForm';
import Layout from './components/Layout';
import './custom.css';

const App = () => {
    const [weatherData, setWeatherData] = useState(null);
    const [showModal, setShowModal] = useState(false);

    const getWeather = async (location) => {
        let res = await fetch(`api/v1/weather/${location}`);

        if (res.status !== 200) {
            throw `Received response code ${res.status}`;
        }

        let resJson = await res.json();
        setWeatherData(resJson);
    };

    const toggleModal = () => {
        setShowModal(prev => !prev);
    };

    useEffect(() => {
        getWeather('London');
    }, []);

    return (
        <Layout title="Weather App">
            <Heading
                location={weatherData?.location}
                temperature={weatherData?.weatherDetails.currentTemp}
                high={weatherData?.weatherDetails.maximumTemp}
                low={weatherData?.weatherDetails.minimumTemp}
                displayDetails={weatherData?.displayDetails}
                toggleModal={toggleModal} />
            <WeatherDetails weatherData={weatherData} />
            <LocationForm showModal={showModal} toggleModal={toggleModal} getWeather={getWeather} />
            <button id="locationBtn" className="btn btn-primary mt-5" onClick={toggleModal}>Change location</button>
        </Layout>
    );
};

export default App;