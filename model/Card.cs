using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace model
{
    public class Card : IComparable<Card>
    {
        public string Eng { get; set; }
        public string EngDesc { get; set; }

        public string Transcription { get; set; }

        public string Rus { get; set; }
        public string RusDesc { get; set; }

        public int WordType { get; set; }
        public int Rank { get; set; }

        public Card():this(0) { ;}
        public Card(int rank)
        {
            Rank = rank;
        }

        public override bool Equals(object obj)
        {
            Card temp = obj as Card;
            if (temp != null)
            {
                return 
                    this.Eng == temp.Eng & 
                    this.Rus == temp.Rus &
                    this.EngDesc == temp.EngDesc &
                    this.RusDesc == temp.RusDesc &
                    this.Transcription == temp.Transcription;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Eng, Rus);
        }

        #region IComparable<Card> Members

        public int CompareTo(Card other)
        {
            return this.Eng.CompareTo(other.Eng);
        }

        #endregion
    }
}
