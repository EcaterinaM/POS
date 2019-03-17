import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

import { ServiceHelper } from '../helpers';

@Injectable()
export class BaseService {

  baseServiceUrl: string;
  baseRoute: string;

  constructor(private httpClient: HttpClient,
    private serviceHelper: ServiceHelper) {
    this.baseServiceUrl = environment.serviceUrl;
  }

  post<T>(route: string, entity: T): Observable<T> {
    return this.httpClient.post<T>(`${this.baseServiceUrl}${route}`, entity, this.serviceHelper.getHttpHeaders());
  }

  get<T>(route: string): Observable<T> {
    return this.httpClient.get<T>(`${this.baseServiceUrl}${route}`, this.serviceHelper.getHttpHeaders());
  }

  update<T>(route: string, entity: T): Observable<T> {
    return this.httpClient.put<T>(`${this.baseServiceUrl}${route}`, entity, this.serviceHelper.getHttpHeaders());
  }
}
