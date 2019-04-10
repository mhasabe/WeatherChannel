import { Component } from '@angular/core';
import { DataService } from '../Shared/dataService';
import { HttpErrorResponse } from '@angular/common/http';
import { take } from 'rxjs/operators';

@Component({
    selector: "location-detail",
    templateUrl: "locationDetail.component.html"
})
export class LocationDetail {

    constructor(private service: DataService) {

    }

    error:string=""
    locationInfo: string = "";
    zipcode: string = "";

    getLocationDetail(): void {
        this.service.getLocationDetail(this.zipcode).subscribe(success => {
            this.locationInfo = this.service.locationInfo;
            this.error = "";
        }, (error: HttpErrorResponse) => {
            this.locationInfo = "";
            this.error = "" + error +"";
        });
    }

}