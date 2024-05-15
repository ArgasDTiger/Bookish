import {IAuthor} from "./author";
import {IGenre} from "./genre";

export interface IBook {
  id: number;
  ISBN: string;
  title: string;
  description: string;
  imageUrl: string;
  pages: number;
  price: number;
  publishDate: Date;
  publisher?: string;
  genres: IGenre[];
  authors: IAuthor[];
}
