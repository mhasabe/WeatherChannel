import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError, EMPTY, Observable } from 'rxjs'
import { map, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: "root"
})
export class DataService {

    constructor(private http: HttpClient) { }

    public error = "";
    public locationInfo = "";

    getLocationDetail(location: string) {
        return this.http.get("api/location/" + location).pipe(map((data: string) => {
            this.locationInfo = data;
            return true;
        }), catchError((error: HttpErrorResponse) => {
                this.error =  error.error;
                return throwError(error.error);
        }));
    }


}