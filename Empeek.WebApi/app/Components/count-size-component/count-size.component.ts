import { Component } from '@angular/core';

@Component({
    selector: 'empeek-count-app',
    templateUrl: 'app/components/count-size-component/count-size.component.html'
})
export class CountSizeComponent {
    countSize: string = 'count size from component';
}