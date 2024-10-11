using AutoMapper;
using CrudCustomers.Models.DTOs;
using Newtonsoft.Json;

public class ViaCepService : IViaCepService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public ViaCepService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public async Task<AddressDto> GetAddressByCep(string cep)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();

        var viaCepDto = JsonConvert.DeserializeObject<ViaCepDto>(json);

        var addressDto = _mapper.Map<AddressDto>(viaCepDto);

        return addressDto;
    }
}
