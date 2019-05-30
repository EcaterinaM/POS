import { Component, OnInit } from '@angular/core';
import { Chart, ChartDatasetModel, ChartOptionsModel, LineChartColorModel, YAxisModel } from '../../../shared/components/chart/models';
import { ChartTypeConstants, ChartStyleConstants } from '../../../shared/components/chart/constants';
import { MetricService } from '../../../shared/services/model-services/metric.service';
import { Property } from '../../../shared/models/property.model';
import { SensorDataService, UserService } from '../../../shared'
import { AuthenticationHelper } from '../../../shared';
import { SensorDataList } from '../../../shared'
import { interval, Subscription } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserModel } from '../../../shared/models/user.model';

@Component({
  selector: 'app-humidity',
  templateUrl: './humidity.component.html',
  styleUrls: ['./humidity.component.scss']
})
export class HumidityComponent implements OnInit {
  chart: Chart;
  chartOptions: ChartOptionsModel;
  user: UserModel;
  username: string;
  subscription: Subscription;

  property: Property;

  constructor(private sensorDataService: SensorDataService,
    private jwtHelperService: JwtHelperService,
    private authHelper: AuthenticationHelper,
    private userService: UserService,
    private metricService: MetricService) {
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
    this.sensorDataService.getSensorData('Humidity', this.user.sensorId).subscribe((sensorData: SensorDataList) => {
      this.chartOptions = new ChartOptionsModel();
      this.chartOptions.scales.yAxes = [
        {
          ticks: {
            min: 0,
            max: 100,
            callback: (value: any) => value = value + '%'
          }
        }
      ];
      this.chartOptions.title.display = true;
      this.chart = new Chart(['#eea50a'],
        [new ChartDatasetModel(sensorData.dataList, 'Humidity', '#eea50a')],
        sensorData.dates.map(d => d.toString().replace('T', ' ')),
        ChartTypeConstants.lineChart,
        'Humidity',
        false);

      var max = sensorData.dataList.reduce((a, b) => Math.max(a, b));
      var min = sensorData.dataList.reduce((a, b) => Math.min(a, b));
      var maxPosition = sensorData.dataList.indexOf(max);
      var minPosition = sensorData.dataList.indexOf(min);

      var minDate = sensorData.dates[minPosition];
      var maxDate = sensorData.dates[maxPosition];
      this.property = new Property(max.toString(), maxDate.toString().replace('T', ' '), min.toString(), minDate.toString().replace('T', ' '));
    }
    );
  }
}
