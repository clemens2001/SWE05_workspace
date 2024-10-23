using System.Net;
using static System.Console;


#pragma warning disable SYSLIB0014 // Type or member is obsolete: WebClient used for demonstration purposes. Use HttpClient instead.
public class Downloader
{
    public void DownloadSync(string url, string filePath)
    {
        using var client = new WebClient();     // using makes sure the client is disposed after the block

        byte[] bytes = client.DownloadData(url);
        WriteLine($"{nameof(DownloadSync)}: Downloaded '{url}'");

        File.WriteAllBytes(filePath, bytes);
        WriteLine($"{nameof(DownloadSync)}: Saved '{filePath}'");
    }

    public void DownloadAsync_Legacy(string url, string filePath)
    {
        using var client = new WebClient();


        client.DownloadDataCompleted += (s, e) =>
        {
            WriteLine($"{nameof(DownloadAsync_Legacy)}: Downloaded '{url}'");

            var stream = new FileStream(filePath, FileMode.Create);
            stream.BeginWrite(e.Result, 0, e.Result.Length, asyncResult =>
            {
                stream.EndWrite(asyncResult);
                stream.Dispose();
                WriteLine($"{nameof(DownloadAsync_Legacy)}: Saved '{filePath}'");
            }, null);

        };

        client.DownloadDataAsync(new Uri(url));
    }

    public Task DownloadAsync_Task(string url, string filePath)
    {
        using var client = new WebClient();

        var task = client.DownloadDataTaskAsync(url)
            .ContinueWith(t =>
            {
                WriteLine($"{nameof(DownloadAsync_Task)}: Downloaded '{url}'");
                return t.Result;
            })
            .ContinueWith(t => File.WriteAllBytesAsync(filePath, t.Result))
            .ContinueWith(t =>
            {
                WriteLine($"{nameof(DownloadAsync_Task)}: Saved '{filePath}'");
            });

        return task;
    }

    public async void DownloadAsync_Await(string url, string filePath)
    {
        using var client = new WebClient();
        byte[] bytes = await client.DownloadDataTaskAsync(url);
        WriteLine($"{nameof(DownloadAsync_Await)}: Downloaded '{url}'");

        await File.WriteAllBytesAsync(filePath, bytes);
        WriteLine($"{nameof(DownloadAsync_Await)}: Saved '{filePath}'");
    }

    public void DownloadMultipleAsync(string url1, string filePath1, string url2, string filePath2)
    {
        // TODO
        WriteLine($"{nameof(DownloadMultipleAsync)}: {nameof(DownloadAsync_Await)} of '{url1}' started");

        // TODO
        WriteLine($"{nameof(DownloadMultipleAsync)}: {nameof(DownloadAsync_Await)} of '{url2}' started");

        // TODO
        WriteLine($"{nameof(DownloadMultipleAsync)}: {nameof(DownloadAsync_Await)} of all files completed");
    }
}
