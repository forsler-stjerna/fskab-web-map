import React from 'react';
import { Map, TileLayer, CircleMarker, Popup, Polyline } from 'react-leaflet';
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
            path: {},
            zoom: 0,
        }

        this.getCoordinates(0);
    }

    createPostData(body) {
        return { method: 'POST', mode: 'cors', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) };
    }

    getCoordinates(zoom) {
        if (this.state.markers[zoom]) return;



        fetch('./api/coordinate/coordinates', this.createPostData({ zoom: zoom }))
            .then((response) => response.json())
            .then((data) => {
                var markers = this.state.markers;
                markers[zoom] = data.groups;
                this.setState({ markers });
                return data;
            })
            .then((data) => fetch('./api/path/shortestpath', this.createPostData({ coordinates: data.groups.map(k => k.coordinate) })))
            .then(response => response.json())
            .then(jsonData => {
                var path = this.state.path;
                path[zoom] = jsonData.coordinates;
                this.setState({ path });
            });
    }

    zoomChanged(value) {
        this.setState({ zoom: value });
        this.getCoordinates(value);
    }


    renderMarker(m, i) {
        return (
            <CircleMarker key={i} center={[m.coordinate.latitude, m.coordinate.longitude]} radius={3 + 3 * m.coordinates.length}>
                <Popup>
                    {`there are ${m.coordinates.length} coordinates in this group ${m.coordinates.map((c) => { return c.name })}`}
                </Popup>
            </CircleMarker>
        );
    }

    renderMarkers() {
        return (
            <React.Fragment>
                {(this.state.markers[this.state.zoom] || []).map((m, i) => { return this.renderMarker(m, i) })}
            </React.Fragment>
        );
    }

    renderPolyline() {
        const paths = this.state.path[this.state.zoom];
        if (!paths) return null;

        var positions = paths.map(p => { return [p.latitude, p.longitude] });

        return (
            <Polyline positions={positions} color={'LimeGreen'} />
        );
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
                    {this.renderMarkers()}

                    {this.renderPolyline()}

                </Map>
                <div style={{ padding: 20 }}>
                    <Slider style={{ margin: 10 }} min={0} max={30} value={parseInt(this.state.zoom)} onChange={this.zoomChanged.bind(this)} />
                </div>
            </div>
        );
    }
}