import React from 'react';
import { Map, TileLayer, CircleMarker, Popup } from 'react-leaflet';
import Slider from 'rc-slider';
import 'rc-slider/assets/index.css';

const DEFAULT_VIEWPORT = {
    center: [55.610507, 13.009180],
    zoom: 13,
}

export default class FskabMap extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            viewport: DEFAULT_VIEWPORT,
            markers: {},
            zoom: 0,
        }

        this.getCoordinates(0);
    }

    getCoordinates(zoom) {
        if (this.state.markers[zoom]) return;

        var data = {
            method: 'POST', mode: 'cors', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify({ zoom: zoom })
        }

        fetch('./api/coordinate/coordinates', data)
            .then((response) => response.json())
            .then((data) => {
                var markers = this.state.markers;
                markers[zoom] = data;
                this.setState({ markers });
            });
    }

    zoomChanged(value) {
        this.setState({zoom: value});
        this.getCoordinates(value);
    }

    render() {
        return (
            <div>
                <Map style={{ width: '100%', height: 600 }}
                    viewport={this.state.viewport}
                >
                    <TileLayer
                        attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                    />
                    {(this.state.markers[this.state.zoom] || []).map((m,i) => {
                        return (
                            <CircleMarker key={i} center={[m.coordinate.latitude, m.coordinate.longitude]} radius={3 + 3 * m.coordinates.length}>
                                <Popup>
                                    {`there are ${m.coordinates.length} coordinates in this group ${m.coordinates.map((c) => { return c.name })}`}
                                </Popup>
                            </CircleMarker>
                        );
                    })}
                </Map>
                <div style={{padding: 20}}>
                    <Slider style={{margin: 10}} min={0} max={30} value={parseInt(this.state.zoom)} onChange={this.zoomChanged.bind(this)}/>
                </div>
            </div>
        );
    }
}