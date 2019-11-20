import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Route, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class MemberListResolver implements Resolve<User[]> {

    pageNumber = 1;
    pageSize = 5;
    constructor(private userservice: UserService,
                private router: Router,
                private alertify: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<User[]> | Promise<User[]> | User[] {
        return this.userservice.getUsers(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error(error);
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}