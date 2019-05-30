import { Component, OnInit } from '@angular/core';
import { Chart, ChartDatasetModel, ChartOptionsModel, LineChartColorModel, YAxisModel } from '../../../shared/components/chart/models';
import { ChartTypeConstants, ChartStyleConstants } from '../../../shared/components/chart/constants';
import { MetricService} from '../../../shared/services/model-services/metric.service';
import { Property } from '../../../shared/models/property.model';

@Component({
  selector: 'app-humidity',
  templateUrl: './humidity.component.html',
  styleUrls: ['./humidity.component.scss']
})
export class HumidityComponent implements OnInit {
  chart: Chart;
  chartOptions: ChartOptionsModel;

  property: Property;
  constructor(private metricService: MetricService) {
  }

  ngOnInit(): void {
    this.buildChart();

    this.getHumidityMaxMin();
  }

  private getHumidityMaxMin() {
    this.metricService.getPropertyMaxMin('humidity', 'A04416B5-1DB0-404C-B3EE-434FF611A8C5')
      .subscribe((result: Property) => {
        this.property = new Property(result.maxValue, result.maxValueDate,
          result.minValue, result.minValueDate);
        console.log(this.property);
      });
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
