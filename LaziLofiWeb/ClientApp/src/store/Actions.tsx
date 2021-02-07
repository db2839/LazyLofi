import { Action } from "redux";

export const GET_VIDEOS: string = 'GET_VIDEOS';
export const API_ERROR: string = 'API_ERROR';
export const IS_LOADING: string = 'IS_LOADING';
export const FINISHED_LOADING: string = 'FINISHED_LOADING';
export const VIDEOS_RETRIEVAL_SUCCESS = 'VIDEOS_RETRIEVAL_SUCCESS';

export interface ActionWithPayload extends Action<any> {
    type: string;
    payload: any;
}

export type KnownAction = ActionWithPayload;