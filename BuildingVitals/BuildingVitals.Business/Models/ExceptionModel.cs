namespace BuildingVitals.BusinessContracts.Models
{
    public class ExceptionModel
    {
        public string Message { get; set; }

        public ExceptionModel() { }

        public ExceptionModel(string message)
        {
            Message = message;
        }
    }
}
