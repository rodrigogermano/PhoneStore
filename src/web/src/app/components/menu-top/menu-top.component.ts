import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-menu-top',
  templateUrl: './menu-top.component.html',
  styleUrls: ['./menu-top.component.scss']
})
export class MenuTopComponent implements OnInit {

  constructor(private oauthService: OAuthService) { }

  ngOnInit(): void {        
  }

  public login() : void {     
    this.oauthService.initImplicitFlow("login");    
  }

  public logout() : void{    
    this.oauthService.logOut();
  }

  public IsAutenticated() : boolean {    
    return this.oauthService.hasValidIdToken();
  }
}