using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Services.Models
{
  public class MenuListResult
  {
    [JsonPropertyName("4")]
    public MenuListSport Menu { get; set; }
  }

  public class MenuListSport
  {
    [JsonPropertyName("menusLevel1More")]
    public IList<MenuListEntry> MenusLevel1More { get; set; }

    [JsonPropertyName("menusLevel1")]
    public IList<MenuListEntry> MenusLevel1 { get; set; }
  }

  public class MenuListEntry
  {
    [JsonPropertyName("nodeId")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
  }
}
