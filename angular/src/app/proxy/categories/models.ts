import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';

export interface AddOrEditCategoryDto extends EntityDto<number> {
  nameEn: string;
  nameAr: string;
  descriptionEn: string;
  descriptionAr: string;
}

export interface CategoryDto extends FullAuditedEntityDto<number> {
  nameEn?: string;
  nameAr?: string;
  descriptionEn?: string;
  descriptionAr?: string;
}
