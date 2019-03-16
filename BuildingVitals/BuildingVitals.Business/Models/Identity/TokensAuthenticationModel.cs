namespace BuildingVitals.BusinessContracts.Models.Identity
{
    public class TokensAuthenticationModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string LoginProvider { get; set; }
    }
}
