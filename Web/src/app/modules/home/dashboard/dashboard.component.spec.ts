import { HttpErrorResponse } from '@angular/common/http';
import { Type } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { noop, Observable, of, throwError } from 'rxjs';
import { SharedModule } from '../../shared/shared.module';
import { SpeakingLanguage, VehicleType } from '../models/enums';
import { IViewCustomer } from '../models/models';
import { HomeDataService } from '../services/home-data.service';
import { DashboardComponent } from './dashboard.component';

describe('DashboardComponent', () => {

    let fixture: ComponentFixture<DashboardComponent>;
    let dashboardComponent: DashboardComponent;
    beforeEach(async () => {

        await TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                SharedModule,
                ReactiveFormsModule,
                BrowserAnimationsModule
            ],
            declarations: [
                DashboardComponent
            ],
        }).compileComponents();

        fixture = TestBed.createComponent(DashboardComponent);
        dashboardComponent = fixture.componentInstance;
    });

    it('should create the dashboard and call api to get the data', () => {
        const mockHomeDataService = fixture.debugElement.injector.get<HomeDataService>(HomeDataService as Type<HomeDataService>);
        spyOn(mockHomeDataService, 'getCustomers').and.callThrough();
        fixture.detectChanges();
        fixture.whenStable().then(() => {
            expect(mockHomeDataService.getCustomers).toHaveBeenCalledTimes(1);
        });
        expect(dashboardComponent).toBeTruthy();
    });

    it('should init vehicle types to populate in ui', () => {
        expect(dashboardComponent.customerPreferredVehicles).toBeDefined();
        expect(dashboardComponent.customerPreferredVehicles.length).toBe(4);
        expect(dashboardComponent.customerPreferredVehicles.findIndex((v) => v.type === VehicleType.Any) !== -1).toBeTrue();
        expect(dashboardComponent.customerPreferredVehicles.findIndex((v) => v.type === VehicleType.FamilyCar) !== -1).toBeTrue();
        expect(dashboardComponent.customerPreferredVehicles.findIndex((v) => v.type === VehicleType.SportsCar) !== -1).toBeTrue();
        expect(dashboardComponent.customerPreferredVehicles.findIndex((v) => v.type === VehicleType.Tradie) !== -1).toBeTrue();
    });

    it('should init languages to populate in ui', () => {
        expect(dashboardComponent.customerSpeakingLanguages).toBeDefined();
        expect(dashboardComponent.customerSpeakingLanguages.length).toBe(3);
        expect(dashboardComponent.customerSpeakingLanguages.findIndex((v) => v.type === SpeakingLanguage.Any) !== -1).toBeTrue();
        expect(dashboardComponent.customerSpeakingLanguages.findIndex((v) => v.type === SpeakingLanguage.Greek) !== -1).toBeTrue();
        expect(dashboardComponent.customerSpeakingLanguages.findIndex((v) => v.type === SpeakingLanguage.NonGreek) !== -1).toBeTrue();
    });

    it('should init display columns to be init', () => {

        const columnNames = ['customerName', 'vehicleType', 'speakingLanguage', 'salesPersonName'];

        expect(dashboardComponent.displayedColumns).toBeDefined();
        expect(dashboardComponent.displayedColumns.length).toBe(columnNames.length);
        for (const item of dashboardComponent.displayedColumns) {
            expect(columnNames).toContain(item);
        }
    });

    it('should show customer name', () => {
        const columnNames = ['Customer Name', 'Vehicle Type', 'Speaking Language', 'Sales Person Name'];
        fixture.detectChanges();
        const compiled = fixture.nativeElement;
        const headerCollection = compiled.getElementsByClassName('mat-header-cell');

        expect(headerCollection.length).toBe(columnNames.length);
        for (const index in columnNames) {
            if (columnNames[index]) {
                expect(compiled.getElementsByClassName('mat-header-cell')[index].textContent).toContain(columnNames[index]);
            }
        }
    });

    it('should call api to post customer on save and simulate success', () => {
        const mockHomeDataService = fixture.debugElement.injector.get<HomeDataService>(HomeDataService as Type<HomeDataService>);

        const mockData = of<IViewCustomer[]>([
            {
                id: 'Abc', vehicleTypeDescription: '',
                name: '',
                vehicleType: VehicleType.Any,
                speakingLanguageDescription: '',
                speakingLanguage: SpeakingLanguage.Any,
                salesPersonName: ''
            }
        ]);
        spyOn(mockHomeDataService, 'saveCustomer').and.returnValue(mockData);

        dashboardComponent.customerForm.patchValue({
            name: 'abc user',
            speakingLanguage: SpeakingLanguage.Any,
            vehicleType: VehicleType.Any
        });

        dashboardComponent.saveCustomer();

        fixture.detectChanges();

        expect(mockHomeDataService.saveCustomer).toHaveBeenCalledTimes(1);

        mockHomeDataService.saveCustomer(dashboardComponent.customerForm.value).subscribe(() => {
            expect(dashboardComponent.customers.length).toBe(1);
        });
    });

    it('should call api to post customer on save and simulate error', () => {
        const mockHomeDataService = fixture.debugElement.injector.get<HomeDataService>(HomeDataService as Type<HomeDataService>);
        const errorMessage = 'test message';

        const mockData = throwError({ status: 400, statusText: 'Bad Request', error: { Unspecified: [errorMessage] } });

        spyOn(mockHomeDataService, 'saveCustomer').and.returnValue(mockData);

        dashboardComponent.customerForm.patchValue({
            name: 'abc user',
            speakingLanguage: SpeakingLanguage.Any,
            vehicleType: VehicleType.Any
        });

        dashboardComponent.saveCustomer();

        fixture.detectChanges();

        expect(mockHomeDataService.saveCustomer).toHaveBeenCalledTimes(1);

        mockHomeDataService.saveCustomer(dashboardComponent.customerForm.value).subscribe(
            noop,
            () => {
                expect(dashboardComponent.pageMessage.message).toBe(errorMessage);
            });
    });
});
