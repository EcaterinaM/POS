import { PathServicesConstants } from './path-services.constants';

export class NotAuthorizedRoutesConstants {
  static readonly routes = [
    PathServicesConstants.tokenServicePath,
    PathServicesConstants.refreshTokenServicePath
  ]
}
