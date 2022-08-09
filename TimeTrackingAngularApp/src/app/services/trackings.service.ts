import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from '../constants';
import { Tracking } from '../models/tracking';

@Injectable({
  providedIn: 'root',
})
export class TrackingsService {
  constructor(private httpClient: HttpClient) {}

  getTrackings() {
    return this.httpClient.get<Tracking[]>(`${API_URL}/trackings`);
  }

  getTrackingsById(id: number) {
    return this.httpClient.get<Tracking>(`${API_URL}/trackings/` + id);
  }

  addTrackings(tracking: Tracking) {
    return this.httpClient.post(`${API_URL}/trackings`, tracking);
  }

  deleteTrackings(tracking: Tracking) {
    return this.httpClient.delete(`${API_URL}/trackings/` + tracking.id);
  }

  updateTrackings(trackingId: number, tracking: Tracking) {
    return this.httpClient.put(`${API_URL}/trackings/${trackingId}`, tracking);
  }

  filterTrackings(tracking: Tracking) {
    if (tracking.date != null) {
      return this.httpClient.get<Tracking[]>(
        `${API_URL}/trackings?date=${tracking.date}`
      );
    } else if (tracking.numberOfHours != null) {
      return this.httpClient.get<Tracking[]>(
        `${API_URL}/trackings?hours=${tracking.numberOfHours}`
      );
    }

    return this.httpClient.get<Tracking[]>(`${API_URL}/trackings`);
  }

  getFilteredByCountry(country: string) {
    return this.httpClient.get<Tracking[]>(
      `${API_URL}/trackings/filter?country=${country}`
    );
  }

  getFilteredByCityAndDate(state: string, startDate: string, endDate: string) {
    return this.httpClient.get<Tracking[]>(
      `${API_URL}/trackings/statefilter?searchState=${state}&startDateTime=${startDate}&endDateTime=${endDate}`
    );
  }

  // edit(tracking: Tracking) {
  //   let findElem = this.tracking.find((p) => p.id == tracking.id);
  //   findElem.firstName = person.firstName;
  //   findElem.age = person.age;
  //   findElem.job = person.job;
  //   this.persons$.next(this.persons);
  // }
}
