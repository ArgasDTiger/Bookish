import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {NavbarComponent} from "./core/navbar/navbar.component";
import {FooterComponent} from "./core/footer/footer.component";
import {AccountService} from "./account/account.service";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token!)
      .subscribe(() => {
    }, error => {
      console.log(error);
    });
  }
}
