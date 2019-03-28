import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';

import { ServiceHelper } from '../../helpers';
import { RegisterModel } from '../../models';

import { BaseService } from '../base.service';


@Injectable()
export class RegisterService extends BaseService {

  constructor(private baseService: BaseService,
    httpClient: HttpClient,
    serviceHelper: ServiceHelper) {
    super(httpClient, serviceHelper);
    this.baseServiceUrl = environment.serviceUrl + 'v1/users/register';
  }

  register(registerModel: RegisterModel): Observable<RegisterModel> {
    return this.httpClient.post<RegisterModel>
      (`${this.baseServiceUrl}`, registerModel, this.serviceHelper.getHttpHeaders());
  }
}
