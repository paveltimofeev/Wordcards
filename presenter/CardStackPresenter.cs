using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;

namespace presenter
{
    public class CardStackPresenter : CardPresenter
    {
        ICardStackView view;
        
        Card previouse = null;
        Card current = null;
        bool isFlipped = false;
        bool wasRankIncreased = false;

        public CardStackPresenter(ICardStackView view)
        {
            this.view = view;
            model.LoadXML("default.xml");
        }

        public void Save()
        {
            model.AddCard(view.EditEng, view.EditEngDesc, view.EditTranscription, view.EditRus, view.EditRusDesc);
            model.SaveDatabase();
        }

        public void Next()
        {
            previouse = current;
            current = model.GetRandom();
            isFlipped = false;
            wasRankIncreased = false;
            ShowForwardSide();
        }

        public void Previouse()
        {
            current = previouse;
            ShowForwardSide();
        }

        public void ShowForwardSide()
        {
            view.ShowEngSide(current.Eng, current.EngDesc, current.Transcription);
            view.ShowAdditionalInfo(current.WordType, current.Rank);
        }

        public void ShowBackSide()
        {
            if (!wasRankIncreased)
            {
                current.Rank++;
                wasRankIncreased = true;
                model.SaveDatabase();
            }

            view.ShowRusSide(current.Rus, current.Eng, current.RusDesc);
            view.ShowAdditionalInfo(current.WordType, current.Rank);
        }

        public void Flip()
        {
            if (!isFlipped)
                ShowBackSide();
            else
                ShowForwardSide();

            isFlipped = !isFlipped;
        }

        public void RemoveCurentCard()
        {
            base.RemoveCard(current.Eng, current.EngDesc, current.Transcription, current.Rus, current.RusDesc);
        }
    }
}
