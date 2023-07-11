import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Layout } from './Layout';
import { Home } from './pages/Home';
import { Counter } from './pages/Counter';
import { NoMatch } from './pages/NoMatch';
import { Forecasts } from './pages/Forecasts';

function App() {
    return (
        <div className="app">
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<Layout />}>
                            <Route index element={<Home />} />
                            <Route path="counter" element={<Counter />} />
                            <Route path="fetchdata" element={<Forecasts />} />
                            <Route path="*" element={<NoMatch />} />
                        </Route>
                    </Routes>
                </BrowserRouter>
        </div>
    );
}

export default App;