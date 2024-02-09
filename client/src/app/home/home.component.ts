import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  registerMode = false;
  users: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/user').subscribe({
      next: (response: any) => this.users = response,
      error: (error: any) => console.log(error),
      complete: () => console.log('Requst has completed')
    })
  }

  cancelRegisterMode(event: boolean) {
    //this.registerMode = event.target.value;
    this.registerMode = event;
  }
}
