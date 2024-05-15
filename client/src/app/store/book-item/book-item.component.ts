import {Component, Input} from '@angular/core';
import {IBook} from "../../shared/models/book";
import {DecimalPipe} from "@angular/common";

@Component({
  selector: 'app-book-item',
  standalone: true,
  imports: [
    DecimalPipe
  ],
  templateUrl: './book-item.component.html',
  styleUrl: './book-item.component.css'
})
export class BookItemComponent {
  @Input() book!: IBook;

}
