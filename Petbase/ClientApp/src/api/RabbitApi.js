import Api from './Api';

export default class RabbitApi {
    type = "rabbit";
    api = new Api();

    get = () => {
        return this.api.get(this.type);
    }
}