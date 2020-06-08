import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { OAuthModule } from 'angular-oauth2-oidc';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginCallbackComponent } from './pages/login-callback/login-callback.component';
import { UnauthorizedComponent } from './pages/unauthorized/unauthorized.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './pages/home/home.component';
import { MenuTopModule } from './components/menu-top/menu-top.module';
import { CarouselModule } from './components/carousel/carousel.module';
import { FooterModule } from './components/footer/footer.module';
import { CardComponent } from './pages/home/components/card/card.component';
import { CreateProductComponent } from './pages/home/components/create-product/create-product.component';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    AppComponent,    
    LoginCallbackComponent,    
    UnauthorizedComponent,
    HomeComponent,
    CardComponent,
    CreateProductComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    OAuthModule.forRoot(),
    MenuTopModule,
    CarouselModule,
    FooterModule,
    FormsModule,
    //BrowserAnimationsModule,
    ModalModule.forRoot()
  ],
  providers: [  
    BsModalRef  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
