import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
    <div className="container-fluid mainContainer" style={{ backgroundColor: "#fe9b70" }}>
        <h1>Content Container</h1>
    </div>
);

export default connect()(Home);
