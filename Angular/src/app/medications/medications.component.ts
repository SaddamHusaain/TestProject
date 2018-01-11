import { Component, OnInit, TemplateRef } from '@angular/core';

import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl
} from '@angular/forms';


import { BsModalRef, BsModalService} from 'ngx-bootstrap/modal';

import {ApiService} from './../shared/services/api.service';
import { APIURLS } from './../shared/common/api_urls';
import { debounce } from 'rxjs/operator/debounce';

@Component({
  selector: 'app-medications',
  templateUrl: './medications.component.html',
  styleUrls: ['./medications.component.css'],
  providers: [ApiService]
})
export class MedicationsComponent implements OnInit {
  Medications:any = [{"Name":"Test", "Dosage":"Test", "Frequency":"2", "StartDate":"10/10/2016", "EndDate":"10/10/2016", "Active":"Y"}];
  MedicationForm: FormGroup;
  public modalRef: BsModalRef; // {1}

  constructor (
              private _ApiService:ApiService, 
              private _modalService: BsModalService,
              private _FormBuilder: FormBuilder
            ) { }

  ngOnInit() {
    this.loadData();
  }

  public loadData() {
    this._ApiService.get(APIURLS.GET_ALL_MEDICATION_API).subscribe(
      (data) => {
        this.Medications = data.MedicationList;
    });
  }
  
  public OpenMedicationPopup(template: TemplateRef<any>) {


    this.modalRef = this._modalService.show(template, {class: 'MedicationPopup'}); // {3}

    this.MedicationForm = this._FormBuilder.group({
      'Name': [null, Validators.required],
      'Dosage': [null, Validators.required],
      'Frequency': [null, Validators.required],
      'StartDate': [null, Validators.required],
      'EndDate': [null, Validators.required],
      'Prescriber': [null, Validators.required],
      'RxNumber': [null, Validators.required],
      'Notes': [null],
      'Active': [null]
    });
  }

  isFieldValid(field: string) {
    return !this.MedicationForm.get(field).valid && this.MedicationForm.get(field).touched;
  }

  displayFieldCss(field: string) {
    return {
      'has-error': this.isFieldValid(field),
      'has-feedback': this.isFieldValid(field)
    };
  }

  onSubmit() {
    if (this.MedicationForm.valid) {
      this._ApiService.post(APIURLS.CREATE_MEDICATION_API, this.MedicationForm.value).subscribe(
        (data) => {
          this.Medications = data.MedicationList;
      });
    } else {
      this.validateAllFormFields(this.MedicationForm);
    }
  }

  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      console.log(field);
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }

  reset(){
    this.MedicationForm.reset();
  }
}
