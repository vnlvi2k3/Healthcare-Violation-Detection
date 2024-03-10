import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LegalTextComponent} from './legaltext.component';

const routes: Routes = [{
    path: '',
    component: LegalTextComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class LegalTextRoutingModule {}
