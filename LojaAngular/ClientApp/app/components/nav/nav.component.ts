import { Component, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { EventoService } from "../evento/evento.service";
import { EventoComponent } from "../evento/evento.component";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  animations: [
    trigger('collapse', [
      state('open', style({
        opacity: '1',
        display: 'block',
        transform: 'translate3d(0, 0, 0)'
      })),
      state('closed', style({
        opacity: '0',
        display: 'none',
        transform: 'translate3d(0, -100%, 0)'
      })),
      transition('closed => open', animate('200ms ease-in')),
      transition('open => closed', animate('100ms ease-out'))
    ])
  ]
})
export class NavComponent implements OnInit{
  //show:boolean = false;
  collapse: string = "closed";
  collapseActivities: string = "closed";
  

  ngOnInit() {
    //this.popularTela();
  }

  constructor(private eventoService: EventoService) {
  }

  evento = new EventoComponent(this.eventoService);

  toggleCollapse() {
    //debugger;
    // this.show = !this.show
    this.collapse = this.collapse == "open" ? 'closed' : 'open';
    this.evento.resizeFooter(this.collapse, this.collapseActivities);
  }

  toggleCollapseActivities() {
    this.collapseActivities = this.collapseActivities == "open" ? 'closed' : 'open';
    this.evento.resizeFooter(this.collapse, this.collapseActivities);
  }
}
