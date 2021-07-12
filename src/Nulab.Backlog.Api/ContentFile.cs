namespace Nulab.Backlog.Api
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public sealed class ContentFile
    {
        private readonly string _fileName;

        private readonly HttpResponseMessage _response;

        public ContentFile(HttpResponseMessage response)
        {
            _response = response;
            _fileName = _response.Content.Headers.ContentDisposition.FileNameStar ?? _response.Content.Headers.ContentDisposition.FileName;
        }

        public async Task<string> DownloadAsync(string directory)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            var fileName = Path.Combine(directory, _fileName);

            if (File.Exists(fileName)) File.Delete(fileName);

            // 以下のページを参考にしつつ、.NET Core 3.1 で動くように調整した。
            // https://www.atmarkit.co.jp/fdotnet/dotnettips/618downnoname/downnoname.html
            await using var stream = await _response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            await using var fileStream = new FileStream(fileName, FileMode.Create);

            var buffer = new byte[1024];
            var count = 0;

            do
            {
                count = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                await fileStream.WriteAsync(buffer, 0, count).ConfigureAwait(false);
            } while (count != 0);

            return fileName;
        }
    }
}