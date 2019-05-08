import { Component, Input, OnChanges, ViewChild } from '@angular/core';

import { BaseChartDirective } from 'ng2-charts';

import {
  ChartOptionsModel,
  ChartDatasetModel
  } from './models';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html'
})
export class ChartComponent implements OnChanges {
  @ViewChild(BaseChartDirective)
  private chart: BaseChartDirective;
  @ViewChild('chart') graphCanvasElement;

  @Input('type') chartType: string;
  @Input('colors') colors: any[];
  @Input('data') data: ChartDatasetModel[];
  @Input('labels') labels: Array<any>;
  @Input('legend') legend: boolean;
  @Input('options') options: ChartOptionsModel;
  @Input('title') title: string;

  chartData: any = {};

  ngOnChanges(): void {
    this.options.title.text = this.title;

    this.chartData = this.data;
  }
}
