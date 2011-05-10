using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace presenter
{
    /// <summary>
    /// View interface
    /// </summary>
    public interface ICardStackView
    {
        /// <summary>
        /// Display English side of card 
        /// </summary>
        /// <param name="Eng">Word</param>
        /// <param name="EngDesc">Context or example</param>
        /// <param name="transcription">Word's transcription</param>
        void ShowEngSide(string Eng, string EngDesc, string transcription);

        /// <summary>
        /// Display Russian side of card 
        /// </summary>
        /// <param name="Rus">Russian word</param>
        /// <param name="Eng">English word</param>
        /// <param name="RusDesc">Context or example</param>
        void ShowRusSide(string Rus, string Eng, string RusDesc);

        /// <summary>
        /// Display additional information
        /// </summary>
        /// <param name="wordType">Total words in collection</param>
        /// <param name="Rank">Rank of word</param>
        void ShowAdditionalInfo(int totalWords, int Rank);

        /// <summary>
        /// Redraw, refresh or update view
        /// </summary>
        void Refresh();

        void BringOnTop();

        /// <summary>
        /// Current state (for ex.: edit, new, or dystplay).
        /// </summary>
        //ViewState State { get; set; }

        /// <summary>
        /// Value of editing field Eng
        /// </summary>
        string EditEng { get; }

        /// <summary>
        /// Value of editing field EngDesc
        /// </summary>
        string EditEngDesc { get; }

        /// <summary>
        /// Value of editing field Transcription
        /// </summary>
        string EditTranscription { get; }

        /// <summary>
        /// Value of editing field Rus
        /// </summary>
        string EditRus { get; }

        /// <summary>
        /// Value of editing field RusDesc
        /// </summary>
        string EditRusDesc { get; }

        /// <summary>
        /// Change BG color
        /// </summary>
        void SetBgColor(byte r, byte g, byte b);
    }

    /// <summary>
    /// State of the edit
    /// </summary>
    public enum ViewState { NEW, EDIT, DISPLAY }
}
