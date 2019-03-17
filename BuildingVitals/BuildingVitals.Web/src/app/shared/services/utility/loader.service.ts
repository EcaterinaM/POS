import { Injectable } from '@angular/core';

@Injectable()
export class LoaderService {

  public requestsCompleted: number = 0;
  public requestsStarted: number = 0;
  public isLoading: boolean = false;

  public showApplicationLoader = (): void => {
    this.requestsStarted++;
    this.isLoading = true;
  };

  public hideApplicationLoader = (): void => {
    this.requestsCompleted++;
    if (this.requestsStarted === this.requestsCompleted) {
      this.isLoading = false;
    }
  };
}
