export class ChartDatasetModel {
  data: number[];
  label: string;
  backgroundColor?: string;

  constructor(data: number[], label: string) {
    this.data = data;
    this.label = label;
  }
}
