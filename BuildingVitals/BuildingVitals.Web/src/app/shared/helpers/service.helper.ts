import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';


@Injectable()
export class ServiceHelper {

  getHttpHeaders() {

    let httpHeaders = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*')
      .set('Content-Type', 'application/json');

    return { headers: httpHeaders };
  }
}
