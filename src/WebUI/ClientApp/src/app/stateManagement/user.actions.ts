import { createAction, props } from '@ngrx/store';
import { IUserDto } from '../web-api-client';

export const setUser = createAction('[User] Set User', props<{ user: IUserDto }>());