import { Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {StoreComponent} from "./store/store.component";

export const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'store', component: StoreComponent }
];
