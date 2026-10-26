import { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '@proxy/categories/categories.service';
import { CategoryDto } from '@proxy/categories/models';

@Component({
  selector: 'app-list-categories',
  imports: [],
  templateUrl: './list-categories.component.html',
  styleUrl: './list-categories.component.scss'
})
export class ListCategoriesComponent implements OnInit {
  categories : PagedResultDto<CategoryDto> = [] as PagedResultDto<CategoryDto>;
  input: PagedAndSortedResultRequestDto = { maxResultCount: 10, skipCount: 0, sorting: '' };

  // eslint-disable-next-line @angular-eslint/prefer-inject
  constructor(private categoriesService: CategoriesService) {}

  ngOnInit(): void {
    this.categoriesService.getList(this.input).subscribe((response) => {
      this.categories = response;
    });
  }
}
