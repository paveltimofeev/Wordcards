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
        private ICardInvokeableStackView view;
        ///previouse card instance
        private int historyPosition = -1;
        ///current card instance
        private int current = -1;
        ///Flag discribes state of the card (flipped or not)
        private bool isFlipped = false;
        ///Flag describes that rank of card was increased
        private bool wasRankIncreased = false;
        ///Card's history
        private List<int> history = new List<int>();
        ///View's state
        private ViewState state = ViewState.DISPLAY;
        ///Play-mode timer
        private Timer playTimer = new Timer();
        ///View's bring-on-top method handler
        private delegate void BringOnTopHandler();

        public CardStackPresenter(ICardInvokeableStackView view): this(view, 10)
        {
            ;
        }
        public CardStackPresenter(ICardInvokeableStackView view, int defaultRank)
        {
            this.view = view;
            base.OpenDatabase();
            model.SetDefaultCardRank(defaultRank);

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
                current = model.AddCard(view.EditEng, view.EditEngDesc, view.EditTranscription, view.EditRus, view.EditRusDesc);
            }

            model.SaveDatabase();

            SwitchDisplay();
        }

        /// <summary>
        /// Remove current card.
        /// </summary>
        public void RemoveCurentCard()
        {
            if (current >= 0)
            {
                base.RemoveCardById(current);
                this.model.SaveDatabase();
            }
            this.NextCard();
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
            ChangeRank();

            if (history.Count > 0 && historyPosition >= 0 & historyPosition < history.Count - 1)
            {
                historyPosition++;
                current = history[historyPosition];
                ShowForwardSide();
            }
            else
            {
                /*SIMPLE RANDOM CARD ALGORITHM TO GETS HIGH-RANKED CARDS MORE OFTEN*/
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
        }

        /// <summary>
        /// Change card's rank
        /// </summary>
        private void ChangeRank()
        {
            ///If user didn't flip card decrease it's rank otherwise increase it.
            if (state == ViewState.DISPLAY && model.Cards.Count > 0 && current >= 0)
            {
                Card curr = model.Cards[current];
                if (!wasRankIncreased)
                {
                    if (curr.Rank > 0 & historyPosition == history.Count - 1)
                    {
                        curr.Rank--;
                        model.SaveDatabase();
                    }
                }
                else
                {
                    curr.Rank++;
                    wasRankIncreased = false;
                    model.SaveDatabase();
                }
            }
        }

        /// <summary>
        /// Diplay forward side of card.
        /// </summary>
        public void ShowForwardSide()
        {
            if (current >= 0 & model.Cards.Count > 0)
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
            if (current >= 0 & model.Cards.Count > 0)
            {
                Card temp = model.Cards[current];
                
                if (state == ViewState.DISPLAY && !wasRankIncreased)
                {
                    wasRankIncreased = true;
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
            if (state == ViewState.DISPLAY)
            {
                playTimer.Interval = GetRandomPlayTimerDelay(1, 10);
                view.Dispatcher.Invoke(new BringOnTopHandler(view.BringOnTop));
            }
        }

        protected int GetRandomPlayTimerDelay(int min, int max)
        {
            return 1000 * 60 * new Random().Next(min, max);
        }

        /// <summary>
        /// Request view refresh
        /// </summary>
        protected override void RefreshView()
        {
            view.Refresh();
        }

        /// <summary>
        /// Switch to "Create new card" mode.
        /// </summary>
        public void SwitchNew()
        {
            state = ViewState.NEW;
            view.SetBgColor(252, 180, 16);
            current = -1;
            view.ShowEngSide("", "", "");
        }

        /// <summary>
        /// Switch to "Edid card" mode.
        /// </summary>
        public void SwitchEdit()
        {
            state = ViewState.EDIT;
            if (current >= 0)
            {
                Card temp = model.Cards[current];
                view.ShowEngSide(temp.Eng, temp.EngDesc, temp.Transcription);
            }
        }

        /// <summary>
        /// Switch to "Display card" mode (default).
        /// </summary>
        public void SwitchDisplay()
        {
            state = ViewState.DISPLAY;
            this.ShowForwardSide();
        }
    }
}
