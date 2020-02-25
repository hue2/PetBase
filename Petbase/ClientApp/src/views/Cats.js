import React from 'react';
import Table from './Table/Table';
import CatApi from '../api/CatApi';
import Modal from './Modal/Modal';
import Columns from './Table/Columns';

export default class Cats extends React.PureComponent {
    state = {
        data: [],
        pictureModal: false,
        adoptModal: false,
        selectedRow: { name: '', imageUrl: '' },
    }

    handleImageClick = (row) => {
        this.setState({ selectedRow: row });
        this.toggleModal();
    }

    handleAdoptClick = (row) => {
        
    }

    catApi = new CatApi();
    columns = new Columns().getColumns(this.handleImageClick);

    componentDidMount () {
        this.catApi.get().then(data => {
            this.setState({ data });
        })
    }

    toggleModal = (event) => {
        this.setState({
            [event.target.id]: !this.state[event.target.id],
        });
    }

    render() {
        return (
            <div>
                <Table data={this.state.data} columns={this.columns} title="Cats" />
                <Modal 
                    showModal={this.state.pictureModal} 
                    title={this.state.selectedRow.name} 
                    toggle={this.toggleModal} 
                    imageUrl={this.state.selectedRow.pictureUrl} 
                    id="pictureModal"
                />
                <Modal
                    showModal={this.state.adoptModal} 
                    title={this.state.selectedRow.name} 
                    toggle={this.toggleModal} 
                    imageUrl={this.state.selectedRow.pictureUrl} 
                    id="adoptModal"
                />
            </div>
        )
    }
}