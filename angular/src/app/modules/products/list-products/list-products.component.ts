import { BaseCoreModule } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService, CategoryDto } from '@proxy/categories';
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
  categories : CategoryDto[] | undefined = [];
  // input: PagedAndSortedResultRequestDto = { maxResultCount: 10, skipCount: 0, sorting: '' };
  searchForm! : FormGroup;

  // eslint-disable-next-line @angular-eslint/prefer-inject
  constructor(private productsService: ProductsService, private router: Router, private fb: FormBuilder, private categoriesService: CategoriesService)
  {
    this.buildForm();
  }

  ngOnInit(): void {
    this.categoriesService.getList({maxResultCount: 10, skipCount: 0}).subscribe((response) => {
      this.categories = response.items;
    });

    this.searchProducts();
  }

  buildForm(): void {
    this.searchForm = this.fb.group({
      filter : new FormControl(''),
      categoryId: new FormControl(null)
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
