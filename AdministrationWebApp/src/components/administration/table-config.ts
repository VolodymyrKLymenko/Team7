import { Column } from 'src/core/models/column';

export const EventsTableConfiguration = new Map([
    ['Title', new Column('Title', 'title')],
    ['Description', new Column('Description', 'description')],
    ['StartDate', new Column('Start date', 'startDateTime')],
    ['OrganizedFaculty', new Column('Organized by', 'facultyName')],
    ['SupportPhone', new Column('Support', 'supportPhone')]
]);

