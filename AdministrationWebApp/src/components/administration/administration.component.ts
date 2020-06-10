import { Component, OnInit, TemplateRef, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { EventModel } from 'src/core/models/event';
import { EventService } from 'src/core/services/events/event.service';
import { Column } from 'src/core/models/column';
import { EventsTableConfiguration } from './table-config';
import { UpdateEventModel } from 'src/core/services/events/update-event';
import { CreateEventModel } from 'src/core/services/events/create-event';
import { FormValidationService } from 'src/core/services/validation/validation.service';
import { ValidationMessages } from 'src/core/utils/common-constants';
import { FacultyModel } from 'src/core/models/faculty';

@Component({
  selector: 'app-admin',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.styl']
})
export class AdministrationComponent implements OnInit, AfterViewInit {
  public events: EventModel[];
  public columns: Column[];
  public actionForm: FormGroup;
  public formErrors: any = {};
  public submitTouched = false;

  public isEditWindowOpen = false;
  public eventToUpdate: UpdateEventModel;
  public editingEventId = -1;
  public editingEventIndex = -1;
  public eventToCreate: CreateEventModel;

  public faculties: FacultyModel[] = [
    { id: 1, name: "Applied Mathematic" } as FacultyModel,
    { id: 2, name: "Physician faculty" } as FacultyModel,
    { id: 3, name: "Biological faculty" } as FacultyModel
  ]

  private eventTitleToEdit: string;
  private eventSupportToEdit: string;

  @ViewChild('titleDescriptionColumn') public titleDescriptionColumn: TemplateRef<any>;
  @ViewChild('startDateColumn') public startDateColumn: TemplateRef<any>;

  constructor(
    private eventService: EventService,
    private formValidationService: FormValidationService
  ) { }

  public ngOnInit(): void {
    this.updateEvents();
  }

  public ngAfterViewInit(): void {
    this.initializeTableColumns();
  }

  private updateEvents(): void {
    this.eventService.getAll()
      .subscribe(res => {
        this.events = res;
      });
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
  }

  public editEvent(event: EventModel, index: number): void {
    this.editingEventId = event.id;
    this.editingEventIndex = index;
    this.eventTitleToEdit = event.title;
    this.eventSupportToEdit = event.supportPhone;

    this.eventToUpdate = {
      id: event.id,
      description: event.description,
      location: event.location,
      startDate: event.startDateTime,
      endDate: event.finishDateTime,
      facultyId: event.facultyId,
      eventStatusId: event.eventStatusId
    } as UpdateEventModel;

    this.createEditForm();
    this.isEditWindowOpen = true;
  }

  public createEvent(): void {
    this.eventToCreate = {
      startDateTime: new Date(Date.now()),
      finishDateTime: new Date(Date.now())
    } as CreateEventModel;

    this.createNewEventForm();
    this.isEditWindowOpen = true;
  }

  public get canEditTitle(): boolean {
    return this.eventToCreate && !this.eventToUpdate;
  }

  public onSubmit(): void {
    this.submitTouched = true;

    if (this.actionForm.valid) {
      if (this.eventToUpdate) {
        this.eventToUpdate.title = this.eventTitleToEdit;
        this.eventToUpdate.description = this.actionForm.controls['description'].value;
        this.eventToUpdate.location = this.actionForm.controls['location'].value;
        this.eventToUpdate.startDate = this.actionForm.controls['startDate'].value;
        this.eventToUpdate.endDate = this.actionForm.controls['endDate'].value;
        this.eventToUpdate.faculty = this.actionForm.controls['faculty'].value;
        this.eventToUpdate.facultyId = this.actionForm.controls['faculty'].value.id;

        console.log('eventtttttttt ', this.eventToUpdate)

        this.eventService.updateEvent(this.eventToUpdate)
          .subscribe(res => {
            this.events.splice(this.editingEventIndex, 1, res);
          });
      }
      else {
        this.eventToCreate.title = this.actionForm.controls['title'].value;
        this.eventToCreate.description = this.actionForm.controls['description'].value;
        this.eventToCreate.location = this.actionForm.controls['location'].value;
        this.eventToCreate.startDateTime = this.actionForm.controls['startDate'].value;
        this.eventToCreate.finishDateTime = this.actionForm.controls['endDate'].value;
        this.eventToCreate.faculty = this.actionForm.controls['faculty'].value;
        this.eventToCreate.facultyId = this.actionForm.controls['faculty'].value.id;

        console.log('eventtttttttt ', this.eventToCreate)
        this.eventService.createEvent(this.eventToCreate)
          .subscribe(res => {
            this.events.splice(0, 0, res);
          });
      }
      this.resetForm();
    }
    else {
      this.formValidationService.markFormGroupTouched();
      this.validateForm();
    }
  }

  private createEditForm(): void {
    this.actionForm = new FormGroup({
      title: new FormControl(this.eventTitleToEdit, []),
      faculty: new FormControl(this.eventToUpdate.faculty, []),
      description: new FormControl(this.eventToUpdate.description, [Validators.required]),
      location: new FormControl(this.eventToUpdate.location, [Validators.required]),
      startDate: new FormControl(new Date(this.eventToUpdate.startDate), [Validators.required]),
      endDate: new FormControl(new Date(this.eventToUpdate.endDate), [Validators.required]),
      support: new FormControl(this.eventSupportToEdit, [])
    });

    this.formValidationService.setFormData(this.actionForm, ValidationMessages.EditEvents);
    this.actionForm.valueChanges.subscribe(() => this.validateForm());
  }

  private createNewEventForm(): void {
    this.actionForm = new FormGroup({
      title: new FormControl(this.eventToCreate.title, [Validators.required]),
      faculty: new FormControl(this.eventToCreate.faculty, []),
      description: new FormControl(this.eventToCreate.description, [Validators.required]),
      location: new FormControl(this.eventToCreate.location, [Validators.required]),
      startDate: new FormControl(new Date(this.eventToCreate.startDateTime), [Validators.required]),
      endDate: new FormControl(new Date(this.eventToCreate.finishDateTime), [Validators.required]),
      support: new FormControl(this.eventSupportToEdit, [])
    });

    this.formValidationService.setFormData(this.actionForm, ValidationMessages.EditEvents);
    this.actionForm.valueChanges.subscribe(() => this.validateForm());
  }

  private validateForm(): void {
    this.formErrors = this.formValidationService.validateForm();
  }

  private resetForm(): void {
    this.eventToCreate = null;
    this.eventToUpdate = null;
    this.editingEventId = null;
    this.eventTitleToEdit = null;

    this.actionForm = null;
    this.formErrors = {};
    this.submitTouched = false;

    this.isEditWindowOpen = false;
  }

  public changeEditWindowVisibility(visibility: boolean): void {
    this.isEditWindowOpen = visibility;

    if (!visibility) {
      this.resetForm();
    }
  }
}
