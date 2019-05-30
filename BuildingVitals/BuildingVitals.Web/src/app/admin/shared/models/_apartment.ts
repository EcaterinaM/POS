import { Tenant } from 'src/app/tenant/shared/models/_tenant';

export class Apartment {
  floor: string;
  number: number;
  ownerId: string;
  buildingId: string;
  id?: string;
  owner?: Tenant;
}
