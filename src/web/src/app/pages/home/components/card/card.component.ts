import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/model/Product.model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  public Products: Observable<Array<Product>>;

  constructor(private productService: ProductService) { 
    this.productService.CreateEvent.subscribe(
      product => {
        this.Get();   
      }
    )
  }

  ngOnInit(): void {
    this.Get();
  }
  
  Get() : void {
    this.Products = this.productService.Get("1.0");
  }

}
