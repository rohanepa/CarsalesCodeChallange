import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DataService {

    constructor(private httpClient: HttpClient) {
    }

    get = <T>(url: string): Observable<T> => {
        return this.httpClient.get<T>(environment.api + url);
    }

    post = <T>(url: string, data: any): Observable<T> => {
        return this.httpClient.post<T>(environment.api + url, data);
    }
}
