import React from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import { Card, Row, Col, CardBody } from 'reactstrap';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';
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
                            <ToolkitProvider
                                keyField="id"
                                data={this.props.data}
                                columns={this.props.columns}
                                search
                            >
                                {
                                    props => (
                                    <div>
                                        <SearchBar { ...props.searchProps } style={{ marginBottom: 20 }}/>
                                        <BootstrapTable { ...props.baseProps } 
                                            bordered={ false }
                                            striped
                                            hover
                                        />
                                    </div>
                                    )
                                }
                                </ToolkitProvider>               
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </div>
        )
    }
}