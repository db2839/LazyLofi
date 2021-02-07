import React, { ReactElement } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faGithub, faLinkedin, faInstagram } from '@fortawesome/free-brands-svg-icons';
import '../css/FooterLinks.css';

export default (): ReactElement => (
    <div className="footer fixed-bottom" >
        <ul className="social-network social-circle">
            <li>
                <a className="icoLinkedin" href="https://www.linkedin.com/in/darius-bell-263b00a3" title="Linkedin">
                    <i className="fa fa-linkedin"><FontAwesomeIcon icon={faLinkedin} /></i>
                </a>
            </li>
            <li>
                <a className="icoGithub" href="https://github.com/db2839" title="Github">
                    <i className="fa fa-linkedin"><FontAwesomeIcon icon={faGithub} /></i>
                </a>
            </li>
            <li>
                <a className="icoFacebook" href="https://www.facebook.com/darius4567" title="Facebook">
                    <i className="fa fa-linkedin"><FontAwesomeIcon icon={faFacebook} /></i>
                </a>
            </li>
            <li>
                <a className="icoInstagram" href="https://www.instagram.com/coolwonder.db/" title="Instagram">
                    <i className="fa fa-linkedin"><FontAwesomeIcon icon={faInstagram} /></i>
                </a>
            </li>
        </ul>
    </div>
);