import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import FooterLinks from './FooterLinks';

export default (props: { children?: React.ReactNode }) => (
    <React.Fragment>
        <NavMenu/>
        <main id="wrapper" role="main" className="mainContainer" >
            <div>
                {props.children}
            </div>
        </main>
        <FooterLinks/>
    </React.Fragment>
);
