import {AfterViewInit, Component, ElementRef, Input, Output, ViewChild} from '@angular/core';
import {IBook} from "../../../shared/models/book";
import {Subject} from "rxjs";

@Component({
  selector: 'app-carousel-item',
  standalone: true,
  imports: [],
  templateUrl: './carousel-item.component.html',
  styleUrl: './carousel-item.component.css'
})
export class CarouselItemComponent implements AfterViewInit {
  @Input("book") book!: IBook;
  @ViewChild("cardContainer") cardContainer!: ElementRef;
  @Output() cardWidthEmitter = new Subject<number>();

  ngAfterViewInit() {
    const cardWidth = this.cardContainer.nativeElement.offsetWidth;
    console.log(`WIDTH IS ${cardWidth}`)
    this.cardWidthEmitter.next(cardWidth);
  }
}
