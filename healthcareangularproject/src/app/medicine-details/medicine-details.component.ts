import { Component } from '@angular/core';
import { MedicinesService } from '../services/medicines.service';
import { IMedicines } from '../models/medicines';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-medicine-details',
  templateUrl: './medicine-details.component.html',
  styleUrls: ['./medicine-details.component.css']
})
export class MedicineDetailsComponent {
  id: any;
  errorMessage: string = '';
  medicineitem: any = [];
  constructor(
    private _medicineService: MedicinesService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {}
  ngOnInit() {
    this.id = this._route.snapshot.params[`id`];
    this._medicineService.getMedicineById(this.id).subscribe(
      (result) => {
        this.medicineitem = result;
        //console.log(result);
        console.log(this.medicineitem[0].medicine_name);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  deleteMed(): void {
    this._medicineService.deleteMedicineById(this.id).subscribe(
      () => {
        this.errorMessage = '';
        alert('Medicine deleted');
        this._router.navigate(['/medicine-list']);
      },
      (error: any) => {
        this.errorMessage = 'there is a error while deleting';

        console.log(error);
      }
    );
  }
}