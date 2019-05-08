import { ChartDatasetModel } from "./chart-dataset.model";

export class Chart {
  colors: any[];
  chartData: ChartDatasetModel[];
  chartLabels: string[] = [];
  chartType: string;
  chartTitle: string;
  showChartLegend: boolean;

  constructor(colors: any[], chartData: ChartDatasetModel[], chartLabels: string[], chartType: string, chartTitle: string,
    showChartLegend: boolean) {
    this.colors = colors;
    this.chartData = chartData;
    this.chartLabels = chartLabels;
    this.chartType = chartType;
    this.chartTitle = chartTitle;
    this.showChartLegend = showChartLegend;
  }
}
