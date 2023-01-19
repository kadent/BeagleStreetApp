/**
 * Capitalises the first letter of a string
 * @param {string} string
 */
const upperCaseFirst = string => {
    return string.charAt(0).toUpperCase() + string.slice(1);
};

export {
    upperCaseFirst
};