using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.Diagnostics;
using System.Timers;
using System.Windows.Media;
namespace presenter
{
    /// <summary>
    /// Presenter class for ICardStackView view.
    /// </summary>
    public class CardStackPresenter : CardPresenter
    {
        ///View instance
        ICardInvokeableStackView view;
        ///previouse card instance
        int historyPosition = -1;
        ///current card instance
        int current = -1;
        ///Flag discribes state of the card (flipped or not)
        bool isFlipped = false;
        ///Flag describes that rank of card was increased
        bool wasRankIncreased = false;

        List<int> history = new List<int>();

        ViewState state;

        Timer playTimer = new Timer();
        delegate void BringOnTopHandler();

        public CardStackPresenter(ICardInvokeableStackView view)
        {
            this.view = view;
            model.LoadXML("default.xml");

            playTimer.Interval = GetRandomPlayTimerDelay(1, 10);
            playTimer.Stop();
            playTimer.Elapsed += new ElapsedEventHandler(_playTimerElapsed);

            state = ViewState.DISPLAY;
        }

        /// <summary>
        /// Save changes or add new card if its not exists.
        /// </summary>
        public void Save()
        {
            if (state == ViewState.EDIT)
            {
                model.UpdateCard(current, view.EditEng, view.EditEngDesc, view.EditTranscription, view.EditRus, view.EditRusDesc);
            }
            else if (state == ViewState.NEW)
            {
                model.AddCard(view.EditEng, view.EditEngDesc, view.EditTranscription, view.EditRus, view.EditRusDesc);
            }

            model.SaveDatabase();
            state = ViewState.DISPLAY;
        }

        /// <summary>
        /// Remove current card.
        /// </summary>
        public void RemoveCurentCard()
        {
            if (current >= 0)
            {
                Card temp = model.Cards[current];
                base.RemoveCard(temp.Eng, temp.EngDesc, temp.Transcription, temp.Rus, temp.RusDesc);
                this.model.SaveDatabase();
            }
            this.Next();
        }

        /// <summary>
        /// Display next rundom card.
        /// </summary>
        public void Next()
        {
            Card temp = model.GetRandom();

            if (temp != null)
            {
                current = model.Cards.IndexOf(temp);

                history.Add(current);
                historyPosition = history.Count - 1;

                isFlipped = false;
                wasRankIncreased = false;
                ShowForwardSide();
            }
        }

        /// <summary>
        /// Display previouse card.
        /// </summary>
        public void PreviouseCard()
        {
            if (history.Count > 0 && historyPosition > 0 & historyPosition <= history.Count)
            {
                historyPosition--;
                current = history[historyPosition];
            }
            ShowForwardSide();
        }

        /// <summary>
        /// Displays next card if it extists or rundom if not.
        /// </summary>
        public void NextCard()
        {
            if (history.Count > 0 && historyPosition >= 0 & historyPosition < history.Count - 1)
            {
                historyPosition++;
                current = history[historyPosition];
            }
            else
            {
                Next();
            }
            ShowForwardSide();
        }

        /// <summary>
        /// Diplay forward side of card.
        /// </summary>
        public void ShowForwardSide()
        {
            if (current >= 0)
            {
                Card temp = model.Cards[current];

                ///save other side data if current state is edit or new.
                if (state == ViewState.EDIT | state == ViewState.NEW)
                {
                    temp.Rus = view.EditRus;
                    temp.RusDesc = view.EditRusDesc;
                }

                view.SetBgColor(255, 255, 196);
                view.ShowEngSide(temp.Eng, temp.EngDesc, temp.Transcription);
                view.ShowAdditionalInfo(model.Cards.Count, temp.Rank);
            }
        }

        /// <summary>
        /// Diplay back side of card.
        /// </summary>
        public void ShowBackSide()
        {
            if (current >= 0)
            {
                Card temp = model.Cards[current];

                if (state == ViewState.DISPLAY && !wasRankIncreased)
                {
                    temp.Rank++;
                    wasRankIncreased = true;
                    model.SaveDatabase();
                }

                ///save other side data if current state is edit or new.
                if (state == ViewState.EDIT | state == ViewState.NEW)
                {
                    temp.Eng = view.EditEng;
                    temp.EngDesc = view.EditEngDesc;
                    temp.Transcription = view.EditTranscription;
                }

                view.SetBgColor(190, 245, 116);
                view.ShowRusSide(temp.Rus, temp.Eng, temp.RusDesc);
                view.ShowAdditionalInfo(model.Cards.Count, temp.Rank);
            }
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

        /// <summary>
        /// Start play mode.
        /// </summary>
        public void PlayMode()
        {
            if (!playTimer.Enabled)
                playTimer.Start();
            else
                playTimer.Stop();

            view.IsPlayMode = playTimer.Enabled;
        }

        private void _playTimerElapsed(object sender, ElapsedEventArgs e)
        {
            playTimer.Interval = GetRandomPlayTimerDelay(1, 10);
            view.Dispatcher.Invoke(new BringOnTopHandler(view.BringOnTop));
        }

        protected int GetRandomPlayTimerDelay(int min, int max)
        {
            return 1000 * 60 * new Random().Next(min, max);
        }

        protected override void RefreshView()
        {
            view.Refresh();
        }

        public void SwitchNew()
        {
            state = ViewState.NEW;
            view.SetBgColor(252, 180, 16);
            current = -1;
            view.ShowEngSide("", "", "");
        }

        public void SwitchEdit()
        {
            state = ViewState.EDIT;
            if (current >= 0)
            {
                Card temp = model.Cards[current];
                view.ShowEngSide(temp.Eng, temp.EngDesc, temp.Transcription);
            }
        }

        public void SwitchDisplay()
        {
            state = ViewState.DISPLAY;
            this.ShowForwardSide();
        }
    }
}
