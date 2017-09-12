import { Injectable, Inject } from '@angular/core';
import { InterceptorService } from 'ng2-interceptors';

import { HttpService } from './http.service';
import { APIConfig } from '../app/app.config';
import { InjectorHttpService } from './http.injector.service';

@Injectable()
export abstract class HttpBaseService extends HttpService {

    private header = APIConfig.Header;
    protected urlBase: string;
    protected recurso = {
        default: "",
        buscar: "",
        exportar: ""
    };

    constructor(injectorHttpService: InjectorHttpService, recurso: any, urlBase: string) {
        super(injectorHttpService.http);

        this.urlBase = urlBase;
        this.recurso.default = recurso.default;
        this.recurso.buscar = recurso.buscar;
        this.recurso.exportar = recurso.exportar;
    }

    getAll() {
        //debugger;
        return this._getAll(this.urlBase + this.recurso.default);
        //return this._getAll(this.urlBase);
    }

    getById(id:any) {
        return this._getById(id, (this.urlBase + this.recurso.default), this.header.ContentType.json);
    }

    post(obj: any) {
        return this._post(obj, (this.urlBase + this.recurso.default), this.header.ContentType.json);
    }

    put(id: number, obj: any) {
        return this._put(id, obj, (this.urlBase + this.recurso.default), this.header.ContentType.json);
    }

    patch(id: number, obj: any) {
        return this._patch(id, obj, (this.urlBase + this.recurso.default), this.header.ContentType.json);
    }
}