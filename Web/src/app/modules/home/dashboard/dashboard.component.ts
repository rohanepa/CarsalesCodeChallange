import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { enum_message } from '../../shared/models/enums';
import { IPageMessage } from '../../shared/models/models';
import { SpeakingLanguage, VehicleType } from '../models/enums';
import { ICustomerPreferredVehicle, ICustomerSpeakingLanguage, IViewCustomer } from '../models/models';
import { HomeDataService } from '../services/home-data.service';
@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.less'],
})
export class DashboardComponent implements OnDestroy {

    customerForm: FormGroup;
    ngSubscribe = new Subject();
    pageMessage!: IPageMessage;
    displayedColumns = ['customerName', 'vehicleType', 'speakingLanguage', 'salesPersonName'];
    customers: IViewCustomer[] = [];
    errorMessage = '';
    isBusy = false;
    lookingFor: ICustomerPreferredVehicle = { type: VehicleType.Any, description: 'Any' };

    customerPreferredVehicles: ICustomerPreferredVehicle[] = [
        { type: VehicleType.Any, description: 'Any' },
        { type: VehicleType.FamilyCar, description: 'Family Car' },
        { type: VehicleType.SportsCar, description: 'Sports Car' },
        { type: VehicleType.Tradie, description: 'Tradie' }
    ];

    customerSpeakingLanguages: ICustomerSpeakingLanguage[] = [
        { type: SpeakingLanguage.Any, description: 'Any' },
        { type: SpeakingLanguage.Greek, description: 'Greek' },
        { type: SpeakingLanguage.NonGreek, description: 'Non Greek' },
    ];

    constructor(
        private homeDataService: HomeDataService,
        private fb: FormBuilder) {

        this.customerForm = this.fb.group({
            name: ['', Validators.required],
            speakingLanguage: ['', Validators.required],
            vehicleType: ['', Validators.required],
        });

    }
    ngOnDestroy(): void {
        this.ngSubscribe.next();
        this.ngSubscribe.complete();
    }

    public saveCustomer(): void {
        if (this.customerForm.invalid) {
            return;
        }

        this.isBusy = true;
    }
}
