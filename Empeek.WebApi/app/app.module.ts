import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { DiskComponent } from './Components/disk-component/disk.component';
import { DirComponent } from './Components/dir-component/dir.component';
import { CountSizeComponent } from './Components/count-size-component/count-size.component';

import { HttpModule } from '@angular/http';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],
    declarations: [AppComponent, DiskComponent, DirComponent, CountSizeComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }