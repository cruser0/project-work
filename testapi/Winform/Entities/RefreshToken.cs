using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Entities
{
    internal class RefreshToken
    {
        public int TokenID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        //KdiGeZ5baK5dLnsk2zQdf4ermF/nOV/m5CqNx8jNFzBVQSmV8lM2mROpWZOfZimahrlwyU8CjeEgSj04ksBUuQ==
    }
}
