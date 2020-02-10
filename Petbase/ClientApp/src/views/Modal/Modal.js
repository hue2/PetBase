import React from 'react';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

export default class Modals extends React.PureComponent {
  render() {
    return (
        <Modal isOpen={this.props.showModal} toggle={this.props.toggle}>
            <ModalHeader toggle={this.props.toggle}>{this.props.title}</ModalHeader>
            <ModalBody style={{ textAlign: "center" }}>
                <img src={this.props.imageUrl} style={{ width: "80%" }}/>
            </ModalBody>
            <ModalFooter>
            </ModalFooter>
        </Modal>             
    );
  }
}