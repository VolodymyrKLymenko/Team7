import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UserService } from '../auth/user.service';
import { ApiRoutes } from 'src/core/utils/api-routes';
import { EventModel } from 'src/core/models/event.model';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  constructor(
    private http: HttpClient,
    private userService: UserService
  ) { }

  public getAll(): Observable<EventModel[]> {
    return this.http.get<EventModel[]>(ApiRoutes.events);
  }

  public getForUser(): Observable<EventModel[]> {
    var user = this.userService.getUserFromLocalStorage();

    return this.http.get<EventModel[]>(`${ApiRoutes.events}/${user.Id}`);
  }
}
