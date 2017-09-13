import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { CounterComponent } from './components/counter/counter.component';
import { NavComponent } from "./components/nav/nav.component";
import { EventoComponent } from "./components/evento/evento.component";
import { FooterComponent } from "./components/footer/footer.component";
import { EventoService } from "./components/evento/evento.service";
import { InjectorHttpService } from "./components/base/http.injector.service";
import { HttpInterceptorModule } from "./components/base/http.interceptor.module";
import { ObjetivoComponent } from "./components/objetivo/objetivo.component";
import { ObjetivoService } from "./components/objetivo/objetivo.service";
import { NgbModal, NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CarreiraComponent } from "./components/carreira/carreira.component";
import { ReuniaoComponent } from "./components/reuniao/reuniao.component";
import { CarreiraService } from "./components/carreira/carreira.service";
import { ReuniaoService } from "./components/reuniao/reuniao.service";

@NgModule({
    declarations: [
        AppComponent,
        CounterComponent,
        NavComponent,
        EventoComponent,
        FooterComponent,
        ObjetivoComponent,
        CarreiraComponent,
        ReuniaoComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        HttpInterceptorModule,
        FormsModule,
        NgbModule.forRoot(),
        RouterModule.forRoot([
            { path: '', component: EventoComponent },
            { path: 'objetivos', component: ObjetivoComponent },
            { path: 'carreira', component: CarreiraComponent },
            { path: 'reunioes', component: ReuniaoComponent },
            { path: 'desempenho', component: EventoComponent },
            { path: 'feedbacks', component: EventoComponent },
        ])
    ],
    providers: [
        InjectorHttpService,
        EventoService,
        ObjetivoService,
        ReuniaoService,
        CarreiraService
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
