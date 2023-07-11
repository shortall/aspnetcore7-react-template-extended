import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { ApolloClient, ApolloProvider, InMemoryCache } from "@apollo/client";
import { Layout } from './Layout';
import { Home } from './pages/Home';
import { Counter } from './pages/Counter';
import { NoMatch } from './pages/NoMatch';
import { Forecasts } from './pages/Forecasts';

// TODO - Figure out how to get Apollo client to work through the Webpack dev server proxy
const client = new ApolloClient({
    cache: new InMemoryCache({
        typePolicies: {
        },
    }),
    uri: "https://localhost:7232/graphql",
    //uri: "/api/graphql/",
});

function App() {
    return (
        <div className="app">
            <ApolloProvider client={client}>
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
            </ApolloProvider>
        </div>
    );
}

export default App;