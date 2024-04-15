namespace Tienda.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> GetAsync<T>(string url);

        // Este Post no devuelve respuesta
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model);

        // Este Post devuelve respuesta
        Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model);

        // En el controller delete no devuelve nada por eso solo se deja <object>
        Task<HttpResponseWrapper<object>> DeleteAsyc<T>(string url);

        // La actualizacion no devuelve nada por eso <object>
        Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model);

        // Para uso futuro se recibe una respuesta una vez se actualiza el registro
        Task<HttpResponseWrapper<TActionResponse>> PutAsync<T, TActionResponse>(string url, T model);
    }
}
