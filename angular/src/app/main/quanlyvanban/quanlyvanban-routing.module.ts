import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {QuanlyvanbanComponent} from './quanlyvanban.component';

const routes: Routes = [{
    path: '',
    component: QuanlyvanbanComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class QuanlyvanbanRoutingModule {}
