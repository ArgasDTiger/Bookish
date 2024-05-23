import {Component, OnInit} from '@angular/core';
import {RouterLink, RouterLinkActive} from "@angular/router";
import {NgbCollapse, NgbDropdown, NgbDropdownMenu, NgbDropdownToggle} from "@ng-bootstrap/ng-bootstrap";
import {ModalService} from "../../shared/modal/modal.service";
import {ModalComponent} from "../../shared/modal/modal.component";
import {LoginModalComponent} from "../modals/login-modal/login-modal.component";
import {RegisterModalComponent} from "../modals/register-modal/register-modal.component";
import {Observable} from "rxjs";
import {IUser} from "../../shared/models/user";
import {AccountService} from "../../account/account.service";
import {AsyncPipe, NgIf} from "@angular/common";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    NgbCollapse,
    NgbDropdownMenu,
    NgbDropdown,
    NgbDropdownToggle,
    NgIf,
    AsyncPipe
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  isCollapsed = true;
  currentUser$!: Observable<IUser>;
  constructor(private modalService: ModalService,
              private accountService: AccountService) {}

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  openLoginModal() {
    this.modalService.open(LoginModalComponent);
  }

  openRegisterModal() {
    this.modalService.open(RegisterModalComponent);
  }

  onLogout() {
    this.accountService.logout()
  }

}
