import {ChartStyleConstants} from "../constants";

export class YAxisModel {
  beginAtZero: boolean = true;
  display: boolean = true;
  position: string = ChartStyleConstants.positionLeft;
  ticks = {
    suggestedMin: 0,
    suggestedMax: 0
  };
}
