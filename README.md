# Lync-Skype4Buisness
Extension methods for Lync SDK (Client side SDK) and UCMA (Server side SDK)

## Lync SDK
Lync SDK extension methods for supporting TPL and async / await.

```C#
var transferResponse = await avModality.TransferAsync(uriContactEndpoint, TransferOptions.None);
var state = transferResponse.TargetState;
```

```C#
if (conversation.SelfParticipant.CanBeMuted())
{
  await conversation.SelfParticipant.SetMuteAsync(isMuted);
}
```

## UCMA
UCMA extension methods for supporting TPL and async / await.


```C#
await _platform.StartupAsync();
await _appEndpoint.EstablishAsync();
```
