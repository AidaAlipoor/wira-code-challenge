 Answers to Technical Questions

## How much time did you spend on this task?
It was about 6 hours.

---

## If you had more time, what improvements or additions would you make?
If I had more time, I would add global exception handling middleware with logging and better input validation.  
I’d also improve testing coverage, use Swagger for documentation, and containerize the app with Docker for easier deployment.

---

## What is the most useful feature recently added to your favorite programming language?
One of the most useful features in recent C# versions is **Primary Constructors** (C# 12).  
They simplify constructor definitions and make code cleaner, especially when using dependency injection.

```csharp
public class WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
{
    public async Task<double> GetTemperatureAsync(string city)
    {
        logger.LogInformation($"Fetching temperature for {city}");
        // ...
        return 25.0;
    }
}

##How do you identify and diagnose a performance issue in a production environment? Have you done this before?

To identify and diagnose performance issues in production, I followed these steps in a project I contributed to:
Collect metrics and logs — using ILogger and Serilog to identify slow endpoints or exceptions.
Check database performance — using SQL Profiler to detect slow queries.
Reproduce locally if possible, then optimize the code.

##What’s the last technical book you read or technical conference you attended? What did you learn from it?

The last technical book I read was "AI Engineering" by Chip Huyen.
I haven’t finished the entire book yet, but I read the chapters about Retrieval-Augmented Generation (RAG) and the introduction.
From what I’ve read, I learned how RAG combines external knowledge retrieval with large language models to make AI systems more reliable and factual.
The book also explained the importance of data pipelines, evaluation, and production-ready AI systems, which helped me better understand how to structure AI projects — not just play with models.
I found it very practical because I’m working on a chatbot system that uses RAG, so I could connect the theory directly to my own project.

##What’s your opinion about this technical test?

I believe this challenge was well-balanced and appropriate for a junior-level developer.
It wasn’t too easy or too difficult, providing a fair opportunity to demonstrate both coding and problem-solving skills.

{
  "name": "Aida Alipoor",
  "role": ".NET Developer",
  "experienceYears": 3,
  "specialties": ["C#", ".NET", "Clean Architecture", "AI Development"],
  "strengths": ["Problem Solving", "Debugging", "Clean Code", "Continuous Learning"],
  "personality": "Curious, Analytical, Patient"
}