import { HttpBaseService } from "../base/http.base.service";
import { InjectorHttpService } from "../base/http.injector.service";
import { Inject } from "@angular/core";
import { APIConfig } from "../app/app.config";
import { environment } from "../../environments/environment";

export class ObjetivoService extends HttpBaseService {
    constructor( @Inject(InjectorHttpService) public injectorHttpService: InjectorHttpService) {
        super(injectorHttpService, APIConfig.Sites.Portal.Recursos.Objetivos, environment.Api.Objetivos.baseUrl);
    }

    //Exemplo
    public getObjetivos() {
        return this.getAll();
    }
}