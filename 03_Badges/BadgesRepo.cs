using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepo
    {
        protected readonly Dictionary<int, Badge> _badgeDirectory = new Dictionary<int, Badge>();

        public bool AddBadge(Badge newBadge)
        {
            int startCount = _badgeDirectory.Count;
            _badgeDirectory.Add(newBadge.BadgeID, newBadge);
            bool added = (_badgeDirectory.Count > startCount) ? true : false;
            return added;
        }

        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDirectory;
        }
    }
}
