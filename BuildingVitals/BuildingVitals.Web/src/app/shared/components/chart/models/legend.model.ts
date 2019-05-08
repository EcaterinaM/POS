import { ChartStyleConstants } from '../constants';
import { LabelsModel } from './labels.model';

export class LegendModel {
  display = true;
  position: string = ChartStyleConstants.positionTop;
  labels: LabelsModel = new LabelsModel();
}
