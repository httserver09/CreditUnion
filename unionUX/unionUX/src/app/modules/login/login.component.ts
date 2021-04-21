import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  LoggedIn: boolean = false;

  constructor(private authService: AuthService,
          private alertService: AlertService,
          public progressBar: ProgressbarService,
          private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm){
    this.alertService.info('Logging in...');
    this.progressBar.startLoading();

    const loginObserver = {
      next: x => {
        this.progressBar.setSuccess();
        this.router.navigate(['accounts']); 
        this.alertService.success('Welcom back: ' + x.username);
        this.progressBar.completeLoading();
        
      },
      error: err => {
        this.progressBar.setError();
        console.log(err);
        this.alertService.danger('Unable to login !');
        this.progressBar.completeLoading();
      }
    }

    this.authService.login(f.value).subscribe(loginObserver);
    
    this.LoggedIn = true;
  }

}
