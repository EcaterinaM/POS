import { ChartStyleConstants } from '../constants';

export class ChartTitleModel {
  position: string = ChartStyleConstants.positionTop;
  display: boolean = true;
  text: string = '';
  fontFamily: string = ChartStyleConstants.fontFamily;
  fontSize: number = 28;
  fontColor: string = '#C7C7C7';
  fontStyle: string = ChartStyleConstants.fontStyle;
  padding: number = ChartStyleConstants.padding;
}
