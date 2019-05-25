import { BaseService, ServiceHelper } from 'src/app/shared';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Building } from '../models/_building';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BuildingService extends BaseService {
  constructor(private baseService: BaseService,
    httpClient: HttpClient,
    serviceHelper: ServiceHelper) {
    super(httpClient, serviceHelper);
    this.baseServiceUrl = environment.serviceUrl + 'v1/buildings';
  }

  save(building: Building): Observable<Building> {
    return this.httpClient.post<Building>
      (`${this.baseServiceUrl}`, building, this.serviceHelper.getHttpHeaders());
  }
  getAllBuildings(ownerId: string): Observable<Building[]> {
    return this.httpClient.get<Building[]>(`${this.baseServiceUrl}/${ownerId}`, this.serviceHelper.getHttpHeaders());
  }
}
