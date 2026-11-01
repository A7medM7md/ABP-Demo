import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AddOrEditProductDto extends EntityDto<number> {
  nameEn?: string;
  nameAr?: string;
  descriptionEn?: string;
  descriptionAr?: string;
  categoryId: number;
}

export interface GetProductListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
  categoryId?: number;
}

export interface ProductDto extends FullAuditedEntityDto<number> {
  nameEn?: string;
  nameAr?: string;
  descriptionEn?: string;
  descriptionAr?: string;
  categoryId: number;
  categoryNameEn?: string;
  categoryNameAr?: string;
  categoryDescriptionEn?: string;
  categoryDescriptionAr?: string;
}
