import React from 'react';
import Table from './Table/Table';
import RabbitApi from '../api/RabbitApi';
import Modal from './Modal/Modal';
import Columns from './Table/Columns';

export default class Rabbits extends React.PureComponent {
    state = {
        data: [],
        showModal: false,
        selectedRow: { name: '', imageUrl: '' },
    }

    handleImageClick = (row) => {
        this.setState({ selectedRow: row });
        this.toggleModal();
    }

    rabbitApi = new RabbitApi();
    columns = new Columns().getColumns(this.handleImageClick);

    componentDidMount () {
        this.rabbitApi.get().then(data => {
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
                <Table data={this.state.data} columns={this.columns} title={"Rabbits"}/>
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