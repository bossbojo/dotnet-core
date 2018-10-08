webpackJsonp(["Simple.module"],{

/***/ "./src/app/Pages/Simple/Simple.component.html":
/***/ (function(module, exports) {

module.exports = "<form [formGroup]=\"ModelConnect\" (submit)=\"OnConnect()\">\n    <div class=\"row\">\n      <div class=\"col-6\">\n        <div class=\"form-group\">\n          <label for=\"UserId\">User ID:</label>\n          <input type=\"text\" class=\"form-control\" id=\"UserId\" formControlName=\"UserId\" >\n        </div>\n      </div>\n      <div class=\"col-6\">\n        <div class=\"form-group\">\n          <label for=\"Channel\">Chennel:</label>\n          <input type=\"text\" class=\"form-control\" id=\"Channel\" formControlName=\"Channel\" >\n        </div>\n      </div>\n      <div class=\"col-12 text-right\">\n        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\n      </div>\n    </div>\n    <hr>\n  </form>\n  <div class=\"row\">\n    <table class=\"table\">\n      <thead class=\"thead-dark\">\n        <tr>\n          <th>User ID</th>\n          <th>Channel</th>\n          <th>Messages</th>\n        </tr>\n      </thead>\n      <tbody>\n        <tr *ngFor=\"let someObjects of someObject\">\n          <td>{{someObjects.UserId}}</td>\n          <td>{{someObjects.Channel}}</td>\n          <td>\n            <code>\n                <ngx-json-viewer [json]=\"someObjects.Messages\" [expanded]=\"false\"></ngx-json-viewer>\n            </code>\n          </td>\n        </tr>\n      </tbody>\n    </table>\n  </div>"

/***/ }),

/***/ "./src/app/Pages/Simple/Simple.component.scss":
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/Pages/Simple/Simple.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SimpleComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__aspnet_signalr__ = __webpack_require__("./node_modules/@aspnet/signalr/dist/esm/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("./node_modules/@angular/core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("./node_modules/@angular/forms/esm5/forms.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var SimpleComponent = /** @class */ (function () {
    function SimpleComponent(build) {
        this.build = build;
        this.someObject = [];
        this.ModelConnect = this.build.group({
            UserId: ['253', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["d" /* Validators */].required],
            Channel: ['YourChanel', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["d" /* Validators */].required]
        });
    }
    SimpleComponent.prototype.ngOnInit = function () {
    };
    SimpleComponent.prototype.OnConnect = function () {
        var _this = this;
        this.someObject = [];
        this.hubConnection = new __WEBPACK_IMPORTED_MODULE_0__aspnet_signalr__["a" /* HubConnectionBuilder */]().withUrl('http://localhost:5000/notification').build();
        this.hubConnection.start().then(function () {
            console.log('Connection started!');
            _this.hubConnection.invoke('OnConnectHub', _this.ModelConnect.value.UserId, _this.ModelConnect.value.Channel).catch(function (err) { return console.error(err); });
        })
            .catch(function (err) {
            console.log('Error while establishing connection :(');
        });
        this.hubConnection.on('OnConnected', function (Ojson) {
            if (Ojson) {
                var data = JSON.parse(Ojson);
                if (_this.isJson(data.Item)) {
                    data.Item = JSON.parse(data.Item);
                }
                _this.someObject.push(new model_connect(_this.ModelConnect.value.UserId, _this.ModelConnect.value.Channel, data));
                console.log(_this.someObject);
            }
        });
        this.hubConnection.on('ReceiveNotification', function (Ojson) {
            if (Ojson) {
                var data = JSON.parse(Ojson);
                if (_this.isJson(data.Item)) {
                    data.Item = JSON.parse(data.Item);
                }
                _this.someObject.push(new model_connect(_this.ModelConnect.value.UserId, _this.ModelConnect.value.Channel, data));
            }
        });
    };
    SimpleComponent.prototype.isJson = function (str) {
        try {
            JSON.parse(str);
        }
        catch (e) {
            return false;
        }
        return true;
    };
    SimpleComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["n" /* Component */])({
            selector: 'app-Simple',
            template: __webpack_require__("./src/app/Pages/Simple/Simple.component.html"),
            styles: [__webpack_require__("./src/app/Pages/Simple/Simple.component.scss")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_forms__["a" /* FormBuilder */]])
    ], SimpleComponent);
    return SimpleComponent;
}());

var model_connect = /** @class */ (function () {
    function model_connect(UserId, Channel, Messages) {
        this.UserId = UserId;
        this.Channel = Channel;
        this.Messages = Messages;
    }
    return model_connect;
}());


/***/ }),

/***/ "./src/app/Pages/Simple/Simple.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SimpleModule", function() { return SimpleModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_forms__ = __webpack_require__("./node_modules/@angular/forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_ngx_json_viewer__ = __webpack_require__("./node_modules/ngx-json-viewer/ngx-json-viewer.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Simple_routing__ = __webpack_require__("./src/app/Pages/Simple/Simple.routing.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_core__ = __webpack_require__("./node_modules/@angular/core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_common__ = __webpack_require__("./node_modules/@angular/common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__Simple_component__ = __webpack_require__("./src/app/Pages/Simple/Simple.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var SimpleModule = /** @class */ (function () {
    function SimpleModule() {
    }
    SimpleModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_3__angular_core__["I" /* NgModule */])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_4__angular_common__["b" /* CommonModule */],
                __WEBPACK_IMPORTED_MODULE_2__Simple_routing__["a" /* SimpleRoutes */],
                __WEBPACK_IMPORTED_MODULE_1_ngx_json_viewer__["a" /* NgxJsonViewerModule */],
                __WEBPACK_IMPORTED_MODULE_0__angular_forms__["c" /* ReactiveFormsModule */],
                __WEBPACK_IMPORTED_MODULE_0__angular_forms__["b" /* FormsModule */],
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_5__Simple_component__["a" /* SimpleComponent */]]
        })
    ], SimpleModule);
    return SimpleModule;
}());



/***/ }),

/***/ "./src/app/Pages/Simple/Simple.routing.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SimpleRoutes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Simple_component__ = __webpack_require__("./src/app/Pages/Simple/Simple.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("./node_modules/@angular/router/esm5/router.js");


var routes = [
    { path: '', component: __WEBPACK_IMPORTED_MODULE_0__Simple_component__["a" /* SimpleComponent */] },
];
var SimpleRoutes = __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* RouterModule */].forChild(routes);


/***/ })

});
//# sourceMappingURL=Simple.module.chunk.js.map