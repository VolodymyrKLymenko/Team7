import { Component, Input, Output, EventEmitter, HostListener, OnInit } from '@angular/core';
import * as _ from 'lodash';

import { Pagination } from 'src/core/models/pagination';
import { Column } from 'src/core/models/column';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.styl']
})
export class TableComponent implements OnInit {
  public parser = _;
  public useMobileTemplate = false;
  public pagination: Pagination;

  @Input('columns') public columns: Column[];
  @Input('data') public data: any[];
  @Input('mobileWidth') public minAvaliableWidth;
  @Input('rowAmount') public rowAmount = 10;
  @Input('totalAmount') public totalAmount = 0;

  @Output('rowClicked') public rowClickedEvent = new EventEmitter<any>();
  @Output('pageChanged') public pageChangedEvent = new EventEmitter<Pagination>();

  @HostListener('window:resize', ['$event'])
  public onResize(event: any): void {
    this.checkMobileCompability(event.target.innerWidth);
  }

  public ngOnInit(): void {
    this.setUpPagintaion();
    this.checkMobileCompability(window.innerWidth);
  }

  public checkMobileCompability(windowWidth: number): void {
    if (this.minAvaliableWidth && windowWidth <= this.minAvaliableWidth) {
      this.useMobileTemplate = true;
    } else {
      this.useMobileTemplate = false;
    }
  }

  public rowClicked(data: any): void {
    this.rowClickedEvent.emit(data);
  }

  public moveToNextPage(): void {
    this.pagination.pageNumber++;
    this.pageChangedEvent.emit(this.pagination);
  }

  public moveToPreviousPage(): void {
    this.pagination.pageNumber--;
    this.pageChangedEvent.emit(this.pagination);
  }

  private setUpPagintaion(): void {
    this.pagination = {
      pageNumber: 0,
      pageCount: this.rowAmount
    };
  }
}
