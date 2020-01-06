namespace Acklann.Plaid.Interfaces
{
    /// <summary>An interface for entities with an access token property.</summary>
    public interface IHasAccessToken
    {
        /// <summary>Gets or sets the access token.</summary>
        string AccessToken { get; set; }
    }
}
