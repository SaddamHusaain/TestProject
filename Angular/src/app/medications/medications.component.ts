import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm} from '@angular/forms';

import { BsModalRef, BsModalService} from 'ngx-bootstrap/modal';

import {ApiService} from './../shared/services/api.service';
import { APIURLS } from './../shared/common/api_urls';

@Component({
  selector: 'app-medications',
  templateUrl: './medications.component.html',
  styleUrls: ['./medications.component.css'],
  providers: [ApiService]
})
export class MedicationsComponent implements OnInit {
  public modalRef: BsModalRef; // {1}

  constructor(private _ApiService:ApiService, private _modalService: BsModalService) { }

  ngOnInit() {
    this.loadData();
  }

  Medications:any = [];

  public loadData() {
    this._ApiService.get(APIURLS.GET_ALL_MEDICATION_API).subscribe(
      (data) => {
        debugger;
        this.Medications = data.MedicationList;
    });
  }

  public AddMedicationsPopup(template: TemplateRef<any>) {
    this.modalRef = this._modalService.show(template, {class: 'MedicationPopup'}); // {3}
  }

  public onSubmit = function (form) {
    console.log(form.value);
    this._ApiService.post(APIURLS.GET_ALL_MEDICATION_API, form.value).subscribe (
      (data) => {
        
    });
  }
}
