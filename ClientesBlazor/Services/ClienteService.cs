using System.Net.Http.Json;
using ClientesBlazor.Models;

namespace ClientesBlazor.Services;

public class ClienteService
{
    private readonly HttpClient _http;

    public ClienteService(HttpClient http) => _http = http;

    public async Task<List<Cliente>> ObtenerTodosAsync()
        => await _http.GetFromJsonAsync<List<Cliente>>("api/clientes") ?? new();

    public async Task<Cliente?> ObtenerPorIdAsync(int id)
        => await _http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");

    public async Task<bool> CrearAsync(Cliente c)
        => (await _http.PostAsJsonAsync("api/clientes", c)).IsSuccessStatusCode;

    public async Task<bool> ActualizarAsync(Cliente c)
        => (await _http.PutAsJsonAsync($"api/clientes/{c.Id_cliente}", c)).IsSuccessStatusCode;

    public async Task<bool> EliminarAsync(int id)
        => (await _http.DeleteAsync($"api/clientes/{id}")).IsSuccessStatusCode;
}
