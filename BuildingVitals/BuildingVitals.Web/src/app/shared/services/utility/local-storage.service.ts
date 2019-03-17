import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  getItem(key: string): string {
    return localStorage.getItem(key);
  }

  setItem(key: string, value: string | number): void {
    localStorage.setItem(key, value.toString());
  }

  clearAll(): void {
    localStorage.clear();
  }
}
