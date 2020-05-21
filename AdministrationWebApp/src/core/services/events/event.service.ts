import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UserService } from '../auth/user.service';
import { ApiRoutes } from 'src/core/utils/api-routes';
import { EventModel } from 'src/core/models/event.model';
import { CreateEventModel } from './create-event.model';
import { UpdateEventModel } from './update-event.model';

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

  public createEvent(request: CreateEventModel): Observable<EventModel> {
    return this.http.post<EventModel>(ApiRoutes.events, request);
  }

  public updateEvent(eventId: number, request: UpdateEventModel): Observable<EventModel> {
    return this.http.put<EventModel>(`${ApiRoutes.events}/${eventId}`, request);
  }
}
