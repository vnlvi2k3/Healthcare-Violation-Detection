import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { VanBanPhapLyServiceProxy, VanBanPhapLyListDto, ListResultDtoOfVanBanPhapLyListDto, DocumentServiceProxy, DocumentListDto } from '@shared/service-proxies/service-proxies';
import { result } from 'lodash-es';
import { DateTime } from 'luxon';

@Component({
    templateUrl: './legaltext.component.html',
    animations: [appModuleAnimation()]
})
export class LegalTextComponent extends AppComponentBase implements OnInit {

    text: VanBanPhapLyListDto[] = [];
    data: DocumentListDto[] = [];
    filter: string = '';
    validDate: string = '';
    expireDate: string = '';
    searchData: string = '';

export class LegalTextComponent extends AppComponentBase implements OnInit {

    text: VanBanPhapLyListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _vanbanphaplyService: VanBanPhapLyServiceProxy,
        private _documentService: DocumentServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getText();
    }

    getText(): void {
        // this._vanbanphaplyService.getVanBanPhapLy(this.filter).subscribe((result) => {
        //     this.text = result.items;
        // });
        this._documentService.getDocument(this.filter).subscribe((result) => {
            this.data = result.items;
        })
    }

    showDateRange: boolean = false
    toggleAdvancedSearch() {
        this.showDateRange = !this.showDateRange;
        this.validDate = '';
        this.expireDate = '';
        this.searchData = '';
    }

    getSearch(): void{
        if((this.validDate != '') && (this.expireDate == '')){
            this._documentService.search(this.searchData, 1, this.validDate, this.expireDate).subscribe((result) => {
                this.data = result.items;
            })
        }
        else if(this.validDate == '' && this.expireDate != ''){
            this._documentService.search(this.searchData, 2, this.validDate, this.expireDate).subscribe((result) => {
                this.data = result.items;
            })
        }
        else if(this.validDate != '' && this.expireDate != ''){
            this._documentService.search(this.searchData, 3, this.validDate, this.expireDate).subscribe((result) => {
                this.data = result.items;
            })
        }
        else{
            this._documentService.search(this.searchData, 0, this.validDate, this.expireDate).subscribe((result) => {
                this.data = result.items;
            })
        }
    }
}
