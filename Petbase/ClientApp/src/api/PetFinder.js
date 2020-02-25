import Api from './Api';

export default class PetFinderApi {
    type = "petfinder";
    api = new Api();

    get = () => {
        return this.api.get(this.type);
    }
}