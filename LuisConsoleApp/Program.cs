using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System;
using System.Configuration;

namespace LuisConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LUISRuntimeClient luisClient = new LUISRuntimeClient(
                new ApiKeyServiceClientCredentials(ConfigurationManager.AppSettings["LUIS.SubscriptionKey"]))
            { Endpoint = "https://westus.api.cognitive.microsoft.com/" };

            while (true)
            {
                Console.Write("Input: ");

                LuisResult luisResult = luisClient.Prediction.ResolveAsync(ConfigurationManager.AppSettings["LUIS.ApplicationId"], Console.ReadLine()).Result;

                if (luisResult.TopScoringIntent != null)
                {
                    Console.WriteLine($"TopScoringIntent: {luisResult.TopScoringIntent.Intent} - Score: {luisResult.TopScoringIntent.Score}");
                }

                if (luisResult.Intents != null)
                {
                    foreach (IntentModel luisIntent in luisResult.Intents)
                    {
                        Console.WriteLine($"TopScoringIntent: {luisIntent.Intent} - Score: {luisIntent.Score}");
                    }
                }
            }
        }
    }
}
