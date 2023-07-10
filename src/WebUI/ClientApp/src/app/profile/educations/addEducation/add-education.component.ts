import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IEducation, IEducationDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-add-education',
  templateUrl: './add-education.component.html',
  styleUrls: ['./add-education.component.css']
})
export class AddEducationComponent {

  @Output() selectdEducation: EventEmitter<string> = new EventEmitter<string>();

  @Output() _listFilter: EventEmitter<string> = new EventEmitter<string>(); //output
  
  @Input() filteredEducations : IEducationDto[] = []; //input

  v: string = '';

  public set listFilter(v : string) {
      this._listFilter.emit(v);
      this.v = v;
  }
  
  
  chosenEducation: string ='';
  chooseEducation(education: IEducationDto) {
      this.chosenEducation = education.title;
  }

  openD() {
    const modal = document.querySelector('.modalDialogAE') as HTMLElement;
    modal.style.opacity = '1';
    modal.style.pointerEvents = 'auto';
    this.listFilter='';
  }
  
  closeD(){
    const modal = document.querySelector('.modalDialogAE') as HTMLElement;
    modal.style.opacity = '0';
    modal.style.pointerEvents = 'none';
    this.filteredEducations = [];
  }

  saveEducation()
  {
      this.v !=' ' &&  this.selectdEducation.emit((this.chosenEducation == '' ? this.v : this.chosenEducation));
      this.chosenEducation = '';
  }
}
