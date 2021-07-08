using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public class ClaimRepo
    {
        protected readonly List<Claim> _claimDirectory = new List<Claim>();
        public bool AddClaim(Claim newClaim)
        {
            int startCount = _claimDirectory.Count;
            _claimDirectory.Add(newClaim);
            bool added = (_claimDirectory.Count > startCount) ? true : false;
            return added;
        }
        public List<Claim> GetClaims()
        {
            return _claimDirectory;
        }
        public bool RemoveClaim(Claim currentClaim)
        {
            bool delete = _claimDirectory.Remove(currentClaim);
            return delete;
        }
    }
}
