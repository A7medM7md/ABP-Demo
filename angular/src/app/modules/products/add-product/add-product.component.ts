import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService, CategoryDto } from '@proxy/categories';
import { ProductsService } from '@proxy/products';

@Component({
  selector: 'app-add-product',
  imports: [ReactiveFormsModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.scss'
})
export class AddProductComponent implements OnInit {

  // FormGroup: is a set of form controls, each form control is a form field in the form, and i want to save them together in one variable to be able to manage them easily.
  // FormGroup at the end of the day will be translated to DTO
  productForm! : FormGroup;
  categories : CategoryDto[] | undefined = [];
  input = { maxResultCount: 100, skipCount: 0, sorting: '' };

  // eslint-disable-next-line @angular-eslint/prefer-inject
  constructor(private productsService: ProductsService,
    // eslint-disable-next-line @angular-eslint/prefer-inject
    private router: Router,
    // eslint-disable-next-line @angular-eslint/prefer-inject
    private categoriesService: CategoriesService,
    // eslint-disable-next-line @angular-eslint/prefer-inject
    private formBuilder: FormBuilder
  )
  {
    this.buildForm();
  }

  ngOnInit(): void {
    this.categoriesService.getList(this.input).subscribe((response) => {
      this.categories = response.items;
    });
  }

  // There are 2 ways in angular to draw the form and bind it to the component, one is template driven forms and the other is reactive forms, in this example we will use reactive forms.


  buildForm(){
    // name of property in form group should be the same as the name of property in the DTO, to be able to bind them together easily, and to be able to use the form group value as the DTO directly
    // and also same as formControlName value in the html.
    this.productForm = this.formBuilder.group({
      nameAr: new FormControl('', {validators: [Validators.required, Validators.maxLength(300)]}),
      nameEn: new FormControl('', {validators: [Validators.required, Validators.maxLength(300)]}),
      descriptionAr: new FormControl('', {validators: [Validators.required, Validators.maxLength(900)]}),
      descriptionEn: new FormControl('', {validators: [Validators.required, Validators.maxLength(900)]}),
      categoryId: new FormControl('', {validators: [Validators.required]})
    });
  }

  saveProduct(){

    if(this.productForm.invalid){
      return;
    }

    this.productsService.createProduct(this.productForm.value).subscribe(() => {
      this.router.navigateByUrl('/products');
    });
  }

  cancel(){
    this.router.navigateByUrl('/products');
  }
}
