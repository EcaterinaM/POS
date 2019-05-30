import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';

import { ServiceHelper } from '../../helpers';

import { BaseService } from '../base.service';

import { Property } from '../../models/property.model';


@Injectable()
export class MetricService extends BaseService {

  constructor(private baseService: BaseService,
    httpClient: HttpClient,
    serviceHelper: ServiceHelper) {
    super(httpClient, serviceHelper);
    this.baseServiceUrl = environment.serviceUrl + 'v1/metrics';
  }

  getPropertyMaxMin(property: string, sensorId: string): Observable<Property> {
    return this.httpClient.get<Property>(`${this.baseServiceUrl}/property/${property}/${sensorId}`, this.serviceHelper.getHttpHeaders());
  }

}
