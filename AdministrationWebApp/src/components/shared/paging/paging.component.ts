import { Component, Output, EventEmitter, Input } from '@angular/core';
import { Pagination } from 'src/core/models/pagination';

@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html',
  styleUrls: ['./paging.component.styl']
})
export class PagingComponent {
  @Output('moveNextPage') public moveNextPage = new EventEmitter<any>();
  @Output('movePreviousPage') public movePreviousPage = new EventEmitter<any>();
  @Input('pagingInfo') public pagination: Pagination;
  @Input('totalAmount') public totalAmount: number;

  public moveNext(): void {
    if (this.nextAvaliable()) {
      this.moveNextPage.emit();
    }
  }

  public movePrevious(): void {
    if (this.previousAvaliable()) {
      this.movePreviousPage.emit();
    }
  }

  public nextAvaliable(): boolean {
    return this.pagination && ((this.pagination.pageNumber + 1) < (this.totalAmount / this.pagination.pageCount));
  }

  public previousAvaliable(): boolean {
    return this.pagination && (this.pagination.pageNumber > 0);
  }
}
