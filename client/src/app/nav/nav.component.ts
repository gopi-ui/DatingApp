import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  model: any = {};
  //loggedIn = false;
  //currentUser$:Observable<User| null>=of(null)

  constructor(public accountService: AccountService, private router: Router,
    private toastr: ToastrService) { }
  ngOnInit(): void {
    //this.getCurrentUser()
   // this.currentUser$ = this.accountService.currentUser$;  // durectlyf rom account service we have done
  }
  // getCurrentUser() {
  //   this.accountService.currentUser$.subscribe({
  //     next: (user) => (this.loggedIn = !!user),
  //     error:err => console.error(err)

  //   });
  // }

  login() {
    debugger
    this.accountService.login(this.model).subscribe({
      // next: (response: any) => {
       // console.log(response);
       // this.loggedIn = true;
      // },
      // error: (error: any) => console.log(error),
      next: _ => this.router.navigateByUrl('/members'),
      error: error => this.toastr.error(error.error)
    });
  }

  logout() {
    this.accountService.logout();
    //this.loggedIn = false;
    this.router.navigateByUrl('/');
  }
}
