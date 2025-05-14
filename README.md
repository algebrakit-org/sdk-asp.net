# sdk-asp.net

## How to Run the Demo App

1. Ensure you have the .NET SDK installed on your system. You can verify this by running:
   ```bash
   dotnet --version
   ```
   If not installed, download it from [Microsoft's .NET website](https://dotnet.microsoft.com/).

2. Navigate to the root directory of the project:
   ```bash
   cd /Users/martijnslob/github/sdk-asp.net
   ```

3. Build the solution to ensure all dependencies are resolved:
   ```bash
   dotnet build sdk-asp.net.sln
   ```

4. Run the demo application (ensure you replace `your-api-key-here` in the code with your actual API key):
   ```bash
   dotnet run --project DemoApp/DemoApp.csproj
   ```

The demo app will initialize the SDK, create a session for a specific exercise, and log the session ID and scoring results to the console.

---

## How to Use the SDK

The SDK provides a simple interface for interacting with the AlgebraKit API. Below is an example of how to use the SDK in your own application:

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