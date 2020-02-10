import Api from './Api';

export default class DogApi {
    type = "dog";
    api = new Api();

    get = () => {
        return this.api.get(this.type);
    }
}