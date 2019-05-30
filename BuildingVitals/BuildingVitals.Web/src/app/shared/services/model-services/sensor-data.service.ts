
import { ServiceHelper } from '../../helpers';
import { BaseService } from '../base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SensorDataList } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class SensorDataService extends BaseService {
  constructor(private baseService: BaseService,
    httpClient: HttpClient,
    serviceHelper: ServiceHelper) {
    super(httpClient, serviceHelper);
    this.baseServiceUrl = environment.serviceUrl + 'v1/metrics';
  }

  getSensorData(propertyName: string, sensorId: string): Observable<SensorDataList> {
    return this.httpClient.get<SensorDataList>(`${this.baseServiceUrl}/${propertyName}/${sensorId}`,  this.serviceHelper.getHttpHeaders())
  }
}
