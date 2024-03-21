import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {DocumentRoutingModule} from './document-routing.module';
import {DocumentComponent} from './document.component';
import { UploadFileModalComponent } from './upload-document/upload-document.component';
import { FileUploadModule } from 'primeng/fileupload';
@NgModule({
    declarations: [DocumentComponent, UploadFileModalComponent],
    imports: [AppSharedModule, DocumentRoutingModule, FileUploadModule]
})
export class DocumentModule {}
