import React from 'react';
import Table from './Table/Table';
import CatApi from '../api/CatApi';
import Modal from './Modal/Modal';
import Columns from './Table/Columns';
import PetFinderApi from '../api/PetFinder';

export default class Cats extends React.PureComponent {
    state = {
        data: [],
        pictureModal: false,
        adoptModal: false,
        isLoading: false,
        selectedRow: { name: '', imageUrl: '' },
        zipcode: null,
        animals: []
    }

    handleImageClick = (event, row) => {
        this.setState({ selectedRow: row });
        this.toggleModal(event);
    }

    handleAdoptClick = (event, row) => {
        this.setState({ selectedRow: row });
        this.toggleModal(event);
    }

    catApi = new CatApi();
    columns = new Columns().getColumns(this.handleImageClick, this.handleAdoptClick);
    petFinderApi = new PetFinderApi();

    componentDidMount () {
        this.setState({ isLoading: true });
        this.catApi.get().then(data => {
            this.setState({ data, isLoading: false });
        })
    }

    toggleModal = (event) => {
        this.setState({
            [event.target.id]: !this.state[event.target.id],
        });
    }

    handleChange = (event) => {
        this.setState({ zipcode: event.target.value })
    }

    handleSearch = () => {
        this.petFinderApi.get(this.state.selectedRow.name, this.state.zipcode).then(result => {
            this.setState({ animals: result.animals })
        });
    }

    render() {
        return (
            <div>
                <Table 
                    data={this.state.data} 
                    columns={this.columns} 
                    title="Cats" 
                    isLoading={this.state.isLoading}
                />             
            </div>
        )
    }
}