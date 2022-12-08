import React from 'react';
import axios from 'axios';

export default class App extends React.Component {
  state = {
    stationData: [],
    fuelData: [],
    showMessage: false,
    showPrice: false

  }

  onButtonClickHandler = () => {
    this.setState({showMessage: true});
   };
   onReceiptButtonClickHandler = () => {
    this.setState({showMessage2: true});
   };

  componentDidMount() {
    axios.get(`https://localhost:44310/api/PetrolStation`)
      .then(res => {
        const stationData = res.data;
        this.setState({ stationData });
      })

  }

  

  render() {
    return (
      <div className="app">
      <div className="search">
      <text>WORK IN PROGRESS</text>
      <br></br>
        <header>Payment Processing System</header>
        <input
          placeholder='Enter Location'
          type="text" />
      <table>
        <tbody>
          {this.state.stationData.map(station =>
            <tr>
              <td>{station.stationName}</td>
              <th></th>
              <td>Address: {station.address}
              <br></br> Number Of Pumps: {station.numberOfPumps} </td>
              <td> </td>
              <button onClick={this.onButtonClickHandler}>Activate Fuel Pumps</button>
              {this.state.showMessage && <p>ACTIVATED</p>}
            </tr>)}
        </tbody>
      </table>
      <button onClick={this.onReceiptButtonClickHandler}>Print Receipt</button>
              {this.state.showMessage2 && <p>£90 from Station One, Pump no.5, Diesel</p>}
      <br></br>
      <text>WORK IN PROGRESS</text>
      </div>
      </div>
      
    )
  }
}