# sdk-asp.net

## How to Run the Demos

### CLI Demo

Demonstrates SDK API calls with text output.

1. Ensure you have the .NET SDK installed on your system. You can verify this by running:
   ```bash
   dotnet --version
   ```
   If not installed, download it from [Microsoft's .NET website](https://dotnet.microsoft.com/).

2. Build the solution:
   ```bash
   dotnet build sdk-asp.net.sln
   ```

3. Set your API key as an environment variable and run:
   ```bash
   # PowerShell
   $env:ALGEBRAKIT_API_KEY = "your-api-key"
   dotnet run --project DemoApp/DemoApp.csproj
   ```
   ```bash
   # bash
   ALGEBRAKIT_API_KEY="your-api-key" dotnet run --project DemoApp/DemoApp.csproj
   ```

### Web Demo

Renders a working Algebrakit exercise in the browser.

1. Update the configuration in `PlayExercise/Pages/Index.cshtml.cs`:
   ```csharp
   private const string ApiKey     = "your-actual-api-key";
   private const string ApiUrl     = "https://api.algebrakit.com";
   private const string WidgetUrl  = "https://widgets.algebrakit.com";
   ```

2. Run the web demo:
   ```bash
   dotnet run --project PlayExercise/PlayExercise.csproj
   ```

3. Open the URL shown in the terminal (e.g., `http://localhost:5000`) in your browser.

---

## How to Use the SDK

The SDK provides a simple interface for interacting with the Algebrakit API. Below is an example of how to use the SDK in your own application:

1. Add a reference to the `AlgebrakitSDK` project in your .NET solution.

2. Initialize the `SessionService` with an `HttpClient`:
   ```csharp
   using System;
   using System.Net.Http;
   using AlgebrakitSDK.Services;
   using AlgebrakitSDK.Models.Requests;
   using AlgebrakitSDK.Models.Responses;

   var httpClient = new HttpClient { BaseAddress = new Uri("https://api.algebrakit.com") };
   var sessionService = new SessionService(httpClient);
   ```

3. Create a session for an exercise:
   ```csharp
   var createSessionRequest = new CreateSessionRequest
   {
       Exercises = new List<Exercise>
       {
           new Exercise { ExerciseId = "your-exercise-id" }
       }
   };

   var createSessionResponse = await sessionService.CreateSessionAsync(createSessionRequest);
   if (createSessionResponse.Success)
   {
       Console.WriteLine("Session created successfully.");
   }
   ```

4. Retrieve scoring results for a session:
   ```csharp
   var sessionScoreRequest = new SessionScoreRequest { SessionId = "your-session-id" };
   var sessionScoreResponse = await sessionService.GetSessionScoreAsync(sessionScoreRequest);

   if (sessionScoreResponse.Success)
   {
       foreach (var question in sessionScoreResponse.Questions)
       {
           Console.WriteLine($"Question: {question.Id}, Marks Earned: {question.Scoring.MarksEarned}, Total Marks: {question.Scoring.MarksTotal}");
       }
   }
   ```

For more details, refer to the source code and comments in the SDK classes.