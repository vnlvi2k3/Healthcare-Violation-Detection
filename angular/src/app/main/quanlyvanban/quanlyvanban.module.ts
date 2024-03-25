import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {QuanlyvanbanRoutingModule} from './quanlyvanban-routing.module';
import {QuanlyvanbanComponent} from './quanlyvanban.component';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table'; 
import { CreateDocumentModalComponent } from './create-document-modal.component';
import { FileUploadModule } from 'primeng/fileupload';

@NgModule({
    declarations: [QuanlyvanbanComponent, CreateDocumentModalComponent],
    // imports: [AppSharedModule, QuanlyvanbanRoutingModule, TableModule]
    imports: [
        PaginatorModule,
        TableModule, 
        AppSharedModule, QuanlyvanbanRoutingModule,
        FileUploadModule
    ], 
})
export class QuanlyvanbanModule {}
