using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream =
    await client.GetStreamAsync("https://localhost:7289/api/Students");
    var repositories =
        await JsonSerializer.DeserializeAsync<List<Name>>(stream);
   


    foreach (var repo in repositories ?? Enumerable.Empty<Name>())
        Console.WriteLine(repo.name+" ");
    
    Console.ReadKey();
}