import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layouts/header/header.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { filter } from 'rxjs/internal/operators/filter';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  showLoginButton = false;
  title = 'car-rental-ui';

  constructor(private router: Router) {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {

        const url = this.router.url;

        // Hide login button on login & register pages
        if (url === '/login' || url === '/register') {
          this.showLoginButton = false;
        } else if (url === '/dashboard') {
          this.showLoginButton = true;
        } else {
          this.showLoginButton = false;
        }
      });
  }
}
