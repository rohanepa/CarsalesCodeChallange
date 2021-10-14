import { SpeakingLanguage, VehicleType } from './enums';

export interface ICustomer {
    name: string;
    vehicleType: VehicleType;
    speakingLanguage: SpeakingLanguage;
}

export interface IViewCustomer extends ICustomer {
    id: string;
    vehicleTypeDescription: string;
    speakingLanguageDescription: string;
    salesPersonName: string;
}

export interface ICustomerPreferredVehicle{
    type: VehicleType;
    description: string;
}

export interface ICustomerSpeakingLanguage {
    type: SpeakingLanguage;
    description: string;
}
