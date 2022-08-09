import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { CountryFilter } from 'src/app/models/CountryFilter';
import { TrackingsService } from 'src/app/services/trackings.service';
import { Subject } from 'rxjs';
import { ObservableService } from 'src/app/services/observable.service';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss'],
})
export class CountryComponent implements OnInit {
  private currentCountry = '';
  private routeSub: Subscription = new Subscription();
  dataSource: CountryFilter[] = [];
  private subject = new Subject();
  private subscription: Subscription = new Subscription();
  message: string = '';
  approvalText: string = '';
  currentItem = 'Television';
  @Input() item = [];
  @Output() newItemEvent = new EventEmitter<string>();

  items: string[] = [];

  addItem(newItem: string) {
    this.items.push(newItem);
  }

  constructor(
    private trackingService: TrackingsService,
    private route: ActivatedRoute,
    private appService: ObservableService
  ) {}

  displayedColumns: string[] = [
    'name',
    'description',
    'date',
    'numberofhours',
    'countyName',
  ];

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe((params) => {
      this.currentCountry = params['country'];
      console.log(this.currentCountry);
      this.trackingService
        .getFilteredByCountry(this.currentCountry)
        .subscribe((tracking) => {
          this.dataSource = tracking;
          console.log(tracking);
        });
    });
  }

  submit() {
    console.log(this.approvalText);
    this.appService.updateApprovalMessage(this.approvalText);
  }

  public openPDF(): void {
    let DATA: any = document.getElementById('htmlData');
    let DATATWO: any = document.getElementById('htmlDataTwo');
    html2canvas(DATA).then((canvas) => {
      let fileWidth = 208;
      let fileHeight = (canvas.height * fileWidth) / canvas.width;
      const FILEURI = canvas.toDataURL('image/png');
      let PDF = new jsPDF('p', 'mm', 'a4');
      let position = 0;
      PDF.addImage(FILEURI, 'PNG', 0, position, fileWidth, fileHeight);
      PDF.save('FilteredbyCountry.pdf');
    });
  }
}
