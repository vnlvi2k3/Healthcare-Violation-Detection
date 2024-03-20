import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DocumentServiceProxy } from '@shared/service-proxies/service-proxies';
import { remove as _remove } from 'lodash-es';

@Component({
    templateUrl: './document.component.html',
    animations: [appModuleAnimation()]
})

export class documentComponent extends AppComponentBase {
    constructor(
        injector: Injector,
        private _DocumentService: DocumentServiceProxy
    ) {
        super(injector);
    }
    deleteDocument(ID: number): void {
        this.message.confirm(
            this.l('AreYouSureToDeleteThisDocument', ID),  "",
            isConfirmed => {
                if (isConfirmed) {
                    this._DocumentService.deleteDocument(ID).subscribe(() => {
                        this.notify.info(this.l('SuccessfullyDeleted'));
                        // _remove(this.people, person);
                    });
                }
            }
        );
    }
    restoreDocument(ID: number): void {
        this.message.confirm(
            this.l('AreYouSureToRestoreThisDocument', ID),  "",
            isConfirmed => {
                if (isConfirmed) {
                    this._DocumentService.restoreDocument(ID).subscribe(() => {
                        this.notify.info(this.l('SuccessfullyRestored'));
                        // _remove(this.people, person);
                    });
                }
            }
        );
    }
}
