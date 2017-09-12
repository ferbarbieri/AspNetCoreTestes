import { Component, OnInit } from '@angular/core';
import { ObjetivoService } from "./objetivo.service";
import { NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-objetivo',
  templateUrl: './objetivo.component.html',
  styleUrls: ['./objetivo.component.css']
})
export class ObjetivoComponent implements OnInit {

  modalId = 'hoplaModal';

  ngOnInit() {
    this.data = this.getObjetivos();
    setTimeout(this.showPage, 1500);
  }

  constructor(private objetivoService: ObjetivoService, private modalService: NgbModal) { }

  modalOption: NgbModalOptions = {};
  closeResult: string;
  data: any;

  private getObjetivos() {
    //debugger;
    return this.objetivoService.getObjetivos()
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

  open(content: any) {
    this.modalOption.backdrop = 'static';
    //this.modalOption.keyboard = false;
    this.modalService.open(content, this.modalOption).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}