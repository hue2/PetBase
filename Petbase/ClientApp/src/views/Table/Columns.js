import React from 'react';

export default class Columns {
    getColumns = (func, adoptFunc) => [
    {
        dataField: 'id',
        hidden: true,
        text: 'id',
    },
    {
        dataField: 'pictureUrl',
        text: '',
        headerStyle: () => {
            return { width: "13%" };
        },
        formatter: (cell, row) => {
            return (
                <div className="img-container" onClick={(event) => func(event, row)}>
                    <img src={cell} className="image"></img>           
                </div>
            )
        }
    },
    {
        dataField: 'name',
        text: 'Name',
        headerStyle: () => {
            return { width: "13%" };
        }
    },
    {
        dataField: 'lifeSpan',
        text: 'Life Span',
        headerStyle: () => {
            return { width: "10%" };
        }
    },
    {
        dataField: 'size',
        text: 'Size',
        headerStyle: () => {
            return { width: "15%" };
        }
    },
    {
        dataField: 'coat',
        text: 'Coat',
        headerStyle: () => {
            return { width: "15%" };
        }
    },
    {
        dataField: 'uniqueTraits',
        text: 'Unique Traits',
        headerStyle: () => {
            return { width: "25%" };
        }
    },
]
}