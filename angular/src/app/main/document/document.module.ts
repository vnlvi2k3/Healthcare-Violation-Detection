import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {documentRoutingModule} from './document-routing.module';
import {documentComponent} from './document.component';

@NgModule({
    declarations: [documentComponent],
    imports: [AppSharedModule, documentRoutingModule]
})
export class documentModule {}
