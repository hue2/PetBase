import React from 'react';
import { Modal, ModalBody, ModalFooter, ModalHeader, Col, Row } from 'reactstrap';

export default class AdoptModal extends React.Component {
    render() {
        return (
            <Modal isOpen={this.props.showModal} toggle={this.props.toggle} id={this.props.id}>
                <ModalHeader toggle={this.props.toggle}>{this.props.title}</ModalHeader>
                <ModalBody style={{ textAlign: "center" }}>
                    <input type="text" placeholder="zipcode" onChange={this.props.onChange}
                               value={this.props.zipcode ? this.props.zipcode : ""}/>
                    {this.props.animals.length > 0 && this.props.animals.map(item => {
                        return (
                            <Row>
                                <Col>
                                    <img src={item.url} />
                                </Col>
                            </Row>
                        )
                    })}
                </ModalBody>
                <ModalFooter>
                    <button onClick={this.props.onSearch}>Search</button>
                </ModalFooter>
            </Modal>   
        )
    }
}