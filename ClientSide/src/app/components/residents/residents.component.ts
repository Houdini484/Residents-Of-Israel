import { Component, Input, OnInit } from '@angular/core';
import { ResidentsModel } from 'src/models/Residents.model';

@Component({
  selector: 'app-residents',
  templateUrl: './residents.component.html',
  styleUrls: ['./residents.component.scss']
})
export class ResidentsComponent implements OnInit {

  @Input()
  residents!: any;

  constructor() {
  }

  ngOnInit(): void {
  }

  
}
