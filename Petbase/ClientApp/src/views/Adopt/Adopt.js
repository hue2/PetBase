import React from 'react';
import { Card, Row, Col, CardBody } from 'reactstrap';

import PetFinderApi from '../../api/PetFinder';
import "./Adopt.scss";

export default class Adopt extends React.Component {
    constructor(props) {
        super(props);

    }

    state = {
        breed: null,
        zipcode: null,
        distance: 50,
        allBreeds: [],
    }

    api = new PetFinderApi();

    componentDidMount() {
        this.api.getNames().then(result => {
            this.setState({ allBreeds: result });
        });
    }

    render() {
        return (
            <div className="animated fadeIn">
                <Row>
                    <Col>
                        <br/>
                        <div>
                            <h2>Adopt</h2>
                            <hr />
                        </div>
                        <Card>
                            <CardBody>
                                <div>
                                    <input type="radio" id="cats" name="animal" value="cats"/>
                                    <label for="cats" className="type-filter">Cats</label>
                                    <input type="radio" id="dogs" name="animal" value="dogs" />
                                    <label for="dogs" className="type-filter">Dogs</label>
                                    <input type="radio" id="rabbits" name="animal" value="rabbits" />
                                    <label for="rabbits" className="type-filter">Rabbits</label>
                                </div>
                                <div>
                                    <select>
                                        {
                                            this.state.allBreeds.map(x => (
                                                <option value="x">{x}</option>
                                            ))
                                        }                 
                                    </select>
                                </div>             
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </div>
        )
    }
}