namespace Acklann.Plaid.Interfaces
{
    /// <summary>A common interface for entities with a PublicKey property.</summary>
    public interface IHasPublicKey
    {
        /// <summary>The public key.</summary>
        string PublicKey { get; set; }
    }
}
