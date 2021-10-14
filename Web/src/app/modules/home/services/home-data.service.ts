import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from '../../shared/services/data.service';
import { ICustomer, IViewCustomer } from '../models/models';

@Injectable({
    providedIn: 'root'
})
export class HomeDataService {

    constructor(
        private dataService: DataService) {
    }
}
