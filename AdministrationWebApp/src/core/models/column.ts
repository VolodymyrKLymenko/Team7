import { TemplateRef } from '@angular/core';

export class Column {
    Header: string;
    HeaderContent?: TemplateRef<any>;
    RowContent?: TemplateRef<any>;
    DataPath: string;

    constructor(header: string, path: string) {
        this.Header = header;
        this.DataPath = path;
    }
}
