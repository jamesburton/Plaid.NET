namespace Acklann.Plaid.Interfaces
{
    /// <summary>An interface for entities with ClientId+Secret credentials.</summary>
    public interface IHasClientIdAndSecret
    {
        /// <summary>The client identifier.</summary>
        string ClientId { get; set; }
        /// <summary>The client secret.</summary>
        string Secret { get; set; }
    }
}
