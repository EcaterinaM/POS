import { LegendModel } from './legend.model';
import { ChartTitleModel } from './chart-title.model';
import { ScalesModel } from './scales.model';

export class ChartOptionsModel {
  legend: LegendModel = new LegendModel();
  title: ChartTitleModel = new ChartTitleModel();
  responsive = true;
  scales: ScalesModel = new ScalesModel();
}
