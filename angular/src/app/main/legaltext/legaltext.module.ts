import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {LegalTextRoutingModule} from './legaltext-routing.module';
import {LegalTextComponent} from './legaltext.component';
import { CreateLegalTextModalComponent } from './create-legaltext-modal.component';

import { CreateLegalTextModalComponent } from './create-legaltext-modal.component';

@NgModule({
    declarations: [LegalTextComponent, CreateLegalTextModalComponent],
    imports: [AppSharedModule, LegalTextRoutingModule]
})
export class LegalTextModule {}
