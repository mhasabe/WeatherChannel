import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
        this.error = "";
        this.locationInfo = "";
    }
    DataService.prototype.getLocationDetail = function (location) {
        var _this = this;
        return this.http.get("api/location/" + location).pipe(map(function (data) {
            _this.locationInfo = data;
            return true;
        }), catchError(function (error) {
            _this.error = error.error;
            return throwError(error.error);
        }));
    };
    DataService = tslib_1.__decorate([
        Injectable({
            providedIn: "root"
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], DataService);
    return DataService;
}());
export { DataService };
//# sourceMappingURL=dataService.js.map