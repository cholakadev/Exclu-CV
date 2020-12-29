import { environment } from './../environments/environment';
import { IDepartment, ILevel, ISkill } from './../interfaces/main';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICv } from 'src/interfaces/cv';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ExclucvServiceService {
  private baseUrl = environment.exclucv.baseUrl;

  constructor(private _http: HttpClient) {}

  getAllCvs(): Observable<Array<ICv>> {
    return this._http.get<Array<ICv>>(this.baseUrl + '/user/cv');
  }

  getAllDepartments(): Observable<IDepartment[]> {
    return this._http.get<IDepartment[]>(this.baseUrl + '/main/departments');
  }

  getAllLevels(): Observable<ILevel[]> {
    return this._http.get<ILevel[]>(this.baseUrl + '/main/levels');
  }

  createCv(data: ICv): Observable<ICv> {
    return this._http.post<ICv>(this.baseUrl + '/user/cv', data);
  }

  getAllSkills(): Observable<Array<ISkill>> {
    return this._http.get<Array<ISkill>>(this.baseUrl + '/skills/all');
  }

  deleteCv(id: number): Observable<any> {
    return this._http.delete<any>(this.baseUrl + `/user/cv/${id}`);
  }
}
