import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IGenre} from "../shared/models/genre";
import {environment} from "../../environments/environment.development";
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private http: HttpClient) { }

  getGenres() {
    return this.http.get<IGenre[]>(environment.apiUrl + 'genres',
      { observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getAuthors() {
    return this.http.get<IGenre[]>(environment.apiUrl + 'author',
      { observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }
}
