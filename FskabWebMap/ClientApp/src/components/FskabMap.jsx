import React from 'react';
import { Map, TileLayer, Marker, Popup } from 'react-leaflet'

const DEFAULT_VIEWPORT = {
    center: [55.610507, 13.009180],
    zoom: 13,
}

export default class FskabMap extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            viewport: DEFAULT_VIEWPORT,
            markers: []
        }

        this.getCoordinates();
    }

    getCoordinates() {
        var data = {
            method: 'POST', mode: 'cors', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify({ zoom: 0 })
        }

        fetch('./api/coordinate/coordinates', data).then((response) => {
            console.log(response);
            if (response.status !== 200) return;

            response.json().then((data) => {
                this.setState({ markers: data });
            });
        })
    }

    render() {
        return (
            <Map style={{ width: '100%', height: 600 }}
                viewport={this.state.viewport}
            >
                <TileLayer
                    attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                {this.state.markers.map(m => {
                    return (
                        <Marker position={[m.coordinate.latitude, m.coordinate.longitude]}>
                            <Popup>
                                {`there are ${m.coordinates.length} coordinates in this group`}
                            </Popup>
                        </Marker>
                    );
                })}
            </Map>
        );
    }
}