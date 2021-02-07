import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';
import LazyLofiApi from '../api/LazyLofiApi';
import { ActionWithPayload, API_ERROR, FINISHED_LOADING, IS_LOADING, VIDEOS_RETRIEVAL_SUCCESS, KnownAction } from './Actions';

export interface VideosState {
    vidoes: any;
    show: boolean;
    found: boolean;
    loading: boolean
}

export const actionCreators = {
    getVideos: (): AppThunkAction<ActionWithPayload> => (dispatch: any) => {
        dispatch({
            type: IS_LOADING,
        });
        LazyLofiApi.getVideos()
            .then(result => {
                dispatch({ type: VIDEOS_RETRIEVAL_SUCCESS, payload: result, });
                dispatch({ type: FINISHED_LOADING });
            })
            .catch(err => {
                dispatch({
                    type: API_ERROR,
                    payload: err,
                })
                dispatch({
                    type: FINISHED_LOADING
                });
            });
    },
};

const unloadedState: any = {
    videos: null,
    isLoading: false,
    err: {}
} as any;

export const reducer:
    Reducer<any> = (
        state: any | undefined,
        incomingAction: Action,
    ): any => {
        if (state === undefined) {
            return unloadedState;
        }

        const action = incomingAction as KnownAction;
        switch (action.type) {
            case VIDEOS_RETRIEVAL_SUCCESS:
                return {
                    ...state,
                    videocontainer: action.payload.videos,
                    isLoading: false,
                };
            case API_ERROR:
                return {
                    ...state,
                    err: action.payload,
                    isLoading: false
                };
            default:
                return state;
        }
    };
