using System.ComponentModel.DataAnnotations;

namespace OAuth.AuthorizationServer.Core.Data.Model
{
    // Used internally by DotNetOpenAuth
    public partial class SymmetricCryptoKey
    {
        [Key]
        public string Bucket { get; set; }
        public string Handle { get; set; }
        public System.DateTime ExpiresUtc { get; set; }
        public byte[] Secret { get; set; }
    }
}
