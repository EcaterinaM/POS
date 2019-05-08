export class LineChartColorModel {
  borderColor: string;
  fill: boolean;
  pointBorderWidth: number;

  constructor(borderColor: string, fill: boolean = false, pointBorderWidth: number = 6) {
    this.borderColor = borderColor;
    this.fill = fill;
    this.pointBorderWidth = pointBorderWidth;
  }
}
