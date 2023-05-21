import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { medicineData } from '../data/data';
import { IMedicines } from '../models/medicines';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MedicinesService {

  constructor(private _http : HttpClient) { }

  getMedicinesFromDb() : Observable<IMedicines[]>{
    return this._http.get<IMedicines[]>('http://localhost:3001/medicines')
    // return this._http.get<IMedicines[]>('http://localhost:5292/api/medicine/getmedicinelist')
  }

  getMedicineById(id: number): Observable<IMedicines> {
    return this._http.get<IMedicines>(
      `http://localhost:5292/api/medicine/getmedicinebyid?id=${id}`
    );
  }



  addNewItem(item : any){
    return this._http.post('http://localhost:3001/medicines' , item)
  }

  deleteMedicineById(id: number): Observable<IMedicines> {
    return this._http.delete<IMedicines>(
      `http://localhost:5292/api/medicine/deletemedicinebyid?id=${id}`
    );
  }

  getMedicines(){
    return medicineData;
  }
}

