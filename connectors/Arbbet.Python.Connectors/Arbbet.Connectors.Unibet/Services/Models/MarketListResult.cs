using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Services.Models
{
  public class MarketListResult
  {
    [JsonPropertyName("marketNames")]
    public MarketNames MarketNames { get; set; }
  }

  public class MarketNames
  {
    [JsonPropertyName("Paris spéciaux")]
    public IList<MarketDetail> Paris_Speciaux { get; set; }

    [JsonPropertyName("Fun Bets")]
    public IList<MarketDetail> Fun_Bets { get; set; }

    [JsonPropertyName("2ème MT")]
    public IList<MarketDetail> Second_MT { get; set; }

    [JsonPropertyName("Buteurs")]
    public IList<MarketDetail> Buteurs { get; set; }

    [JsonPropertyName("Compétition")]
    public IList<MarketDetail> Competition { get; set; }

    [JsonPropertyName("1ère MT")]
    public IList<MarketDetail> First_MT { get; set; }

    [JsonPropertyName("Buts par équipe")]
    public IList<MarketDetail> Buts_Equipe { get; set; }

    [JsonPropertyName("Scores")]
    public IList<MarketDetail> Scores { get; set; }

    [JsonPropertyName("Résultat")]
    public IList<MarketDetail> Resultat { get; set; }

    [JsonPropertyName("Combo")]
    public IList<MarketDetail> Combo { get; set; }

    [JsonPropertyName("Buts")]
    public IList<MarketDetail> Buts { get; set; }

    [JsonPropertyName("Minutes")]
    public IList<MarketDetail> Minutes { get; set; }
  }

  public class MarketDetail
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }
  }
}
