﻿namespace Acklann.Plaid.Management
{
    /// <summary>
    /// Represents a response from plaid's '/item/delete' endpoints. The '/item/delete' endpoint allows you to delete an <see cref="Entity.Item"/>. Once deleted, the access_token associated with the Item is no longer valid and cannot be used to access any data that was associated with the <see cref="Entity.Item"/>.
    /// </summary>
    /// <seealso cref="ResponseBase" />
    public class RemoveItemResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Entity.Item"/> was removed/deleted.
        /// </summary>
        /// <value><c>true</c> if removed/deleted; otherwise, <c>false</c>.</value>
        public bool Removed { get; set; }
    }
}