using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace model
{
    public class CardRankComparer : IComparer<Card>
    {
        #region IComparer<Card> Members

        public int Compare(Card x, Card y)
        {
            return y.Rank.CompareTo(x.Rank);
        }

        #endregion
    }
}
