import React from 'react';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

export default class AdoptModal extends React.Component {
    render() {
        return (
            <Modal isOpen={this.props.showModal} toggle={this.props.toggle} id={this.props.id}>
                <ModalHeader toggle={this.props.toggle}>{this.props.title}</ModalHeader>
                <ModalBody style={{ textAlign: "center" }}>
                    <input type="text" placeholder="zipcode" onChange={this.props.handleChange}
                               value={this.props.zipcode ? this.props.zipcode : ""}/>
                </ModalBody>
                <ModalFooter>
                </ModalFooter>
            </Modal>   
        )
    }
}