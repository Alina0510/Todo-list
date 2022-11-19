import { Component } from '@angular/core';
import { MyTask } from './models/my-task';
import { MyTaskService } from './services/my-task.service';

@Component({
  selector: 'app-root',
  templateUrl: '../index.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Todo-list.ng';

}
