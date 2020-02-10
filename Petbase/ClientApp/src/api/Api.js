export default class Api {
    get = (type) => {
        return fetch(`api/${type}`)
            .then(response => response.json())
    }
}