import { Component, OnInit, TemplateRef, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { CommonConstants } from 'src/core/utils/common-constants';
import { EventModel } from 'src/core/models/event.model';
import { EventService } from 'src/core/services/events/event.service';
import { Column } from 'src/core/models/column.model';
import { EventsTableConfiguration } from './table-config';

@Component({
  selector: 'app-admin',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.styl']
})
export class AdministrationComponent implements OnInit, AfterViewInit {
  public events: EventModel[];
  public columns: Column[];

  @ViewChild('titleDescriptionColumn') public titleDescriptionColumn: TemplateRef<any>;
  @ViewChild('startDateColumn') public startDateColumn: TemplateRef<any>;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private eventService: EventService
  ) { }

  public ngOnInit(): void {
    this.updateEvents();
  }

  public ngAfterViewInit(): void {
    this.initializeTableColumns();
  }

  private updateEvents(): void {
    this.eventService.getForUser()
      .subscribe(res => {
        this.events = res;
      })
  }

  private initializeTableColumns(): void {
    const config = EventsTableConfiguration;

    const titleConfig = config.get('Title');
    titleConfig.RowContent = this.titleDescriptionColumn;
    config.set('Title', titleConfig);

    const startDateConfig = config.get('StartDate');
    startDateConfig.RowContent = this.startDateColumn;
    config.set('StartDate', startDateConfig);

    this.columns = Array.from(config.values());

    console.log(this.columns);
  }

  public editEvent(event: EventModel, index: number): void {
    console.log("edit", event, index);
  }

  public createEvent(): void {
    console.log("create new");
  }
}
