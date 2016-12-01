﻿using System.Threading.Tasks;
using Microsoft.Rtc.Collaboration;

namespace LyncAsyncExtensionMethods
{
  internal static class ApplicationEndpointMethods
  {
    public static Task DrainAsync(this 
            ApplicationEndpoint endpoint)
    {
      return Task.Factory.FromAsync(
          endpoint.BeginDrain,
          endpoint.EndDrain, null);
    }
  }
}
