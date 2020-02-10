import Api from './Api';

export default class CatApi {
    type = "cat";
    api = new Api();

    get = () => {
        return this.api.get(this.type);
    }
}