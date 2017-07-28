import { Component } from '@angular/core';

@Component({
    selector: 'empeek-dir-app',
    templateUrl: 'app/Components/dir-component/dir.component.html'
})
export class DirComponent {
    dir:string = 'dir from component';
}