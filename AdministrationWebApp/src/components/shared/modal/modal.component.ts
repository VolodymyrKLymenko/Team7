import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.styl']
})
export class ModalComponent {
  @Input('isVisiable') public isVisiable = false;
  @Output('changed') public visibleChange = new EventEmitter<boolean>();

  public hideWindow(): void {
    this.isVisiable = false;
    this.visibleChange.emit(this.isVisiable);
  }

  public showWindow(): void {
    this.isVisiable = true;
    this.visibleChange.emit(this.isVisiable);
  }
}
