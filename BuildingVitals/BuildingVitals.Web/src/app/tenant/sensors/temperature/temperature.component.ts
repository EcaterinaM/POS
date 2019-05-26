import { Component, OnInit } from '@angular/core';
import { Chart, ChartDatasetModel, ChartOptionsModel, LineChartColorModel, YAxisModel } from '../../../shared/components/chart/models';
import { ChartTypeConstants, ChartStyleConstants } from '../../../shared/components/chart/constants';


@Component({
  selector: 'app-temperature',
  templateUrl: './temperature.component.html',
  styleUrls: ['./temperature.component.scss']
})
export class TemperatureComponent implements OnInit{
  chart: Chart;
  chartOptions: ChartOptionsModel;

  ngOnInit(): void {
    this.buildChart();
  }

  private buildChart() {
    this.chartOptions = new ChartOptionsModel();
    this.chartOptions.title.display = true;
    this.chartOptions.scales.yAxes.push(new YAxisModel());

    this.chart = new Chart([],
      [new ChartDatasetModel([1, 2, 40, 6], 'temperature'), new ChartDatasetModel([10, 40, 80, 20], 'humidity')],
      ['Ianuarie', 'Februarie', 'Martie', 'Aprilie'],
      ChartTypeConstants.lineChart,
      'Sensor data',
      false);
  }
}