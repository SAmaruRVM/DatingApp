import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface IApplicationUser {
  id: number;
  userName: string;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'The dating app!';
  users: IApplicationUser[] = [];
  selectedUser: IApplicationUser = {
    id: 0,
    userName: ''
  };
  constructor(private httpClient: HttpClient) {

  }
  ngOnInit(): void {
    this.httpClient.get<IApplicationUser[]>('http://localhost:5000/users')
            .subscribe(response => {
              this.users = response;
              console.log(this.users);
            }, error => console.log(error))
  }


}
