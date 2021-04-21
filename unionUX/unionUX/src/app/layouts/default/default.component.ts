import { Component, OnInit } from '@angular/core';
import { NgProgress } from '@ngx-progressbar/core';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.css']
})
export class DefaultComponent implements OnInit {

  sidebarOpen = false;

  constructor(private progress: NgProgress,
            public progressBar: ProgressbarService) { }

  ngOnInit(): void {
    this.progressBar.progressRef = this.progress.ref('progressBar');
  }

  sideBarToggler($event){
    this.sidebarOpen = !this.sidebarOpen;
  }
}
