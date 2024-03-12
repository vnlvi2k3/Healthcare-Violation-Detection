import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DocumentServiceProxy, DocumentListDto, ListResultDtoOfDocumentListDto } from '@shared/service-proxies/service-proxies';


@Component({
    templateUrl: './document.component.html',
    animations: [appModuleAnimation()]
})

export class DocumentComponent extends AppComponentBase{

    document: DocumentListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _documentService: DocumentServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getDocument();
    }

    getDocument(): void {
        this._documentService.getDocument(this.filter).subscribe((result) => {
            this.document = result.items;
        });
    }


}
