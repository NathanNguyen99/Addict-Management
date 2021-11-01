import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { AddictClassifyService } from '../../Shared/Services/addictclassify.service';
import { FormControl, Validators } from '@angular/forms';
import { AddictClassify } from '../../Shared/Models/AddictClassify'
import { ClassifyService } from 'src/app/Shared/Services/classify.service';
import { addictService } from 'src/app/Shared/Services/addict.service';
@Component({
  selector: 'app-addict-classify-edit',
  templateUrl: './addictclassify-edit.component.html',
  styleUrls: ['./addictclassify-edit.component.css']
})
export class AddictClassifyEditComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AddictClassifyEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddictClassify,
    public dataService: AddictClassifyService,
    private classifyService: ClassifyService,
    private addictservice: addictService ) { }

    classifyData : any;
    addictData : any;
    addictSearch : any ;
formControl = new FormControl('', [
Validators.required
// Validators.email,
]);

getErrorMessage() {
return this.formControl.hasError('required') ? 'Required field' :'';
}

ngOnInit() {
  this.loadClassifys();
  this.loadAddicts();
}



public loadClassifys() {    
  this.classifyService.getAll().subscribe(data=> {
    //console.log(data);
     this.classifyData = data      
    }, err => console.log(err));    
}

public loadAddicts() {    
  this.addictservice.getBaseFieldAddicts().subscribe((data: any)=> {
     this.addictData = data     
     this.addictSearch = this.addictData.slice();
    }, (err: any) => console.log(err));    
}

submit() {
// emppty stuff
}

onNoClick(): void {
this.dialogRef.close();
}

public confirmAdd(): void {
this.dataService.addObject(this.data);
}

stopEdit(): void {
  this.dataService.updateObject(this.data);
}

selectChange($event: any) {
  //console.log($event);
  
}

}
