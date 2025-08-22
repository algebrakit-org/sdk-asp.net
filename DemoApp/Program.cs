using AlgebrakitSDK.Models.Requests;
using AlgebrakitSDK.Models.Responses;
using AlgebrakitSDK.Services;
using System;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AlgebrakitSDK.Models.Shared;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Define the exercise ID as a constant
            const string exerciseId = "fa42e943-8213-41a6-8a91-8c22a929ffe9";

            // Initialize the HttpClient and SessionService with API key
            using var httpClient = new HttpClient { BaseAddress = new Uri("https://api.algebrakit.com") };
            var apiKey = "YWxnZWJyYWtpdC5DTVMtTWFydGlqbi42YTQzMGM1ZjRiZTQxZGExMmVhNjc3NTU1OTNlY2IwMDg3YzczMTQ2Nzk5ZDdiNmIyNmE2NWJmNWFiZjY2NjgyYjkzY2ZmMTcxMzM5ODQ2NzQ3MWIyOWNiNjdlZWQxZjg="; // Replace with your actual API key
            var sessionService = new SessionService(httpClient, apiKey);

            try
            {
                // Read published info for the exercise
                var exerciseInfoResponse = await sessionService.GetExerciseInfoAsync(new ExerciseInfoRequest { Id = exerciseId });
                if (exerciseInfoResponse != null)
                {
                    Console.WriteLine($"Exercise Info for {exerciseId}: Course Name: {exerciseInfoResponse.CourseName}, Type: {exerciseInfoResponse.Type}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve exercise published info.");
                }

                // Validate the exercise
                var validateResponse = await sessionService.ValidateExerciseAsync(new ExerciseValidateRequest { ExerciseId = exerciseId });
                if (validateResponse != null)
                {
                    Console.WriteLine($"Exercise Validate for {exerciseId}: Valid: {validateResponse.Valid}, Marks: {validateResponse.Marks}");
                }
                else
                {
                    Console.WriteLine("Failed to validate exercise.");
                }

                // Create a session for the exercise
                var createSessionRequest = new CreateSessionRequest
                {
                    Exercises = new List<Exercise>
                    {
                        new ExerciseById { ExerciseId = exerciseId, Version = "latest" },
                    }
                };

                // Update the handling of CreateSessionResponse to reflect the array response
                var createSessionResponse = await sessionService.CreateSessionAsync(createSessionRequest);

                if (createSessionResponse != null && createSessionResponse.Any())
                {
                    foreach (var session in createSessionResponse)
                    {
                        if (session.Success && session.Sessions.Any())
                        {
                            var sessionId = session.Sessions.First().SessionId;
                            Console.WriteLine($"Session created successfully. Session ID: {sessionId}");

                            // Get scoring results for the created session
                            var sessionScoreResponse = await sessionService.GetSessionScoreAsync(new SessionScoreRequest { SessionId = sessionId });

                            if (sessionScoreResponse != null)
                            {
                                Console.WriteLine("Scoring Results:");
                                foreach (var question in sessionScoreResponse.Questions)
                                {
                                    Console.WriteLine($"Question: {question.Id}, Marks Earned: {question.Scoring.MarksEarned}, Total Marks: {question.Scoring.MarksTotal}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed to retrieve scoring results.");
                            }

                            // Get session info
                            var sessionInfoResponse = await sessionService.GetSessionInfoAsync(new SessionInfoRequest { SessionId = sessionId });
                            if (sessionInfoResponse != null)
                            {
                                Console.WriteLine("Session Info successfully retrieved.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to retrieve session info.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to create session.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No sessions were created.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
