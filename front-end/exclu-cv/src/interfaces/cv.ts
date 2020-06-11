import { IMainInformation, ISkill } from './main';
import { IEducation } from './education';
import { IWorkExperience } from './work-experience';

export interface ICv {
    id: number,
    main_information: IMainInformation,
    skills: Array<ISkill>,
    educations: Array<IEducation>,
    work_experiences: Array<IWorkExperience>
}