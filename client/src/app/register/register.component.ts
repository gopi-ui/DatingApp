import { Component, EventEmitter, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  // constructor(private accountService: AccountService) { }
  constructor(private accountService: AccountService, private toastr: ToastrService) { }
  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
     // error: (error: any) => console.log(error)
      error: error => {
        this.toastr.error(error.error);
        console.log(error);
      }
    })
  }

  cancel() {
    this.cancelRegister.emit(false)
  }
}
