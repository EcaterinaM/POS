import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';

import { ServiceHelper } from '../../helpers';

import { BaseService } from '../base.service';

import { UserModel } from '../../models/user.model';


@Injectable()
export class UserService extends BaseService {

  constructor(private baseService: BaseService,
    httpClient: HttpClient,
    serviceHelper: ServiceHelper) {
    super(httpClient, serviceHelper);
    this.baseServiceUrl = environment.serviceUrl + 'v1/users';
  }

  getUserDetails(username: string): Observable<UserModel> {
    return this.httpClient.get<UserModel>(`${this.baseServiceUrl}/${username}`, this.serviceHelper.getHttpHeaders());
  }

  editUser(user: UserModel, username: string) {
    return this.httpClient.put(`${this.baseServiceUrl}/${username}`, user, this.serviceHelper.getHttpHeaders());
  }
}
