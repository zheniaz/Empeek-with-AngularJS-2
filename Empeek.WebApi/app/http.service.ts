﻿import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class HttpService {

    constructor(private http: Http) { }

    getEmpeek() {
        return this.http.get('D:\USB-накопитель')
    }

}