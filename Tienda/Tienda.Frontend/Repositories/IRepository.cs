namespace Tienda.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> GetAsync<T>(string url);

        // Este Post no devuelve respuesta
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model);

        // Este Post devuelve respuesta
        Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model);

    }
}
