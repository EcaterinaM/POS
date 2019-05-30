export class Property {
  maxValue: string;
  maxValueDate: string;
  minValue: string;
  minValueDate: string;

  constructor(max: string, maxdate: string, min: string, mindata: string) {
    this.maxValue = max;
    this.maxValueDate = maxdate;
    this.minValue = min;
    this.minValueDate = mindata;
  }
}
