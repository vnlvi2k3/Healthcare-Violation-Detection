import { Component, Injector, OnInit, ViewChild, ViewEncapsulation, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DocumentServiceProxy, DocumentListDto, ListResultDtoOfDocumentListDto } from '@shared/service-proxies/service-proxies';
import { NgForm } from '@angular/forms';
import { DateTime } from 'luxon';
import { BrowserModule } from '@angular/platform-browser';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { TableModule } from 'primeng/table';
import { HttpClient } from '@angular/common/http';
import { AppConsts } from '@shared/AppConsts';
import * as moment from 'moment';
import { remove as _remove } from 'lodash-es';
import { DatePipe } from '@angular/common';

@Component({
    templateUrl: './quanlyvanban.component.html',
    animations: [appModuleAnimation()]
})

export class QuanlyvanbanComponent extends AppComponentBase implements OnInit {

  data: DocumentListDto[] = [];
  filter: string = '';
  validDate: string = '';
  expireDate: string = '';
  showAdvancedSearch: boolean = false; // Variable to control the visibility of advanced search inputs
  previewUrl: string;
  downloadUrl: string;

  constructor(
      injector: Injector,
      private _documentService: DocumentServiceProxy,
      private _httpClient: HttpClient
  ) {
      super(injector);
      this.previewUrl= AppConsts.remoteServiceBaseUrl + '/FileUpload/DownloadFile';
      this.downloadUrl = AppConsts.remoteServiceBaseUrl + '/FileUpload/DownloadFile';
  }

  convertDate(isoDate: DateTime): string {
    const date = new Date(isoDate.toISO()); // Convert isoDate to a Date object
    const datePipe = new DatePipe('en-US');
    return datePipe.transform(date, 'dd/MM/yyyy');
  }

  ngOnInit(): void {
    this.getDoc();
  }

    // Method to filter the documents based on the search text
    // filterDocs(): void {
    // // Convert the search text to lowercase for case-insensitive search
    // const searchTextLower = this.searchText1.toLowerCase();
    // // Filter the documents based on the search text
    // this.doc = this.doc.filter(doc =>
    // doc.fullText.toLowerCase().includes(searchTextLower) ||
    // doc.type.toLowerCase().includes(searchTextLower) ||
    // doc.docID.toLowerCase().includes(searchTextLower)
    // );
    // }

      // Function to toggle the visibility of advanced search inputs
  toggleAdvancedSearch(): void {
    this.showAdvancedSearch = !this.showAdvancedSearch;
    this.filter = '';
    this.validDate = '';
    this.expireDate = '';
    this.getSearch();
  }

  // Function to perform basic search
  getSearch(): void{
    if((this.validDate != '') && (this.expireDate == '' || this.expireDate == null)){
      this._documentService.search(this.filter, 1, this.validDate, this.expireDate).subscribe((result) => {
          this.data = result.items;
      })
    }
    else if((this.validDate == '' || this.validDate == null) && this.expireDate != ''){
      this._documentService.search(this.filter, 2, this.validDate, this.expireDate).subscribe((result) => {
          this.data = result.items;
      })
    }
    else if(this.validDate != '' && this.expireDate != ''){
      this._documentService.search(this.filter, 3, this.validDate, this.expireDate).subscribe((result) => {
          this.data = result.items;
      })
    }
    else{
      this._documentService.search(this.filter, 0, this.validDate, this.expireDate).subscribe((result) => {
          this.data = result.items;
      })
    }
  }

  // Assuming 'docs' is your array of documents
  getDocumentCount(): number {
        // Return the count of documents based on a specific property, for example 'docID'
        return this.data.length;
  }
    
  // first: number = 0;

  // rows: number = 10;

  // displayedDocs: DocListDto[];
    
  getDoc(): void {
    this._documentService.getDocument(this.filter).subscribe((result) => {
        this.data = result.items;
        // console.log(this.convertDate(this.data[0].validation));
        // this.updateDisplayedDocuments();
    });
  }

  // onPageChange(event) {
  //     this.first = event.first;
  //     this.rows = event.rows;
  //     this.updateDisplayedDocuments();
  //     this.getDoc();
  // }

  // updateDisplayedDocuments() {
  //     this.displayedDocs = this.doc.slice(this.first, this.first + this.rows);
  // }
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
          .get<any>(this.previewUrl + `?fileName=${fileName}`, {responseType: 'blob' as 'json'})
          .subscribe((response: Blob) => {
              const previewUrl = window.URL.createObjectURL(response);
              window.open(previewUrl, '_blank');
              URL.revokeObjectURL(previewUrl);
          })
  }

  deleteDocument(doc: DocumentListDto): void {
    this.message.confirm(
        this.l('Are You Sure To Delete The Document', doc.id),'',
        (isConfirmed) => {
            if(isConfirmed){
                this._documentService.deleteDocument(doc.id).subscribe(() => {
                    this.notify.info(this.l('SuccessfullyDeleted'));
                });
            }
        }
    )
  }
}
