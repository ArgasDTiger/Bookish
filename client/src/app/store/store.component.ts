import {Component, OnInit} from '@angular/core';
import {NgClass, NgForOf, NgIf} from "@angular/common";
import {NgbDropdown, NgbDropdownMenu, NgbDropdownToggle} from "@ng-bootstrap/ng-bootstrap";
import {StoreService} from "./store.service";
import {IGenre} from "../shared/models/genre";

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [
    NgClass,
    NgIf,
    NgbDropdownToggle,
    NgbDropdownMenu,
    NgbDropdown,
    NgForOf
  ],
  templateUrl: './store.component.html',
  styleUrl: './store.component.css'
})
export class StoreComponent implements OnInit {

  genres: IGenre[] = [{name: 'All'}];
  selectedGenres: string[] = ['All'];
  constructor(private storeService: StoreService) {
  }

  ngOnInit(): void {
      this.getGenres();
  }

  getGenres() {
    this.storeService.getGenres()
      .subscribe(response => {
        this.genres = [...this.genres, ...response!];
      })
  }

  selectGenre(genre: string) {
    if (genre === 'All') {
      this.selectedGenres = ['All'];
    } else if (this.selectedGenres.includes('All')) {
      this.selectedGenres = [genre];
    } else if (this.selectedGenres.includes(genre)) {
      const index = this.selectedGenres.indexOf(genre);
      this.selectedGenres.splice(index, 1);
    } else {
      this.selectedGenres.push(genre);
    }
  }


}
