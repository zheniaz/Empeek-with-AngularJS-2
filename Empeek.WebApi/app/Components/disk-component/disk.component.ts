import { Component } from '@angular/core';

@Component({
    selector: 'empeek-disk-app',
    templateUrl: 'app/Components/disk-component/disk.component.html'
})
export class DiskComponent {
    disk:string = 'disk from component';
}