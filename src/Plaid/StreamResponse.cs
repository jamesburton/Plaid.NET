using Newtonsoft.Json;
using System;
using System.IO;

namespace Acklann.Plaid
{
    /// <summary>Represents a binary stream response such as from from plaid's '/asset_report/pdf/get' endpoint wrapped to include status code.</summary>
    /// <seealso cref="ResponseBase" />
    public class StreamResponse : ResponseBase, IDisposable
    {
        /// <summary>The response stream.</summary>
        [JsonProperty("responseStream")]
        public Stream ResponseStream { get; set; }

        #region IDisposable Support
        private bool disposedValue/* = false*/; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    if (ResponseStream != null)
                        ResponseStream.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~StreamResponse()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}