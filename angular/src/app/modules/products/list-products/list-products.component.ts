import { BaseCoreModule } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductDto } from '@proxy/products';
import { ProductsService } from '@proxy/products/products.service';

@Component({
  selector: 'app-list-products',
  imports: [BaseCoreModule, ReactiveFormsModule],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.scss'
})
export class ListProductsComponent implements OnInit {
  products : ProductDto[] | undefined = [];
  // input: PagedAndSortedResultRequestDto = { maxResultCount: 10, skipCount: 0, sorting: '' };
  searchForm! : FormGroup;

  // eslint-disable-next-line @angular-eslint/prefer-inject
  constructor(private productsService: ProductsService, private router: Router, private fb: FormBuilder) {
    this.buildForm();
  }

  ngOnInit(): void {
    this.searchProducts();
  }

  buildForm(): void {
    this.searchForm = this.fb.group({
      filter : new FormControl(''),
    });
  }

  addProduct(): void {
    this.router.navigate(['/products/add']);
  }

  searchProducts(): void {
    this.productsService.getAllProducts(this.searchForm.value).subscribe((response) => {
      this.products = response.items;
    });
  }
}
