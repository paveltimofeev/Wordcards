using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;

namespace presenter
{
    /// <summary>
    /// Presenter class for ICardStackView view.
    /// </summary>
    public class CardStackPresenter : CardPresenter
    {
        ///View instance
        ICardStackView view;
        ///previouse card instance
        Card previouse = null;
        ///current card instance
        Card current = null;
        ///Flag discribes state of the card (flipped or not)
        bool isFlipped = false;
        ///Flag describes that rank of card was increased
        bool wasRankIncreased = false;

        public CardStackPresenter(ICardStackView view)
        {
            this.view = view;
            model.LoadXML("default.xml");
        }

        /// <summary>
        /// Save changes or add new card if its not exists.
        /// </summary>
        public void Save()
        {
            model.AddCard(view.EditEng, view.EditEngDesc, view.EditTranscription, view.EditRus, view.EditRusDesc);
            model.SaveDatabase();

            view.State = ViewState.DISPLAY;
        }

        /// <summary>
        /// Remove current card.
        /// </summary>
        public void RemoveCurentCard()
        {
            base.RemoveCard(current.Eng, current.EngDesc, current.Transcription, current.Rus, current.RusDesc);
        }

        /// <summary>
        /// Display next rundom card.
        /// </summary>
        public void Next()
        {
            previouse = current;
            current = model.GetRandom();
            isFlipped = false;
            wasRankIncreased = false;
            ShowForwardSide();
        }

        /// <summary>
        /// Display previouse card.
        /// </summary>
        public void Previouse()
        {
            current = previouse;
            ShowForwardSide();
        }

        /// <summary>
        /// Diplay forward side of card.
        /// </summary>
        public void ShowForwardSide()
        {
            ///save other side data if current state is edit or new.
            if (view.State == ViewState.EDIT | view.State == ViewState.NEW)
            {
                current.Rus = view.EditRus;
                current.RusDesc = view.EditRusDesc;
            }

            view.ShowEngSide(current.Eng, current.EngDesc, current.Transcription);
            view.ShowAdditionalInfo(current.WordType, current.Rank);
        }

        /// <summary>
        /// Diplay back side of card.
        /// </summary>
        public void ShowBackSide()
        {
            if (view.State == ViewState.DISPLAY && !wasRankIncreased)
            {
                current.Rank++;
                wasRankIncreased = true;
                model.SaveDatabase();
            }

            ///save other side data if current state is edit or new.
            if (view.State == ViewState.EDIT | view.State == ViewState.NEW)
            {
                current.Eng = view.EditEng;
                current.EngDesc = view.EditEngDesc;
                current.Transcription = view.EditTranscription;
            }

            view.ShowRusSide(current.Rus, current.Eng, current.RusDesc);
            view.ShowAdditionalInfo(current.WordType, current.Rank);
        }

        /// <summary>
        /// Flip card.
        /// </summary>
        public void Flip()
        {
            if (!isFlipped)
                ShowBackSide();
            else
                ShowForwardSide();

            isFlipped = !isFlipped;
        }

        protected override void RefreshView()
        {
            view.Refresh();
        }
    }
}
