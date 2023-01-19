import { useState } from "react";

const LocationForm = ({ showModal, toggleModal, getWeather }) => {
    const [location, setLocation] = useState('');
    const [isInvalid, setIsInvalid] = useState(false);

    const onChangeWeather = async location => {
        try {
            await getWeather(location);
            toggleModal();
            setIsInvalid(false);
        } catch (e) {
            setIsInvalid(true);
        }
    };

    const onCloseModal = () => {
        setIsInvalid(false);
        toggleModal();
    };

    return (
        <div className={showModal ? "modal-background" : "d-none"}>
            <div className="modal-container">
                <h4 className="mb-4 d-flex align-items-center justify-content-between">Location
                    <button onClick={onCloseModal} className="btn btn-outline-danger">X</button>
                </h4>
                <div className="input-group mb-3">
                    <input
                        id="locationInput"
                        type="text"
                        className={isInvalid ? 'is-invalid form-control' : 'form-control'}
                        placeholder="Enter a location name"
                        aria-label="Locatione"
                        onChange={e => setLocation(e.target.value)}
                        onKeyPress={e => {
                            if (e.key === 'Enter') {
                                onChangeWeather(location);
                            }
                        }} />
                    <div className="input-group-append">
                        <button id="changeLocationBtn" className="btn btn-primary" type="button" onClick={() => onChangeWeather(location)}>Change</button>
                    </div>
                    <div className="invalid-feedback">Invalid location</div>
                </div>
            </div>
        </div>
    );
};

export default LocationForm;