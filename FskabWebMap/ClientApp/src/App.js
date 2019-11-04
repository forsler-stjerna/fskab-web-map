import React, { Component } from 'react';
import FskabMap from './components/FskabMap.jsx'

export default class App extends Component {
  displayName = App.name

  render() {
    return (
        <div>
            <div>
        This is our page       
                </div>
            <FskabMap/>    
      </div>
    );
  }
}
