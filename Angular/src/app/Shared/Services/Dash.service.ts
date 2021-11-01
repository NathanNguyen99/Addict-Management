import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { baseService } from './base.service';
import { AppConfig } from '../../Config/config';
import { Helpers } from '../../Helpers/helpers';
import { Dash01,Dash02, Dash03, Dash04, Dash05 } from '../Models/DashBoard';
@Injectable()
export class DashBoardService extends baseService {
  private pathAPI = this.config.setting['PathAPI'];
  constructor(private http: HttpClient, private config: AppConfig, helper: Helpers) { super(helper); }
  /** GET heroes from the server */
  getDashBoard01 (): Observable<Dash01[]> {
    return this.http.get<Dash01[]>(this.pathAPI + 'dash/DB01', super.header());//.pipe(catchError(super.handleError));
  }  

  getDashBoard02 (): Observable<Dash02[]> {
    return this.http.get<Dash02[]>(this.pathAPI + 'dash/DB02', super.header());//.pipe(catchError(super.handleError));
  }  

  getDashBoard03 (): Observable<Dash03[]> {
    return this.http.get<Dash03[]>(this.pathAPI + 'dash/DB03', super.header());//.pipe(catchError(super.handleError));
  }  

  getDashBoard04 (): Observable<Dash04[]> {
    return this.http.get<Dash04[]>(this.pathAPI + 'dash/DB04', super.header());//.pipe(catchError(super.handleError));
  }  

  getDashBoard05 (): Observable<Dash05[]> {
    return this.http.get<Dash05[]>(this.pathAPI + 'dash/DB05', super.header());//.pipe(catchError(super.handleError));
  }  
}