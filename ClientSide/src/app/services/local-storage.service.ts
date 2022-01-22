import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  private removeStorage(key: string): boolean {
    try {
      localStorage.removeItem(key);
      localStorage.removeItem(key + '_expiresIn');
    } catch (error) {
      console.log(`Remove From Storage: Error removing key [${key}] Error -> ${error}`);
      return false;
    }
    return true;
  }

  getStorage(key: string) {
    let now = Date.now();
    let expiresIn = localStorage.getItem(key + '_expiresIn');
    if (expiresIn === undefined || expiresIn === null) {
      expiresIn = "0";
    }
    // Expired
    if (+expiresIn < now) {
      this.removeStorage(key);
      return null;
    } else {
      try {
        return localStorage.getItem(key);
      } catch (error) {
        console.log(`Get From Storage: Error removing key [${key}] Error -> ${error}`);
        return null;
      }
    }

  }



  setStorage(key: string, data: any, expires: number): boolean {
    //make sure it's positive
    expires = Math.abs(expires);

    const now = Date.now();
    const schedule = now + expires * 1000;
    try {
      localStorage.setItem(key, JSON.stringify(data));
      localStorage.setItem(key + '_expiresIn', schedule.toString());
    } catch (error) {
      console.log(`Set To Storage: Error removing key [${key}] Error -> ${error}`);
      return false;
    }
    return true;
  }


}
