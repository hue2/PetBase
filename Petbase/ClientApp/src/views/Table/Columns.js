import React from 'react';

export default class Columns {
    getColumns = (func) => [
    {
        dataField: 'id',
        hidden: true,
        text: 'id',
    },
    {
        dataField: 'name',
        text: 'Name',
        headerStyle: () => {
            return { width: "15%" };
        }
    },
    {
        dataField: 'lifeSpan',
        text: 'Life Span',
        headerStyle: () => {
            return { width: "15%" };
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
    {
        dataField: 'pictureUrl',
        text: 'Picture',
        formatter: (cell, row) => {
            return (
                <div className="img-container" onClick={() => func(row)}>
                    <img src={cell} className="image"></img>
                    <div className="overlay">
                        <div className="overlay-text">Click to enlarge</div>
                    </div>
                </div>
            )
        }
    }
]
}