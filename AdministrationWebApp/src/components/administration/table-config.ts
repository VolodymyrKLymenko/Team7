import { Column } from 'src/core/models/column.model';

export const EventsTableConfiguration = new Map([
    ['Title', new Column('Title', 'title')],
    ['Location', new Column('Location', 'location')],
    ['StartDate', new Column('Start date', 'startDate')],
    ['OrganizedUniversity', new Column('Organized by', 'organizedUniversity')],
    ['SupportPhone', new Column('Support', 'supportPhone')]
]);

