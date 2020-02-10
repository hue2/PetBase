import React from 'react';
import Table from './Table/Table';
import DogApi from '../api/DogApi';
import Columns from './Table/Columns';
import Modal from './Modal/Modal';

export default class Dogs extends React.PureComponent {
    state = {
        data: [],
        showModal: false,
        selectedRow: { name: '', imageUrl: '' },
    }

    handleImageClick = (row) => {
        this.setState({ selectedRow: row });
        this.toggleModal();
    }

    dogApi = new DogApi();
    columns = new Columns().getColumns(this.handleImageClick);

    componentDidMount () {
        this.dogApi.get().then(data => {
            this.setState({ data });
        })
    }

    toggleModal = () => {
        this.setState({
            showModal: !this.state.showModal,
        });
    }

    render() {
        return (
            <div>
                <Table data={this.state.data} columns={this.columns} title={"Dogs"}/>
                <Modal 
                    showModal={this.state.showModal} 
                    title={this.state.selectedRow.name} 
                    toggle={this.toggleModal} 
                    imageUrl={this.state.selectedRow.pictureUrl} 
                />
            </div>
        )
    }
}