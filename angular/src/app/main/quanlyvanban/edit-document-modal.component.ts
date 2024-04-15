import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { DocumentServiceProxy , CreateDocumentInput} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { HttpClient } from '@angular/common/http';
import { AppConsts } from '@shared/AppConsts';
import { DateTime } from 'luxon';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'editDocumentModal',
    templateUrl: './edit-document-modal.component.html'
})

export class EditDocumentModalComponent extends AppComponentBase {
    // Add your component logic here
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal' , { static: false }) modal: ModalDirective;
    @ViewChild('nameInput' , { static: false }) nameInput: ElementRef;

    document: CreateDocumentInput = new CreateDocumentInput();

    active: boolean = false;
    saving: boolean = false;

    uploadUrl: string;
    uploadFiles: any[] = [];

    isDuplicated: boolean = false;
    fileUploaded: boolean = false;

    constructor(
        injector: Injector,
        private _documentService: DocumentServiceProxy,
        private _httpClient: HttpClient
    ) {
        super(injector);
        this.uploadUrl = AppConsts.remoteServiceBaseUrl + '/FileUpload/UploadFile'
    }

    convertDate(isoDate: DateTime): string {
        const date = new Date(isoDate.toISO()); // Convert isoDate to a Date object
        const datePipe = new DatePipe('en-US');
        return datePipe.transform(date, 'dd/MM/yyyy');
        // return date;
    }

    show(documentId): void{
        this.active = true;
        this._documentService.getDocumentForEdit(documentId).subscribe((result) => {
            this.document = result;
            console.log(this.document.expiration);
            this.modal.show();
        });
    }

    onShown(): void{
        
    }

    save(): void{
        this.saving = true;
        this._documentService.editDocument(this.document)
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(this.document);
            });
        this.saving = false;
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }   

    uploadFile(data: {files: File}): void {
        const formData: FormData = new FormData();
        const file = data.files[0];
        formData.append('file', file, file.name);
        this._httpClient.post<any>(this.uploadUrl, formData).subscribe(response => {
            // set fullText to response.result
            this.document.fullText = response.result;
        })
        this.fileUploaded = true;
    }
    removeFile(): void {
        this.fileUploaded = false;
    }
    onBeforeSend(event): void {
        event.xhr.setRequestHeader('Authorization','Bearer ' + abp.auth.getToken())
    }

    isValidCode(): boolean {
        const code = this.document.code;
        const pattern = /\d+\/[A-ZĐĐ]+-[A-ZĐĐ]+$/;
        return pattern.test(code);
    }

    checkDup(): void {
        this._documentService.getDocument(this.document.code).subscribe((result) => {
          // Inside the subscription callback, set the isDuplicated flag
        this.isDuplicated = result.items.length > 0;
        //   window.alert(result.items.length); // You can remove this alert if not needed
        });
      }
}
