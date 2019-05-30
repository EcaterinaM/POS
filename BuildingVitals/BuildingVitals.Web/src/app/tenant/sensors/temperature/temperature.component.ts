import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

import { Chart, ChartDatasetModel, ChartOptionsModel, LineChartColorModel, YAxisModel } from '../../../shared/components/chart/models';
import { ChartTypeConstants, ChartStyleConstants } from '../../../shared/components/chart/constants';

import { SensorDataService, UserService } from '../../../shared'
import { AuthenticationHelper } from '../../../shared';
import { SensorDataList } from '../../../shared'
import { UserModel } from 'src/app/shared/models/user.model';
import { interval, Subscription } from 'rxjs';
@Component({
  selector: 'app-temperature',
  templateUrl: './temperature.component.html',
  styleUrls: ['./temperature.component.scss']
})
export class TemperatureComponent {
  chart: Chart;
  chartOptions: ChartOptionsModel;
  chartData: SensorDataList;
  username: string;
  user: UserModel;
  
  subscription: Subscription;

  constructor(private sensorDataService: SensorDataService,
    private jwtHelperService: JwtHelperService,
    private authHelper: AuthenticationHelper,
    private userService: UserService){
  }

  ngOnInit(): void {
    let token = this.authHelper.getUserTokens().accessToken;
    this.username = this.jwtHelperService.decodeToken(token)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    this.userService.getUserDetails(this.username).subscribe((res) => {
      this.user = res;
    this.buildChart();

    });

    const source = interval(60000);
    this.subscription = source.subscribe(val => this.buildChart());
  }

  private buildChart() {
    this.sensorDataService.getSensorData('Temperature', this.user.sensorId).subscribe((sensorData: SensorDataList) => {
      this.chartOptions = new ChartOptionsModel();
      this.chartOptions.title.display = true;
      this.chartOptions.scales.yAxes.push(new YAxisModel());
      this.chart = new Chart([],
        [new ChartDatasetModel(sensorData.dataList, 'Temperature')],
        sensorData.dates.map(d => d.toString().replace('T', ' ')),
        ChartTypeConstants.lineChart,
        'Temperature',
        false);
    }
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
