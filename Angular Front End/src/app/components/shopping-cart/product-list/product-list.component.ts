import { Component, OnInit } from '@angular/core';

import { ProductService } from 'src/app/services/product.service'
import { Product } from 'src/app/models/product';
import { WishlistService } from 'src/app/services/wishlist.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  productList: Product[] = []
  wishlist: number[] = []
  PriceTo :number;
  PriceFrom :number ;

  constructor(
    private productService: ProductService,
    private wishlistService: WishlistService
  ) { }

  ngOnInit() {
    this.loadProducts();
    this.loadWishlist();
  }
  ClearProducts(){
this.PriceTo =null;
this.PriceFrom =null;
    this.productService.filterProducts(0,0).subscribe((products) => {
      this.productList = products;
    })
  }
  FilterProducts() {
    this.productService.filterProducts(this.PriceFrom==null?0:this.PriceFrom,this.PriceTo==null?0:this.PriceTo).subscribe((products) => {
  this.productList = products;
})
}
  loadProducts() {
    this.productService.getProducts().subscribe((products) => {
      this.productList = products;
    })
  }

  loadWishlist() {
    this.wishlistService.getWishlist().subscribe(productIds => {
      this.wishlist = productIds
    })
  }
}
