import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { CreateEducationCommand, CreateSkillCommand, EducationsClient, ICreateEducationCommand, ICreateSkillCommand, IEducationDto, ISkillDto, IUpdateEducationCommand, IUpdateSkillCommand, IUserDto, SkillsClient, UpdateEducationCommand, UpdateSkillCommand, UserDto, UsersClient } from '../web-api-client';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Store, select } from '@ngrx/store';
import { setUser } from '../stateManagement/user.actions';
import { selectUser } from '../stateManagement/user.selectors';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit
{
    public isAuthenticated?: Observable<boolean>;
    skills: ISkillDto[] = [];
    filteredSKills : ISkillDto[] = [];
    filteredEducations: IEducationDto[] = [];
    // subSKill!: Subscription;
    // subUser!: Subscription;
    subEducation!: Subscription;
    educations: IEducationDto[] = [];
    user: IUserDto | undefined;
    myUser: IUserDto | undefined;
    user$!: Observable<IUserDto>;
    userId: number;
    lenOfSkills: number = 2;
    lenOfEducations: number = 2;
    
    constructor(private store: Store,private skillsClinet: SkillsClient, private usersClient: UsersClient, private educationsClient: EducationsClient, private authorizeService: AuthorizeService)
    {
      this.isAuthenticated = this.authorizeService.isAuthenticated();
      this.authorizeService.getUserInfo().subscribe({
        next: data => {
          this.user = data;
          if(data.profileImage)
          {
            this.user.profileImage = `https://localhost:44447/api/Images/${data.profileImage}`;
          } else {
          this.user.profileImage = 'https://localhost:44447/api/Images/f08c0eb9-cdde-471c-af59-a83005ea784f_Screenshot_٢٠٢٠-٠٩-٢٠-١٦-٤٤-١١.png';
          }
          this.store.dispatch(setUser({ user: this.user }));
        } 
      });
    }
    
    ngOnInit() :void {    

      this.store.pipe(select(selectUser)).subscribe({
        next: (data) => {
          if (data) {
            this.userId = data.id;
          }
        },
      });

      setTimeout(() => {
        this.skillsClinet.getSkillsWithPagination(this.userId, 1, 40).subscribe({
          next: (skills) => {
            this.skills = skills.items;
            this.lenOfSkills = skills.totalCount;
            this.textskillbutton =  `Show all ${this.lenOfSkills} skills`;
          },
        });
      }, 100);

      setTimeout(() => {
        this.educationsClient.getEducationsWithPagination(this.userId,1, 40).subscribe(
          {
              next: data => {
              this.educations = data.items;
              this.lenOfEducations = data.totalCount;
              this.textEducationbutton = `Show all ${data.totalCount} educations`;
              }
          });
      }, 100);

    }

    // ngOnDestroy(): void {
    //     // this.subSKill.unsubscribe();
    //     // this.subUser.unsubscribe();
    //     console.log("sun observable is finshed");
    // }


    //skills
    showAllSkills: boolean = false;
    textskillbutton: string =  `Show all ${this.lenOfSkills} skills`;
    toggleSkills() {
        this.showAllSkills = !this.showAllSkills;
        this.textskillbutton = this.showAllSkills? 'Hide' : `Show all ${this.lenOfSkills} skills`;
        
    }

    addSkill(skill: string) {
        console.log(`the skill ${skill} is added`);
        let entity: ICreateSkillCommand = {
          title : skill,
          userId : this.user.id
        }
        this.skillsClinet.create(entity as CreateSkillCommand).subscribe()
    }

    deleteSkill(id: number)
    {
        this.skillsClinet.delete(id).subscribe();
    }
    searchSkills(skill: string)
    {
        this.skillsClinet.search(skill).subscribe({
          next: data =>
          this.filteredSKills = data.items
        });
    }
    // skills end

    //education start
    showAllEducations: boolean = false;
    textEducationbutton: string = '';
    toggleEducations() {
        this.showAllEducations = !this.showAllEducations;
        this.textEducationbutton = this.showAllEducations ? 'Hide' : `Show all ${this.lenOfEducations} educations`;
    }

    addEducation(education: string)
    {
      let entity: ICreateEducationCommand = {
        title : education,
        level: 'test',
        userId : this.user.id
      }
      this.educationsClient.create(entity as CreateEducationCommand).subscribe()    
    }

    edu: IEducationDto = {
        id: 0,
        title: 'empty',
        level: 'empty'
    };

    chosenEducation(education: IEducationDto)
    {
        this.edu = education;
    }

    updateEducation(education: IEducationDto)
    {
      let entity: IUpdateEducationCommand = {
        id: education.id,
        title: education.title,
        level: education.level,
        userId: this.user.id
      }
      this.educationsClient.update(education.id ,entity as UpdateEducationCommand).subscribe();
    }

    searchEducation(education: string)
    {
      this.educationsClient.search(education).subscribe({
        next: data =>
        this.filteredEducations = data.items
      });
    }

    deleteEducation(id: number)
    {
       this.educationsClient.delete(id).subscribe();
    }



    openDSkill() {
      const modal = document.querySelector('.modalDialogAS') as HTMLElement;
      modal.style.opacity = '1';
      modal.style.pointerEvents = 'auto';
    }
    
    openDEducation() {
      const modal = document.querySelector('.modalDialogAE') as HTMLElement;
      modal.style.opacity = '1';
      modal.style.pointerEvents = 'auto';
    }
}

