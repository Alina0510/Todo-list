import { Component } from '@angular/core';
import { MyTask } from '../models/my-task';
import { MyTaskService } from '../services/my-task.service';

@Component({
  selector: 'app-root',
  templateUrl: './my-tasks.component.html',
  styleUrls: ['./app.component.css']
})
export class MyTasksComponent {
  title = 'Todo-list.ng';
  tasks: MyTask[] = [];

  constructor(private myTaskService: MyTaskService) { }
  ngOnInit(): void {
    this.tasks = this.myTaskService.getTasks();
  }
}
