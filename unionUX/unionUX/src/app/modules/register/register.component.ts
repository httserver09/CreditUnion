import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertService } from 'ngx-alerts';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {
    Username: null,
    Email: null,
    Password: null,
    role: null,
    title: null
  };


  constructor(private authService: AuthService,
            private progressBar: ProgressbarService,
            private alertService: AlertService) { 

  }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm){
    this.alertService.info('Posting registration form');
    
    this.progressBar.startLoading();
    
    const registerObserver = {
      next: x => {
        this.progressBar.setSuccess();
        console.log('User Registered !');
        this.alertService.success('Registration successful !');
        this.progressBar.completeLoading();
      },
      error: err => {
        this.progressBar.setError();
        console.log(err);
        this.alertService.danger(err.error.Errors[0].Description);
        this.progressBar.completeLoading();
      }
    }

    console.log(f.value);
    console.log(f.valid);
   

    //call service
    this.authService.register(this.model).subscribe(registerObserver);
  }

}
