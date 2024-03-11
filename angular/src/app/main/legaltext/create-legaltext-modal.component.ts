import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
// import { ModalDirective } from 'ngx-bootstrap';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { VanBanPhapLyServiceProxy, CreateVanBanPhapLyInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'createTextModal',
    templateUrl: './create-legaltext-modal.component.html'
})
export class CreateLegalTextModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal' , { static: false }) modal: ModalDirective;
    @ViewChild('nameInput' , { static: false }) nameInput: ElementRef;

    vanbanphaply: CreateVanBanPhapLyInput = new CreateVanBanPhapLyInput();

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _personService: VanBanPhapLyServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.vanbanphaply = new CreateVanBanPhapLyInput();
        this.modal.show();
    }

    onShown(): void {
        this.nameInput.nativeElement.focus();
    }

    save(): void {
        this.saving = true;
        this._personService.createVanBanPhapLy(this.vanbanphaply)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('Saved Successfully'));
                this.close();
                this.modalSave.emit(this.vanbanphaply);
            });
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}
