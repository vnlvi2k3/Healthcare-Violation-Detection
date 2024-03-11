import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { VanBanPhapLyServiceProxy, VanBanPhapLyListDto, ListResultDtoOfVanBanPhapLyListDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './legaltext.component.html',
    animations: [appModuleAnimation()]
})
export class LegalTextComponent extends AppComponentBase implements OnInit {

    text: VanBanPhapLyListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _vanbanphaplyService: VanBanPhapLyServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getText();
    }

    getText(): void {
        this._vanbanphaplyService.getVanBanPhapLy(this.filter).subscribe((result) => {
            this.text = result.items;
        });
    }
}
