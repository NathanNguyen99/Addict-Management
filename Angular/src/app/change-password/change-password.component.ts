import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AlertService, UserService } from '../Shared/Services';
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  registerForm: FormGroup;
  submitted: boolean = false;
  hide = true;
  constructor(private fb: FormBuilder, private usersevice: UserService,private alertSv:AlertService) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group(
      {
        oldpassword: ["",Validators.required],
        password: ["",Validators.required],
        confirmPassword: ["",Validators.required]
      },
      {
        validator: this.ConfirmPasswordValidator("password", "confirmPassword")
      }
    );
  }



  ConfirmPasswordValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      let control = formGroup.controls[controlName];
      let matchingControl = formGroup.controls[matchingControlName]
      if (
        matchingControl.errors &&
        !matchingControl.errors.confirmPasswordValidator
      ) {
        return;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmPasswordValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

  onSubmit() {
    this.submitted = true;
    if (this.registerForm.status === "VALID") {
      //console.log(this.registerForm.controls)
        this.usersevice.ChangePw(this.registerForm.controls.oldpassword.value,this.registerForm.controls.password.value).subscribe((r: any) => {
          console.log(r);
            if (r === false)
              this.fail();
            else 
              this.success();
        },
        (er: any)=> console.log(er));
    }
  }

  private success() {
        this.alertSv.message("Lưu thành công");
  }

  private fail() {
    this.alertSv.message("Có lỗi, kiểm tra mật khẩu cũ");
}
}
