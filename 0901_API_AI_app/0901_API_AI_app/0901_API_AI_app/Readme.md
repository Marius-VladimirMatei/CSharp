# _0901_API_AI_app

WPF chat assistant using OpenAI Chat Completion API (gpt-3.5-turbo).  
Uses MVVM pattern, config in `appsettings.json`, and OpenAI REST API via HttpClient.

## NuGet Packages used

| Package | Version |
|---------|---------|
| Microsoft.Extensions.Configuration | 9.0.6 |
| Microsoft.Extensions.Configuration.Binder | 9.0.6 |
| Microsoft.Extensions.Configuration.Json | 9.0.6 |
| Newtonsoft.Json | 13.0.3 |

## Build

- .NET 8.0  
- TargetFramework: `net8.0-windows10.0.19041.0`  
- WPF app

## Usage

- API Key + model configured in `appsettings.json`:

```json
{
  "OpenAiSettings": {
    "ApiKey": "sk-proj-xxxxxx",
    "ChatModel": "gpt-3.5-turbo"
  }
}
