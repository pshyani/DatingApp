import { BrowserModule, HammerGestureConfig, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { JwtModule } from '@auth0/angular-jwt';
import { BsDropdownModule, TabsModule, PaginationModule } from 'ngx-bootstrap';
import { NgxGalleryModule } from 'ngx-gallery';
import {TimeAgoPipe} from 'time-ago-pipe';

import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { UserService } from "./_services/user.service";

import { AuthGuard } from "./_guard/auth.guard";
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { MemberDetailsResolver } from './_resolver/member-details.resolver';
import { MemberListResolver } from './_resolver/member-list.resolver';
import { MemberEditResolver } from './_resolver/member-edit.resolver';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { MemeberDetailsComponent } from './members/memeber-details/memeber-details.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { PreventUnSavedChanges } from './_guard/prevent-unsaved.guard';



export function tokenGetter() {
   return localStorage.getItem('token');
 }

 export class CustomHammerConfig extends HammerGestureConfig {
   overrides = {
       pinch: { enable: false },
       rotate: { enable: false }
   };
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MemberListComponent,
      ListsComponent,
      MessagesComponent,
      MemberCardComponent,
      MemeberDetailsComponent,
      TimeAgoPipe,
      MemberEditComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      NgxGalleryModule,
      PaginationModule.forRoot(),
      JwtModule.forRoot({
         config: {
           tokenGetter: tokenGetter,
           whitelistedDomains: ["localhost:5000"],
           blacklistedRoutes: ["localhost:5000/api/auth"]
         }
       })
   ],
   providers: [
      AuthService,      
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      UserService,
      MemberDetailsResolver,
      MemberListResolver,
      MemberEditResolver,
      PreventUnSavedChanges,
      { provide: HAMMER_GESTURE_CONFIG, useClass: CustomHammerConfig }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
