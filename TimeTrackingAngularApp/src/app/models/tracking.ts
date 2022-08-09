import { SubActivity } from './SubActivity';

export interface Tracking {
  id?: number;
  name?: string;
  description?: string;
  date?: Date;
  numberOfHours?: number;
  subActivities?: SubActivity[];

  preparingDelete?: boolean;
  isEditing?: boolean;
}
