import { NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [NgIf],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  standalone: true
})

export class HeaderComponent {
 
  @Input() showLoginButton: boolean = false;

  constructor(private router: Router) {
    
  }

  user = {
    name: 'Sharan',
    profileImage: ''
  };

  logout() {
    console.log('Logout clicked');
    // call authService.logout()
  }

  logIn() {
    this.router.navigate(['/login']);
  }
}
