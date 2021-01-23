export interface IEducation {
  start_date: Date;
  end_date?: Date;
  institution: string;
  class: string;
  degree: string;
  is_active?: boolean;
}
