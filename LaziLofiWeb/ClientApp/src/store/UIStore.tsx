import { Action, Reducer } from 'redux';
import { FINISHED_LOADING, IS_LOADING } from './Actions';

const unloadedState: any = {
    isLoading: false,
} as any;

export const reducer:
    Reducer<any> = (
        state: any | undefined,
        action: Action,
    ): any => {
        if (state === undefined) {
            return unloadedState;
        }
        switch (action.type) {
            case IS_LOADING:
                return {
                    ...state,
                    isLoading: true,
                };
            case FINISHED_LOADING:
                return {
                    ...state,
                    isLoading: false,
                }
            default:
                return state;
        }
    };
