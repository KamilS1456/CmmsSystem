import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import 'antd'
import './App.css'
import App from './App'
import { Provider } from 'react-redux'
import { store } from './store'


createRoot(document.getElementById('root')!).render(
    <Provider store={store}>
        <StrictMode>        
            <App />
        </StrictMode>,
    </Provider>
)
