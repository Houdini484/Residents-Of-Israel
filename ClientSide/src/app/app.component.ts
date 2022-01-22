import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ResidentsModel } from 'src/models/Residents.model';
import { LocalStorageService } from './services/local-storage.service';
import { ResidentsService } from './services/residents.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'תושבים בישראל';

  residents: ResidentsModel[];
  searchForm: FormGroup;
  cityName: string = '';

  constructor(
    private residentsService: ResidentsService,
    private localStorageService: LocalStorageService,

  ) {
    this.searchForm = new FormGroup({
      cityName: new FormControl(this.cityName, Validators.required)
    });
    this.residents = [];
  }
  ngOnInit(): void {
  }

  async getAllResidents() {
    await this.residentsService.getAllResidents().subscribe((r: ResidentsModel[]) => {
      this.residents = r;
    });
  }

  async getAllResidentsByName() {
    const name = this.searchForm.get('cityName')?.value;
    if (name) {
      const residentFromStorage = this.localStorageService.getStorage(name);
      if (residentFromStorage == null) {
        await this.residentsService.getAllResidentsByName(name).subscribe((r: ResidentsModel[]) => {
          this.residents = r;
          this.localStorageService.setStorage(name, (r[0]), 1000)
        });;
      }
      else {
        this.residents = [];
        this.residents.push(JSON.parse(residentFromStorage));
      }
    }
  }

}
