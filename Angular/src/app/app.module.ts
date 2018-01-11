import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';

import { HttpModule } from '@angular/http'
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './shared/modules/app-routing.module';
import { AppBootstrapModule  } from './shared/modules/app-bootstrap.module';

import { AppComponent } from './app.component';

// Common header & footer component
import { HeaderComponent } from './layout/header.component';
import { FooterComponent } from './layout/footer.component';

// Custom components
import { MedicationsComponent } from './medications/medications.component';
import { FieldErrorDisplayComponent } from './shared/components/field-error-display/field-error-display.component';


@NgModule({
    declarations: [
        AppComponent,
        // Header & Footer component
        FooterComponent,
        HeaderComponent,

        // Custom components
        MedicationsComponent,

        FieldErrorDisplayComponent,
    ],
    imports: [
        BrowserModule,
        HttpModule,
        ReactiveFormsModule,
        AppRoutingModule,
        AppBootstrapModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
