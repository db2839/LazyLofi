import React, { Component } from 'react';
import { connect } from 'react-redux';
import Loader from "react-loader-spinner";
import "react-loader-spinner/dist/loader/css/react-spinner-loader.css"

export class VideoLoader extends Component<any, any>{

    componentDidUpdate = () => {
        const { isLoading } = this.props;

        if (isLoading) {
            (window as any).loader.show();
        } else {
            (window as any).loader.hide();
        }
    }

    renderLoader = () => {
        const { isLoading } = this.props;
        return (
            <div style={{ display: isLoading ? 'block' : 'none' }}>
                <Loader type="ThreeDots" color="#00BFFF" height={80} width={80} />
            </div>
        );
    }

    render() {
        return (
            this.renderLoader()
        )
    }

}

const mapStateToProps = (state: any) => ({
    isLoading: state.ui.isLoading
});

export default connect(mapStateToProps)(Loader);
