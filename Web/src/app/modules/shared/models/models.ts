import { enum_message } from './enums';

export class ServerError {
    member = '';
    error: string[] = [];
}

export interface IPageMessage {
    type: enum_message;
    message: string;
  }
