import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DocumentServiceProxy, DocumentListDto, ListResultDtoOfDocumentListDto } from '@shared/service-proxies/service-proxies';
import { HttpClient } from '@angular/common/http';
import { AppConsts } from '@shared/AppConsts';

@Component({
    templateUrl: './document.component.html',
    styleUrls: ['./document.component.css'],
    animations: [appModuleAnimation()]
})

export class DocumentComponent extends AppComponentBase {

    documents: DocumentListDto[] = [];
    filter: string = '';
    downloadUrl: string;

    constructor(
        injector: Injector,
        private _documentService: DocumentServiceProxy,
        private _httpClient: HttpClient
    ) {
        super(injector);
        this.downloadUrl = AppConsts.remoteServiceBaseUrl + '/FileUpload/DownloadFile'
    }

    ngOnInit(): void {
        this.getDocument();
    }

    getDocument(): void {
        this._documentService.getDocument(this.filter).subscribe((result) => {
            this.documents = result.items;
        });
    }

    downloadFile(fileName: string){
        this._httpClient
            .get<any>(this.downloadUrl + `?fileName=${fileName}`, {responseType: 'blob' as 'json'})
            .subscribe((response: Blob) => {
                const downloadURL = window.URL.createObjectURL(response);
                const link = document.createElement('a');
                link.href = downloadURL;
                link.download = fileName;
                link.click();
                URL.revokeObjectURL(downloadURL);
            })
    }
    previewFile(fileName: string){
        this._httpClient
            .get<any>(this.downloadUrl + `?fileName=${fileName}`, {responseType: 'blob' as 'json'})
            .subscribe((response: Blob) => {
                const downloadURL = window.URL.createObjectURL(response);
                window.open(downloadURL, '_blank');
                URL.revokeObjectURL(downloadURL);
            })
    }

}
