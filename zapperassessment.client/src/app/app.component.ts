import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  settingInput: string = '';
  settingId: string = '';
  isUserSettingValid: any | null = null; 

  constructor(private http: HttpClient) {}

  ngOnInit() {

  }

  getUserSettingConfirmation() {
    const url = `https://localhost:7248/api/UserSetting/GetUserSettingConfirmation?settingInput=${this.settingInput}&settingId=${this.settingId}`;
    this.http.get(url).subscribe(
      (result) => {
        this.isUserSettingValid = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  
  validateSettingInput(event: any): void {
    const input = event.target.value;
    const filteredInput = input.replace(/[^01]/g, '');
    event.target.value = filteredInput;

    if (filteredInput.length > 8) {
      event.target.value = filteredInput.substring(0, 8);
    }

    this.settingInput = event.target.value;
  }
  
  validateSettingId(event: any): void {
    const input = event.target.value;
    const filteredInput = input.replace(/[^1-8]/g, '');
    event.target.value = filteredInput;

    if (filteredInput.length > 1) {
      event.target.value = filteredInput.substring(0, 1);
    }

    this.settingId = event.target.value;
  }

  title = 'zapperassessment.client';
}
