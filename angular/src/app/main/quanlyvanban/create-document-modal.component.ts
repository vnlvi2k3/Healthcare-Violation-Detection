import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { DocumentServiceProxy, CreateDocumentInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { AppConsts } from '@shared/AppConsts';

@Component({
    selector: 'createDocumentModal',
    templateUrl: './create-document-modal.component.html'
})
export class CreateDocumentModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal' , { static: false }) modal: ModalDirective;
    @ViewChild('nameInput' , { static: false }) nameInput: ElementRef;

    document: CreateDocumentInput = new CreateDocumentInput();

    active: boolean = false;
    saving: boolean = false;

    uploadUrl: string;
    uploadFiles: any[] = [];

    constructor(
        injector: Injector,
        private _documentService: DocumentServiceProxy,
        private _httpClient: HttpClient
    ) {
        super(injector);
        this.uploadUrl = AppConsts.remoteServiceBaseUrl + '/FileUpload/UploadFile'
    }

    show(): void {
        this.active = true;
        this.document = new CreateDocumentInput();
        this.modal.show();
    }

    onShown(): void {

    }

    save(): void {
        this.saving = true;
        this._documentService.createDocument(this.document)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(this.document);
            });
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }

    uploadFile(data: {files: File}): void {
        const formData: FormData = new FormData();
        const file = data.files[0];
        console.log(file)
        formData.append('file', file, file.name);
        this._httpClient.post<any>(this.uploadUrl, formData).subscribe(response => {
            // set fullText to response.result
            this.document.fullText = response.result;
        })
    }
    onBeforeSend(event): void {
        event.xhr.setRequestHeader('Authorization','Bearer ' + abp.auth.getToken())
    }
}
