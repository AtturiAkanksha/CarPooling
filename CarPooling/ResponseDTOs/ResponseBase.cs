namespace CarPooling.API.ResponseDTOs
{
    public class ResponseBase<T>
    {
        public T Response {get; set;}
        public string Message { get; set;}
    }
}
