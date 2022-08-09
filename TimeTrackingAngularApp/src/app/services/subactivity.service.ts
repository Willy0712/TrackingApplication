import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from '../constants';
import { SubActivity } from '../models/SubActivity';

@Injectable({
  providedIn: 'root',
})
export class SubactivityService {
  constructor(private httpClient: HttpClient) {}

  updateSubactivity(subActivities: SubActivity) {
    return this.httpClient.put(
      `${API_URL}/Subactivity/${subActivities.id}`,
      subActivities
    );
  }
}
