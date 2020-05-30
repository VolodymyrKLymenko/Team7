import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

// More details:
// https://medium.com/@zeljkoradic/loader-bar-on-every-http-request-in-angular-6-60d8572a21a9
export interface LoaderState {
    show: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  private loaderSubject = new Subject<LoaderState>();
  loaderState = this.loaderSubject.asObservable();
  constructor() { }
  show() {
    this.loaderSubject.next({ show: true } as LoaderState);
  }
  hide() {
    this.loaderSubject.next({ show: false } as LoaderState);
  }
}
