import { Component, Input, OnInit, Inject, forwardRef } from '@angular/core';
import * as jQuery from 'jquery';
import { Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map'
import { EventoService } from "./evento.service";
import { NavComponent } from "../nav/nav.component";

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})
export class EventoComponent implements OnInit {

  ngOnInit() {
    this.data = this.getEvents();
    setTimeout(this.showPage(), 1500);
    this._nav = new NavComponent(this.eventService);
  }

  constructor(private eventService: EventoService) { }

  _nav: NavComponent;
  data: any;
  objeto: any;

  private getEvents() {
    //debugger;
    return this.eventService.getAll()
      .subscribe(data => {
        this.data = data;
      });
  }

  resizeFooter(positionCollapse: string, positionCollapseActivity: string) {
    if (positionCollapse == 'open' && positionCollapseActivity == 'closed') {
      $('#footerBar').css({ width: "81%" });
    } else if (positionCollapse == 'closed' && positionCollapseActivity == 'open') {
      $('#footerBar').css({ width: "81%" });
    } else if (positionCollapse == 'closed' && positionCollapseActivity == 'closed') {
      $('#footerBar').css({ width: "100%" });
    } else {
      $('#footerBar').css({ width: "65%" });
    }
  }

  showPage() {
    document.getElementById("starter-template").style.display = "block";
    document.getElementById("loader").style.display = "none";
  }

  atualizarNav(conteudo: any) {
  //  this.eventService.teste()
   //   .subscribe(data => {
    //    this.objeto = data;
      //});
    console.log(conteudo);
    //debugger;

    this.eventService.atualizarNav(conteudo);
    //this.ms.popularTela(this.objeto);
  }
}
