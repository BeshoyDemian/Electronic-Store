import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service'
import { Product } from 'src/app/models/product';
import { WishlistService } from 'src/app/services/wishlist.service';
@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit {
message :string
  productList: Product[] = []
  wishlist: number[] = []
  PriceTo :number;
  PriceFrom :number ;

  constructor(
    private productService: ProductService,
  ){ }

  ngOnInit() {
  }

 
  FilterProducts() {
        this.productService.filterProducts(this.PriceFrom==null?0:this.PriceFrom,this.PriceTo==null?0:this.PriceTo).subscribe((products) => {
      this.productList = products;
    })
  }
}
