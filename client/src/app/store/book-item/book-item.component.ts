import {Component, Input, OnInit} from '@angular/core';
import {IBook} from "../../shared/models/book";
import {DecimalPipe} from "@angular/common";
import {BasketService} from "../../basket/basket.service";

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

  constructor(private basketService: BasketService) {
  }

  addBookToBasket(book: IBook) {
    console.log(`book is foinf to be added`, book)
    this.basketService.addBookToBasket(book);
  }
}
