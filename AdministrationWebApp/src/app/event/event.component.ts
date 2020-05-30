import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from 'src/core/services/auth/user.service';
import { EventModel } from 'src/core/models/event';
import { EventService } from 'src/core/services/events/event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.styl']
})
export class EventComponent implements OnInit {
  @Input('event') public event: EventModel;

  constructor(
    private router: Router,
    private eventService: EventService,
    private userService: UserService
  ) { }

  public ngOnInit(): void {
    console.log('Ev:::', this.event);
  }
}
