namespace TechStore.Domain.Entities
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; } = true;
        public string StatusMessage { get; set; } = "Request complete succesfully";
        public T? objectResponse { get; set; }
    }
}
