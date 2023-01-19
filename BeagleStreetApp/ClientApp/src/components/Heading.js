import { upperCaseFirst } from '../utils';

const Heading = ({ location, temperature, high, low, displayDetails }) => {
    return (
        <>
            {displayDetails &&
                <>
                    {location &&
                        <h2 id="location">{location}</h2>
                    }
                    {temperature &&
                        <h5>{temperature}&deg;C</h5>
                    }
                    {high && low &&
                        <p className="mb-0">High: {high}&deg;C Low: {low}&deg;C</p>
                    }
                    <img src={`https://openweathermap.org/img/wn/${displayDetails[0].icon}@4x.png`} title={displayDetails[0].title}></img>
                    <h3>{displayDetails[0].name}</h3>
                    <p className="mb-5">{displayDetails.map(x => upperCaseFirst(x.description)).join(', ')}</p>
                </>
            }
        </>
    );
};

export default Heading;