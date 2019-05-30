export class ChartDatasetModel {
  data: number[];
  label: string;
  backgroundColor?: string;

  constructor(data: number[], label: string, backgroundColor: string) {
    this.data = data;
    this.label = label;
    this.backgroundColor = backgroundColor;
  }
}
