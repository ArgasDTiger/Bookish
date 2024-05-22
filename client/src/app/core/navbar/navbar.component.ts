import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive} from "@angular/router";
import {NgbCollapse, NgbDropdown, NgbDropdownMenu, NgbDropdownToggle} from "@ng-bootstrap/ng-bootstrap";
import {ModalService} from "../../shared/modal/modal.service";
import {ModalComponent} from "../../shared/modal/modal.component";
import {LoginModalComponent} from "../modals/login-modal/login-modal.component";
import {RegisterModalComponent} from "../modals/register-modal/register-modal.component";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    NgbCollapse,
    NgbDropdownMenu,
    NgbDropdown,
    NgbDropdownToggle
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  isCollapsed = true;

  constructor(private modalService: ModalService) {}

  openLoginModal() {
    this.modalService.open(LoginModalComponent);
  }

  openRegisterModal() {
    this.modalService.open(RegisterModalComponent);
  }

}
