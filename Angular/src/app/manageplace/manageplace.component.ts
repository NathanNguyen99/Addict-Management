import {  Component, ElementRef, OnInit, ViewChild,ChangeDetectionStrategy  } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ManagePlace} from '../Shared/Models/ManagePlace';
import { ManagePlaceService } from '../Shared/Services/manageplace.service';
import { ManagePlaceDataSource } from '../Shared/Datasources/ManagePlace.Datasource';
import { fromEvent } from 'rxjs';
import { PlaceEditComponent} from './obj-edit/place-edit.component';
import { ConfirmService } from '../Shared/Services/confirm.service';
import { AlertService } from '../Shared/Services/alert.service';
import { PlacetypeData} from '../Shared/Services/DATA';
import { Sort} from '@angular/material/sort';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-manageplace',
  templateUrl: './manageplace.component.html',
  styleUrls: ['./manageplace.component.css']
})
export class ManageplaceComponent implements OnInit {

  displayedColumns = ['PlaceName', 'Address','PlaceTypeName', 'actions'];
  _Database!: ManagePlaceService;
  dataSource!: ManagePlaceDataSource;
  index: number=0;
  Oid: string='';
  
  constructor(public dialogService: MatDialog, public _Service: ManagePlaceService, private confirmSv: ConfirmService, private alertSv:AlertService) { }
  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort!: MatSort;
  @ViewChild('filter',  {static: true}) filter!: ElementRef;

  public placetypes = PlacetypeData;

  ngOnInit() {
    this.loadData();
  }

  
  private refreshTable() {
    this.paginator._changePageSize(this.paginator.pageSize);
  }

  public loadData() {
    this._Database = this._Service;//new EduLevelService(this.httpClient);
    this.dataSource = new ManagePlaceDataSource(this._Database, this.paginator, this.sort);
    fromEvent(this.filter.nativeElement, 'keyup')
      // .debounceTime(150)
      // .distinctUntilChanged()
      .subscribe(() => {
        if (!this.dataSource) {
          return;
        }
        this.dataSource.filter = this.filter.nativeElement.value;
      });
  }

  sortData(e: Sort){
    console.log(e);
  }

  startEdit(i: number, odata: ManagePlace) {
    //this.Oid = oid;
    // index row is used just for debugging proposes and can be removed
    this.index = i;
    console.log(this.index);
    const dialogRef = this.dialogService.open(PlaceEditComponent, {
      data: odata
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
        this._Service.SaveEditObject().subscribe(
          data=> {
              // When using an edit things are little different, firstly we find record inside DataService by id
            const foundIndex = this._Database!.dataChange.value.findIndex(x => x.oid === odata.oid);
            // Then you update that record using data from dialogData (values you enetered)
            this._Database!.dataChange.value[foundIndex] = this._Service.getDialogData();
            // And lastly refresh table
            this.refreshTable();
          },
          (error: any) => {
            console.log(error);
          }
        );  
      }
    });
  }

  deleteItem(i: number, odata: ManagePlace) {
    this.index = i;
    //const url = "123";

    this.confirmSv.confirm(odata.placeName, 'B???n c?? ch???c mu???n x??a m?? n??y kh??ng?')
    .subscribe(r=> {if (r === true) {
      
       this._Database.deleteRecord(odata.oid).subscribe(
        result => {
          this.success();
          // Refresh DataTable to remove row.
          this.deleteRowDataTable (i, 1, this.paginator, this.dataSource);
        },
        (err: any) => {
          console.log(err.error);
          console.log(err.message);
          this.alertSv.error('Delete did not happen.');
        }
      );
    }});

  }


  private success() {
    //this.messagesService.openDialog('Success', 'Database updated as you wished!');
    this.alertSv.error("X??a th??nh c??ng",false);
  }
  private deleteRowDataTable (recordId: any, idColumn: any, paginator: any, dataSource: any) {
    // this.dsData = dataSource.data;
    // const itemIndex = this.dsData.findIndex(obj => obj[idColumn] === recordId);
    // dataSource.data.splice(itemIndex, 1);
    // dataSource.paginator = paginator;
  }

  openAddDialog() {
    const dialogRef = this.dialogService.open(PlaceEditComponent, {
      data: {edulv: {} }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
        this._Service.SaveAddObject().subscribe(
          data=> {
            // After dialog is closed we're doing frontend updates
            // For add we're just pushing a new row inside DataService
            this._Database.dataChange.value.push(this._Service.getDialogData());
            this.refreshTable();
          },
          (error: any) => {
            console.log(error);
          }
        );  
      }
    });
  }

  public searchPlaceType(o: any): any {

  //   const url = `${this.membersUrl}/?country=${country}`;

  //   this.httpService.searchCountries(url)
  //     .subscribe(data => {
  //       this.dataLength = data.length;
  //       this.dataSource.data = data;
  //     });

  this.dataSource.filter = o.placeTypeName;
   }

}
