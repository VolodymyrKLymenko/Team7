import { FacultyModel } from 'src/core/models/faculty';

export class CreateEventModel {
    title: string;
    description: string;
    startDateTime: Date;
    finishDateTime: Date;
    location: string;
    facultyId: number;
    eventStatusId: number;
    faculty: FacultyModel;
}
