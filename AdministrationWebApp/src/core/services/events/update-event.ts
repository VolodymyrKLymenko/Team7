import { FacultyModel } from 'src/core/models/faculty';

export class UpdateEventModel {
    id: number;
    title: string;
    description: string;
    startDate: Date;
    endDate: Date;
    location: string;
    facultyId: number;
    eventStatusId: number;
    faculty: FacultyModel;
}
