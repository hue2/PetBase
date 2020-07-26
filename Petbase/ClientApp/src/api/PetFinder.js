import Api from './Api';

export default class PetFinderApi {
    type = "petfinder";
    api = new Api();

    get = (breed, zipCode) => {
        return this.api.get(`${this.type}?breed=${breed}&zipCode=${zipCode}`);
    }
}