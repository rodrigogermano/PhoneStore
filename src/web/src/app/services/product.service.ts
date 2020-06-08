import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  public CreateEvent: any = new EventEmitter<any>();

  constructor(
    private http: HttpClient,
    private oauthService: OAuthService) { }

  public Get(version: string) : Observable<any>{

    let options = {
      headers: new HttpHeaders()
                  //  .set('Authorization', `Bearer ${this.oauthService.getAccessToken()}`)
                   .set('api-version', version)
    };

    return this.http.request("GET", `${environment.urlApiGateway}/products`, options);

  }

  public Post(version: string, body: any) : Observable<any> {

    let options = {
      // headers: new HttpHeaders()
      //              .set('Authorization', `Bearer ${this.oauthService.getAccessToken()}`)
      //              .set('api-version', version),
      body: body
    };

    return this.http.request("POST", `${environment.urlApiGateway}/products`, options);
  }
}
