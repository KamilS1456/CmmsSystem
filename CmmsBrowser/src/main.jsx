import React from "react";
import ReactDOM from "react-dom/client";
import Header from './components/Header/header'
import RestaurantListEdit from "./components/restaurantListEdit";
import './styles/styles.css'

const App = () => (

    <div>
        <Header/>
        <RestaurantListEdit/>
    </div>
)

const root = ReactDOM.createRoot(document.getElementById('root'))
root.render(<App/>)