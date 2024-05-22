import { Component } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  FormsModule, ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators
} from "@angular/forms";
import { ModalComponent } from "../../../shared/modal/modal.component";
import { TextInputComponent } from "../../../shared/components/text-input/text-input.component";

@Component({
  selector: 'app-register-modal',
  standalone: true,
  imports: [
    FormsModule,
    ModalComponent,
    ReactiveFormsModule,
    TextInputComponent,
  ],
  templateUrl: './register-modal.component.html',
  styleUrls: ['./register-modal.component.css']
})
export class RegisterModalComponent {
  registerForm!: FormGroup;

  ngOnInit(): void {
    this.createRegisterForm();
  }

  passwordMatchValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password')?.value;
    const confirmPasswordControl = control.get('confirmPassword');

    if (password !== confirmPasswordControl?.value) {
      confirmPasswordControl?.setErrors({ passwordMismatch: true });
    } else {
      confirmPasswordControl?.setErrors(null);
    }
    return null;
  };


  createRegisterForm() {
    this.registerForm = new FormGroup(
      {
        email: new FormControl('', [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/),
        ]),
        username: new FormControl('', [
          Validators.required,
          Validators.pattern(/^.{3,}$/),
        ]),
        password: new FormControl('', [
          Validators.required,
          Validators.pattern(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[_#?!@$%^&*-]).{8,}$/),
        ]),
        confirmPassword: new FormControl('', [Validators.required]),
      },
      { validators: this.passwordMatchValidator }
    );
  }


}
