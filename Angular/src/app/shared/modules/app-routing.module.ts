import { NgModule }              from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';


// Compontes used in route.
import { MedicationsComponent } from '../../medications/medications.component';

/*
  Created By   : Saddam
  Created Date : 25-11-2017
  Purpose      : Defining route with their components.
*/
const AppRoutes: Routes = [
    { path: 'medications', component: MedicationsComponent },
    { path: '',   redirectTo: '/medications', pathMatch: 'full' }
];


@NgModule({
  imports: [
    RouterModule.forRoot(
      AppRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}
