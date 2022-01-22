import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from 'src/models/app-constants';
import { ResidentsModel } from 'src/models/Residents.model';

@Injectable({
  providedIn: 'root'
})
export class ResidentsService {

  constructor(
    private http: HttpClient
  ) { }


  getAllResidents(): Observable<ResidentsModel[]> {
    const apiAddress = `https://localhost:44393${AppConstants.api.residents}`;
    const residents = this.http.get<ResidentsModel[]>(apiAddress);
    return residents;
  }

  getAllResidentsByName(cityName: string): Observable<ResidentsModel[]> {
    const apiAddress = `https://localhost:44393${AppConstants.api.residentsByName}`;

    const params = new HttpParams()
      .set('cityName', cityName)

    const residentsByName = this.http.get<ResidentsModel[]>(apiAddress, { params });
    return residentsByName;
  }

}

