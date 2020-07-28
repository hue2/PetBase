import React from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import { Card, Row, Col, CardBody, Spinner } from 'reactstrap';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';

import './Table.scss';

const { SearchBar } = Search;

export default class Table extends React.PureComponent {
    render() {
        return (
            <div className="animated fadeIn">
                <Row>
                    <Col>
                        <br/>
                        <div>
                            <h2>{this.props.title}</h2>
                            <hr />
                        </div>
                        <Card>
                            <CardBody>
                            {this.props.isLoading ?
                                <div className="text-center">
                                    <Spinner color="secondary" className="m-auto" />
                                </div>
                                :
                                <ToolkitProvider
                                    keyField="id"
                                    data={this.props.data}
                                    columns={this.props.columns}
                                    search
                                >
                                    {
                                        props => (
                                        <div>
                                            <div id="table-wrapper"><SearchBar { ...props.searchProps } style={{ marginBottom: 20 }}/></div>
                                            <BootstrapTable { ...props.baseProps } 
                                                bordered={ false }
                                                hover
                                            />
                                        </div>
                                        )
                                    }
                                    </ToolkitProvider> 
                            }              
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </div>
        )
    }
}