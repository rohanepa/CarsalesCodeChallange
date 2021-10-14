import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PageMessageComponent } from './components/page-message/page-message.component';
import { LoaderComponent } from './components/loader/loader.component';

@NgModule({
    declarations: [
        PageMessageComponent,
        LoaderComponent
    ],
    imports: [
        HttpClientModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        MatTableModule,
        FormsModule,
        CommonModule
    ],
    exports: [
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        MatTableModule,
        PageMessageComponent,
        LoaderComponent
    ],
    entryComponents: [
    ]
})
export class SharedModule {

}
