import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {LegalTextRoutingModule} from './legaltext-routing.module';
import {LegalTextComponent} from './legaltext.component';

@NgModule({
    declarations: [LegalTextComponent],
    imports: [AppSharedModule, LegalTextRoutingModule]
})
export class LegalTextModule {}
