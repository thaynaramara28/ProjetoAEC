using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http;using ProjetoAEC.Servcos;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProjetoAEC.Models;
using ProjetoAEC;

  namespace ProjetoAEC.Servicos
  {

      
  
public class CepApiService
  {
    public static async Task<List<Candidato>> GetCandidatos()
    {
      HttpClient http = new HttpClient();
      var response = await http.GetAsync($"{Program.ApiHost}/candidatos");
      if(response.IsSuccessStatusCode)
      {
        var resultado = response.Content.ReadAsStringAsync().Result;
        var candidatos = JsonConvert.DeserializeObject<List<Candidato>>(resultado);
        return candidatos;
      }

      return new List<Candidato>();
    }
  }
  }

