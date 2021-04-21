using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Entities;

namespace Arbbet.Connectors.Domain.Statistics
{
  public class StatisticService
  {
    private Statistic _bets = new Statistic();
    private Statistic _countries = new Statistic();
    private Statistic _competitions = new Statistic();
    private Statistic _events = new Statistic();
    private Statistic _outcomes = new Statistic();
    private Statistic _sports = new Statistic();
    private Statistic _teams = new Statistic();

    private IDictionary<Type, Statistic> _statistics = new Dictionary<Type, Statistic>()
    {
      { typeof(Bet), new Statistic() },
      { typeof(Competition), new Statistic() },
      { typeof(Country), new Statistic() },
      { typeof(Event), new Statistic() },
      { typeof(Outcome), new Statistic() },
      { typeof(Sport), new Statistic() },
      { typeof(Team), new Statistic() },
    };

    public StatisticService()
    {
    }

    public void Add(StatisticEvent eventType, Type entityType)
    {
      if (_statistics.ContainsKey(entityType))
      {
        switch (eventType)
        {
          case StatisticEvent.Create:
            _statistics[entityType].Created += 1;
            break;
          case StatisticEvent.Update:
            _statistics[entityType].Updated += 1;
            break;
          case StatisticEvent.Delete:
            _statistics[entityType].Deleted += 1;
            break;
          case StatisticEvent.Retrieve:
            _statistics[entityType].Retrieved += 1;
            break;
          default:
            throw new ArgumentException("StatisticEvent not recognized", nameof(eventType));
        }
      }
      else
      {
        throw new ArgumentException("Type not recognized", nameof(entityType));
      }
    }

    public IDictionary<Type, Statistic> GetStatistics()
    {
      return _statistics;
    }

    public string GetStatisticsString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (KeyValuePair<Type, Statistic> item in _statistics)
      {
        sb.AppendLine($"{item.Key.Name}: {item.Value.Created} created, {item.Value.Updated} updated, {item.Value.Deleted} deleted, {item.Value.Retrieved} retrieved");
      }

      return sb.ToString();
    }
  }
}
