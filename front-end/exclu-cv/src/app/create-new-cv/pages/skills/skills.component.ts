import { GlobalConstants } from './../../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder } from '@angular/forms';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { ExclucvServiceService } from 'src/services/exclucv-service.service';
import { ISkill } from 'src/interfaces/main';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss'],
})
export class SkillsComponent implements OnInit {
  isSubmitted = false;
  localStorageSkills: any;
  skillsForm: FormGroup;

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  skill: ISkill;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  skills: Array<ISkill>;

  constructor(
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private service: ExclucvServiceService
  ) {}

  ngOnInit(): void {
    this.skillsForm = this.formBuilder.group({});

    this.service.getAllSkills().subscribe((response) => {
      this.skills = response;
      console.log(response);
    });
  }

  onSubmit(data): any {
    this.isSubmitted = true;

    GlobalConstants.cv['skills'].push(data);

    this.localStorageSkills = GlobalConstants.cv['skills'];

    localStorage.setItem('cv', JSON.stringify(GlobalConstants.cv));
    this.toastr.success('Successfully saved!');
  }

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    console.log(this.skills);

    // Add our fruit
    if ((value || '').trim()) {
      let skl: ISkill = { skill1: value };

      if (this.skills === undefined) {
        this.skills = Array<ISkill>();
      }

      this.skills.push(skl);
      console.log(skl);

      this.service.addSkill(skl).subscribe((response) => {
        console.log(response);
      });
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(skill: any): void {
    console.log(skill.skillId);
    this.service.deleteSkill(skill.skillId).subscribe((response) => {
      console.log(response);
    });

    const index = this.skills.indexOf(skill);
    if (index >= 0) {
      this.skills.splice(index, 1);
    }
  }
}
