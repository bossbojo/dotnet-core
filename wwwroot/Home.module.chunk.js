webpackJsonp(["Home.module"],{

/***/ "./src/app/Pages/Home/Home.component.html":
/***/ (function(module, exports) {

module.exports = "<h3>URL Hub</h3>\nhttp://localhost:5000/notification\n<hr>\n<h3>HOW TO ConnectHub</h3>\n hubConnection = <label class=\"var\">new</label> <label class=\"method\">signalR.HubConnectionBuilder().withUrl</label>([<label class=\"var\">string</label> URL_Hub])<br>\n.<label class=\"method\">configureLogging</label>(signalR.LogLevel.Information)<br>\n.<label class=\"method\">build</label>();<br>\n<hr>\n<div class=\"row\">\n  <h3>Server Method</h3>\n  <table class=\"table\">\n    <thead class=\"thead-dark\">\n      <tr>\n        <th>Methods</th>\n        <th>Parameter</th>\n      </tr>\n    </thead>\n    <tbody>\n      <tr>\n        <td>\n          <label class=\"var\">this</label>.hubConnection <br> .<label class=\"method\">invoke</label>( \n          <label class=\"string\">'OnConnectHub'</label>,[<label class=\"var\">string</label> UserId],[<label class=\"var\">string</label> \n          Channel]) <br> .<label class=\"method\">catch</label>(\n          <label class=\"err\">err</label> => console.error(<label class=\"err\">err</label>)); <br>\n\n        </td>\n        <td>\n          <label class=\"var\">string</label> UserId : UserId ของระบบนั้นๆ <br>\n          <label class=\"var\">string</label> Chanel : Channel ที่ได้ทำการสร้างขึ้นเพื่อติดต่อ\n        </td>\n      </tr>\n    </tbody>\n  </table>\n</div>\n\n<div class=\"row\">\n  <h3>Client Method</h3>\n  <table class=\"table\">\n    <thead class=\"thead-dark\">\n      <tr>\n        <th>Methods</th>\n        <th>Parameter</th>\n      </tr>\n    </thead>\n    <tbody>\n      <tr>\n        <td>\n          <label class=\"var\">this</label>.hubConnection.<label class=\"method\">on</label>( <label class=\"string\">'ReceiveNotification'</label>, (Ojson: <label class=\"var\">string</label> ) => &#123; <br>\n          <label class=\"var\">let</label> data = <label class=\"method\">JSON</label>.parse(Ojson); <br>\n          &#125;\n        </td>\n        <td>\n          <label class=\"var\">string</label> Ojson : เป็นข้อความที่จะส่งมา หรือ เป็น json string\n        </td>\n      </tr>\n    </tbody>\n  </table>\n</div>"

/***/ }),

/***/ "./src/app/Pages/Home/Home.component.scss":
/***/ (function(module, exports) {

module.exports = ".var {\n  color: blue;\n  font-weight: bold; }\n\n.string {\n  color: green;\n  font-weight: bold; }\n\n.res {\n  color: #008080;\n  font-weight: bold; }\n\n.err {\n  color: #ff0000;\n  font-weight: bold; }\n\n.method {\n  color: #ff8000; }\n"

/***/ }),

/***/ "./src/app/Pages/Home/Home.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomeComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("./node_modules/@angular/core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var HomeComponent = /** @class */ (function () {
    function HomeComponent() {
    }
    HomeComponent.prototype.ngOnInit = function () {
    };
    HomeComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-Home',
            template: __webpack_require__("./src/app/Pages/Home/Home.component.html"),
            styles: [__webpack_require__("./src/app/Pages/Home/Home.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], HomeComponent);
    return HomeComponent;
}());



/***/ }),

/***/ "./src/app/Pages/Home/Home.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeModule", function() { return HomeModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Home_routing__ = __webpack_require__("./src/app/Pages/Home/Home.routing.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("./node_modules/@angular/core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_common__ = __webpack_require__("./node_modules/@angular/common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Home_component__ = __webpack_require__("./src/app/Pages/Home/Home.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var HomeModule = /** @class */ (function () {
    function HomeModule() {
    }
    HomeModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["I" /* NgModule */])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_2__angular_common__["b" /* CommonModule */],
                __WEBPACK_IMPORTED_MODULE_0__Home_routing__["a" /* HomeRoutes */]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_3__Home_component__["a" /* HomeComponent */]]
        })
    ], HomeModule);
    return HomeModule;
}());



/***/ }),

/***/ "./src/app/Pages/Home/Home.routing.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomeRoutes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Home_component__ = __webpack_require__("./src/app/Pages/Home/Home.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("./node_modules/@angular/router/esm5/router.js");


var routes = [
    { path: '', component: __WEBPACK_IMPORTED_MODULE_0__Home_component__["a" /* HomeComponent */] },
];
var HomeRoutes = __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* RouterModule */].forChild(routes);


/***/ })

});
//# sourceMappingURL=Home.module.chunk.js.map