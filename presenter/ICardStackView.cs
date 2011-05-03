using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace presenter
{
    public interface ICardStackView
    {
        void ShowEngSide(string Eng, string EngDesc, string transcription);
        void ShowRusSide(string Rus, string Eng, string RusDesc);
        void ShowAdditionalInfo(int wordType, int Rank);

        void Refresh();

        string EditEng { get; }
        string EditEngDesc { get; }
        string EditTranscription { get; }
        string EditRus { get; }
        string EditRusDesc { get; }
    }
}
