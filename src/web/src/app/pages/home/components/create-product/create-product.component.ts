import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Product } from 'src/app/model/Product.model';
import { ProductService } from 'src/app/services/product.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { OAuthService } from 'angular-oauth2-oidc';


@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {

  public modalRef: BsModalRef;
  
  public Product: Product = new Product();
  public MaxFileSize: number = 25;

  constructor(
    private productService: ProductService,
    private modalService: BsModalService,
    private oauthService: OAuthService) { }

  ngOnInit(): void {
  }

  public Initialize() : void {
    this.Product = new Product();
  }

  public openModal(template: TemplateRef<any>) : void {
    this.Initialize();
    
    let config = {
      backdrop: true,
      ignoreBackdropClick: true,
      class: 'modal-dialog'
    };

    this.modalRef = this.modalService.show(template, config);
  }

  public closeModal() : void {
    if (!this.modalRef) {
      return;
    }
 
    this.modalRef.hide();
    this.modalRef = null;
  }

  public Create() : void {

    console.log("Create");

    this.productService.Post("1.0", this.Product).subscribe(
      success => {
        this.productService.CreateEvent.next(this.Product);
        this.closeModal();
      },
      error => console.log(error)
    )
  }

  onChangeAnexarDocumento(event) : void {

    let reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        let _tamanhoEmMB = file.size / 1048576;

        if (_tamanhoEmMB > this.MaxFileSize) {
          return null;
        }

        this.Product.photo = (reader.result as string).split(',')[1];

      };
    }
  }

  private GetType(name: string, type: string): string {
    if (type != null && type != "") {
      return type
    }

    switch (name.substring(name.lastIndexOf(".") + 1)) {
      case 'msg':
        return 'application/vnd.ms-outlook';
    }
    return type;
  }

  public IsAutenticated() : boolean {    
    return this.oauthService.hasValidIdToken();
  }
}
