import { Component, OnInit } from '@angular/core';
import { CarreiraService } from "./carreira.service";

@Component({
  selector: 'app-carreira',
  templateUrl: './carreira.component.html',
  styleUrls: ['./carreira.component.css']
})
export class CarreiraComponent implements OnInit {

  ngOnInit() {
    this.data = this.getPlano();
    setTimeout(this.showPage, 1500);
  }

  constructor(private carreiraService: CarreiraService) { }

  data: any;

  private getPlano() {
    //debugger;
    return this.carreiraService.getPlano()
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
}
