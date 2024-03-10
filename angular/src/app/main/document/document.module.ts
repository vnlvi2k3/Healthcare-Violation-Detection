import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {DocumentRoutingModule} from './document-routing.module';
import {DocumentComponent} from './document.component';

@NgModule({
    declarations: [DocumentComponent],
    imports: [AppSharedModule, DocumentRoutingModule]
})
export class DocumentModule {}
