import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ISkillDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent {

  @Input() skill: ISkillDto; 
   
  @Output() skillForDeleted: EventEmitter<number> = new EventEmitter<number>();
  
  deleteSkill()
  {
   this.skillForDeleted.emit(this.skill.id);
  }
}
