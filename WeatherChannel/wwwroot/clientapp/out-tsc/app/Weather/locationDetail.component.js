import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { DataService } from '../Shared/dataService';
var LocationDetail = /** @class */ (function () {
    function LocationDetail(service) {
        this.service = service;
        this.error = "";
        this.locationInfo = "";
        this.zipcode = "";
    }
    LocationDetail.prototype.getLocationDetail = function () {
        var _this = this;
        this.service.getLocationDetail(this.zipcode).subscribe(function (success) {
            _this.locationInfo = _this.service.locationInfo;
            _this.error = "";
        }, function (error) {
            _this.locationInfo = "";
            _this.error = "" + error + "";
        });
    };
    LocationDetail = tslib_1.__decorate([
        Component({
            selector: "location-detail",
            templateUrl: "locationDetail.component.html"
        }),
        tslib_1.__metadata("design:paramtypes", [DataService])
    ], LocationDetail);
    return LocationDetail;
}());
export { LocationDetail };
//# sourceMappingURL=locationDetail.component.js.map