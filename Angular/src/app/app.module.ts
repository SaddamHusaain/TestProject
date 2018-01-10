import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';

import { HttpModule } from '@angular/http'
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './shared/modules/app-routing.module';
import { AppBootstrapModule  } from './shared/modules/app-bootstrap.module';

import { AppComponent } from './app.component';

// Common header & footer component
import { HeaderComponent } from './layout/header.component';
import { FooterComponent } from './layout/footer.component';

// Custom components
import { MedicationsComponent } from './medications/medications.component';


@NgModule({
    declarations: [
        AppComponent,
        // Header & Footer component
        FooterComponent,
        HeaderComponent,

        // Custom components
        MedicationsComponent,
    ],
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        AppRoutingModule,
        AppBootstrapModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
