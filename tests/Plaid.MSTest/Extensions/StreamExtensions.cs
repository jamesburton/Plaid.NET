using System.IO;
using System.Threading.Tasks;

namespace Acklann.Plaid.MSTest.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<long> SaveToFile(this Stream stream, string path, FileMode fileMode = FileMode.Create, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, int bufferSize = 16345)
        {
            // If we can seek, then seek to the start of the stream
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);

            var buffer = new byte[bufferSize];
            long totalRead = 0L;
            using (FileStream fs = new FileStream(path, fileMode, fileAccess, fileShare))
            {
                int read;
                while ((read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                {
                    totalRead += read;
                    await fs.WriteAsync(buffer, 0, read).ConfigureAwait(false);
                }
            };
            return totalRead;
        }

        public static async Task<long> SaveToStream(this Stream stream, Stream outputStream, int bufferSize = 16345, bool skipSeek = false)
        {
            // If we can seek, then seek to the start of the streams
            if (stream.CanSeek && !skipSeek) stream.Seek(0, SeekOrigin.Begin);
            if (outputStream.CanSeek && !skipSeek) outputStream.Seek(0, SeekOrigin.Begin);

            var buffer = new byte[bufferSize];
            long totalRead = 0L;

            int read;
            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
            {
                totalRead += read;
                await outputStream.WriteAsync(buffer, 0, read).ConfigureAwait(false);
            }

            return totalRead;
        }
    }
}
