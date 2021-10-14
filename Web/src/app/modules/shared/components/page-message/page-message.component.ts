import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { IPageMessage } from '../../models/models';


@Component({
  selector: 'app-page-message',
  templateUrl: 'page-message.component.html',
  styleUrls: ['page-message.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class PageMessageComponent implements OnInit, OnChanges {

  @ViewChild('element') elRef!: ElementRef;

  @Input() public message!: IPageMessage;

  constructor(private cdr: ChangeDetectorRef) { }

  ngOnInit(): void { }

  ngOnChanges(change: SimpleChanges): void {
    if (change && change.message.currentValue) {

      setTimeout(() => {
        this.message = (null as unknown as IPageMessage);
        this.cdr.detectChanges();
      }, 5000);

      this.cdr.detectChanges();
      this.elRef.nativeElement.scrollIntoViewIfNeeded();
    }
  }
}
