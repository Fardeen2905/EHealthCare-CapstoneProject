import { Component } from '@angular/core';
import { MedicinesService } from '../services/medicines.service';
import { IMedicines } from '../models/medicines';
@Component({
  selector: 'app-medicine-list',
  templateUrl: './medicine-list.component.html',
  styleUrls: ['./medicine-list.component.css']
})
export class MedicineListComponent {

 medicines : IMedicines[] = [];

  constructor(private _medicineService: MedicinesService) {}

  ngOnInit() {
    this._medicineService.getMedicinesFromDb().subscribe((result) => {
      this.medicines = result;
    });
  }

  title: string = 'Medicines Available';
}
