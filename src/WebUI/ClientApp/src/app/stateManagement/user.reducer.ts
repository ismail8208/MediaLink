import { createReducer, on } from '@ngrx/store';
import { setUser } from './user.actions';
import { IUserDto } from '../web-api-client';

export interface UserState {
  user: IUserDto | undefined;
}

export const initialState: UserState = {
  user: undefined
};

export const userReducer = createReducer(
  initialState,
  on(setUser, (state, { user }) => ({ ...state, user }))
);
