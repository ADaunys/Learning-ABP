import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  title: string;
  description: string;
  dueDate: Date;

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  constructor(private authService: AuthService) { }

  login() {
    this.authService.navigateToLogin();
  }

  createTaskItem() {
    console.log(this.title, this.description, this.dueDate);
  }
}
