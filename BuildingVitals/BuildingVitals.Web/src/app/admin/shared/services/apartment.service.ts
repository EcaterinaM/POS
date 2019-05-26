import { BaseService, ServiceHelper } from 'src/app/shared';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AddApartment } from '../models';
import { Observable } from 'rxjs';
import { Apartment } from '../models/_apartment';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService extends BaseService {
  constructor(private baseService: BaseService,
    httpClient: HttpClient,
    serviceHelper: ServiceHelper) {
    super(httpClient, serviceHelper);
    this.baseServiceUrl = environment.serviceUrl + 'v1/apartments';
  }

  save(apartment: AddApartment): Observable<AddApartment> {
    return this.httpClient.post<AddApartment>
      (`${environment.serviceUrl}v1/users/addTenant`, apartment, this.serviceHelper.getHttpHeaders());
  }

  getAllApartments(buildingId): Observable<Apartment[]> {
     return this.httpClient.get<Apartment[]>(`${this.baseServiceUrl}/${buildingId}/building`,  this.serviceHelper.getHttpHeaders())
   }
}
