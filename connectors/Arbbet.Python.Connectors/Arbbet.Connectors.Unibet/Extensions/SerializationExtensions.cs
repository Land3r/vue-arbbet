﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Extensions
{
  public static partial class SerializationExtensions
  {
    public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject, JsonSerializerOptions options = default)
        => JsonSerializer.Deserialize<T>(json, options);

    public static ValueTask<TValue> DeserializeAnonymousTypeAsync<TValue>(Stream stream, TValue anonymousTypeObject, JsonSerializerOptions options = default, CancellationToken cancellationToken = default)
        => JsonSerializer.DeserializeAsync<TValue>(stream, options, cancellationToken); // Method to deserialize from a stream added for completeness
  }
}
