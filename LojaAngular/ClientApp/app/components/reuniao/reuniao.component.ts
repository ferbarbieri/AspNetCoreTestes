import { Component, OnInit } from '@angular/core';
import { ReuniaoService } from "./reuniao.service";

@Component({
  selector: 'app-reuniao',
  templateUrl: './reuniao.component.html',
  styleUrls: ['./reuniao.component.css']
})
export class ReuniaoComponent implements OnInit {

  ngOnInit() {
    this.data = this.getPlano();
    setTimeout(this.showPage, 1500);
  }

  constructor(private reuniaoService: ReuniaoService) { }

  data: any;

  private getPlano() {
    //debugger;
    return this.reuniaoService.getReuniao()
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
