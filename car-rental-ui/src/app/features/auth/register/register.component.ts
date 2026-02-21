import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  standalone: true
})
export class RegisterComponent {
  registerData: any = {
    name: '',
    email: '',
    password: '',
    profileImage: null
  };

  onFileSelected(event: any) {
    this.registerData.profileImage = event.target.files[0];
  }

  onRegister() {
    console.log(this.registerData);
    // call auth service here
  }
}
