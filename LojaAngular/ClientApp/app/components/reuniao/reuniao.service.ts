import { HttpBaseService } from "../base/http.base.service";
import { InjectorHttpService } from "../base/http.injector.service";
import { Inject } from "@angular/core";
import { APIConfig } from "../app/app.config";
import { environment } from "../../environments/environment";

export class ReuniaoService extends HttpBaseService {
    constructor( @Inject(InjectorHttpService) public injectorHttpService: InjectorHttpService) {
        super(injectorHttpService, APIConfig.Sites.Portal.Recursos.Reunioes, environment.Api.Reunioes.baseUrl);
    }

    //Exemplo
    public getReuniao() {
        return this.getAll();
    }
}