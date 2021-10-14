namespace CarSales.CodingChallenge.Infrastructure.Response
{
    public class Response<T> : Response where T : class
    {
        public Response(T result)
        {
            SetResult(result);
        }
    }
}
