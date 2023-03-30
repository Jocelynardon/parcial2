using Dapr;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Dapr configurations
app.UseCloudEvents();

app.MapSubscribeHandler();

app.MapPost("/A", [Topic("pubsub", "A")] (ILogger<Program> logger, MessageEvent item) => {
    Console.WriteLine($"{item.MessageType}: {item.Message}");
    return Results.Ok();
});

app.MapPost("/B", [Topic("pubsub", "B")] (ILogger<Program> logger, MessageEvent item) => {
    Console.WriteLine($"{item.MessageType}: {item.Message}");
    return Results.Ok();
});

app.MapPost("/C", [Topic("pubsub", "C")] (ILogger<Program> logger, Dictionary<string, string> item) => {
    Console.WriteLine($"{item["messageType"]}: {item["message"]}");
    return Results.Ok();
});

app.MapPost("/Calificar", [Topic("pubsub", "Calificar")] (ILogger<Program> logger, Dictionary<string, string> item) => {
    Console.WriteLine($"{item["messageType"]}: {item["message"]}");
    return Results.Ok();
});

app.Run();

internal record MessageEvent(string MessageType, string Message);

/*
 using System;
using System.Collections.Generic;
using System.IO;

class LZSSCompressor
{
    private const int WindowSize = 4096;
    private const int MaxMatchLength = 18;
    private const int LookaheadBufferSize = 18;

    public static void Compress(string inputFilePath, string outputFilePath)
    {
        byte[] inputBuffer = File.ReadAllBytes(inputFilePath);
        List<byte> compressedData = new List<byte>();

        int inputPos = 0;
        while (inputPos < inputBuffer.Length)
        {
            int matchPos = -1;
            int matchLength = -1;

            for (int i = Math.Max(0, inputPos - WindowSize); i < inputPos; i++)
            {
                int length = 0;
                while (length < MaxMatchLength && inputPos + length < inputBuffer.Length && inputBuffer[i + length] == inputBuffer[inputPos + length])
                {
                    length++;
                }

                if (length > matchLength)
                {
                    matchPos = i;
                    matchLength = length;
                }
            }

            if (matchLength > 2)
            {
                // Emit a match token
                int offset = inputPos - matchPos - 1;
                compressedData.Add((byte)(offset >> 4));
                compressedData.Add((byte)(((offset & 0xF) << 4) | ((matchLength - 3) & 0xF)));
                inputPos += matchLength;
            }
            else
            {
                // Emit a literal token
                compressedData.Add(inputBuffer[inputPos++]);
            }
        }

        File.WriteAllBytes(outputFilePath, compressedData.ToArray());
    }
}*/






 */