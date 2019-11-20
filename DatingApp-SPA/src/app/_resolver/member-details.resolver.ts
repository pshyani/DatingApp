import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Route, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class MemberDetailsResolver implements Resolve<User> {
  constructor(
    private userservice: UserService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot
  ): Observable<User> | Promise<User> | User {
    return this.userservice.getUser(+route.params['id']).pipe(
      catchError(error => {
        this.alertify.error(error);
        this.router.navigate(['/members']);
        return of(null);
      })
    );
  }
}