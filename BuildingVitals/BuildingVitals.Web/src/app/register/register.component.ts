import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { RegisterModel } from '../shared';
import { RegexConstants } from '../shared';
import { RegisterService } from '../shared';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  isFormSubmitted = false;
  registerForm: FormGroup;
  registerModel: RegisterModel;
  registerFailed: boolean = false;

  constructor(private formBuilder: FormBuilder,
    private registerService: RegisterService,
    private router: Router) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  submitForm(): void {
    this.isFormSubmitted = true;

    if (this.registerForm.get('password').value != this.registerForm.get('confirmPassword').value) {
      this.registerForm.get('confirmPassword').setErrors({ 'match': true });
    }

    if (this.registerForm.valid) {
      this.registerModel = this.registerForm.value;

      this.registerService.register(this.registerModel).subscribe(
        () => {
          this.router.navigateByUrl('/login');
        },
        () => {
          this.isFormSubmitted = false;
          this.registerFailed = true;
        });
    }
  }

  transformImage(backgroundImage: string) {
    return "url('" + backgroundImage + "')";
  }

  private createRegisterForm(): void {
    this.registerModel = new RegisterModel();
    this.registerForm = this.formBuilder.group({
      username: [this.registerModel.username, [Validators.required, Validators.maxLength(128)]],
      name: [this.registerModel.name, [Validators.required, Validators.maxLength(128)]],
      surname: [this.registerModel.surname, [Validators.required, Validators.maxLength(128)]],
      email: [this.registerModel.email, [Validators.required, Validators.pattern(RegexConstants.email)]],
      password: [this.registerModel.password, [Validators.required, Validators.maxLength(128)]],
      confirmPassword: [this.registerModel.confirmPassword, [Validators.required, Validators.maxLength(128)]],
      phoneNumber: [this.registerModel.phoneNumber, [Validators.required, Validators.pattern(RegexConstants.phoneNumber)]]
    });
  }


  public hasControlErorr(controlName: string, error: string): boolean {
    if (this.registerForm.get(controlName).hasError(error)
      && (this.registerForm.controls[controlName].dirty || this.isFormSubmitted)) {
      return true;
    }
    return false;
  }
}
