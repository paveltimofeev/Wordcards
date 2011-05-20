using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace presenter
{
    /// <summary>
    /// Base class for cards presenters.
    /// </summary>
    public abstract class CardPresenter
    {
        readonly string databaseFile = "default.xml";
        ///Model instance
        protected CardFacade model;

        public CardPresenter()
        {
            databaseFile = Path.Combine(Environment.CurrentDirectory, "default.xml");

            model = new CardFacade();
        }

        /// <summary>
        /// Request for refresh view.
        /// </summary>
        protected abstract void RefreshView();

        protected void OpenDatabase()
        {
            if(File.Exists(databaseFile))
                model.LoadXML(databaseFile);
        }

        /// <summary>
        /// Update or add (if it's not exist in list) new card.
        /// </summary>
        public void SaveCard(string eng, string engDesc, string transcription, string rus, string rusDesc)
        {
            model.AddCard(eng, engDesc, transcription, rus, rusDesc);
            RefreshView();
        }

        /// <summary>
        /// Remove card from list
        /// </summary>
        public void RemoveCard(string eng, string engDesc, string transcription, string rus, string rusDesc)
        {
            model.RemoveCard(eng, engDesc, transcription, rus, rusDesc);
            RefreshView();
        }

        /// <summary>
        /// Remove card from list
        /// </summary>
        public void RemoveCardById(int index)
        {
            model.RemoveCard(index);
            RefreshView();
        }

        /// <summary>
        /// Remove all cards from list.
        /// </summary>
        public void Clear()
        {
            model.Clear();
            RefreshView();
        }

    }
}
