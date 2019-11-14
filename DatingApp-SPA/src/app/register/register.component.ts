import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();
  
  model: any = {};
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register(form: NgForm) {
     this.authService.register(this.model).subscribe(() => {
        console.log('Registration Successfull');
     }, error => {
       console.log(error);
     });
  }

  cancel() {
    this.cancelRegister.emit(false); 
  }
}
