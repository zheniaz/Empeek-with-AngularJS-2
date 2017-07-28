import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { HttpService } from './http.service';

@Component({
    selector: 'empeek-app',
    templateUrl: 'app/app.component.html',
    styles: [
        `.invisibleDisk{display:none;}
        .invisibleDir{display:none;}
        .invisibleSize{display:none;}`
    ]

})
export class AppComponent implements OnInit {
    name: string = 'zhenia';

    queryEmpeek: string;

    constructor(private httpService: HttpService) { }

    ngOnInit() {
        this.httpService.getEmpeek().subscribe((data: Response) => this.queryEmpeek);
    }




    // hide/show div-element section
    visibilityDisk: boolean = true;
    visibilityDir: boolean = true;
    visibilitySize: boolean = true;

    toggleDisk() {
        this.visibilityDisk = !this.visibilityDisk;
    }

    toggleDir() {
        this.visibilityDir = !this.visibilityDir;
    }

    toggleSize() {
        this.visibilitySize = !this.visibilitySize;
    }
}