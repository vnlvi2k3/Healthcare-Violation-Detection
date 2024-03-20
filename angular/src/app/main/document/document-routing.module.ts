import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {documentComponent} from './document.component';

const routes: Routes = [{
    path: '',
    component: documentComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class documentRoutingModule {}