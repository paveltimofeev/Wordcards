﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.IO;
using System.Xml.Serialization;

namespace presenter
{
    public class CardFacade
    {
        Card random = null;
        public List<Card> Cards { get; private set; }
        Transformer trans = new Transformer("style_fb2.xslt");

        public CardFacade()
        {
            Cards = new List<Card>();
        }

        /// <summary>
        /// Save or update card item.
        /// </summary>
        public void AddCard(string eng, string engDesc, string transcription, string rus, string rusDesc)
        {
            Card card = new Card() { Eng = eng, EngDesc = engDesc, Transcription = transcription, Rus = rus, RusDesc = rusDesc };
            if (Cards.Contains(card))
                Cards[Cards.IndexOf(card)] = card;
            else
                Cards.Add(card);
        }

        public void RemoveCard(string eng, string engDesc, string transcription, string rus, string rusDesc)
        {
            Cards.Remove(new Card() { Eng = eng, EngDesc = engDesc, Transcription = transcription, Rus = rus, RusDesc = rusDesc });
        }

        public void Clear()
        {
            Cards.Clear();
        }

        public void SaveXML(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Card>));
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                ser.Serialize(stream, Cards);
                stream.Flush();
                stream.Close();
            }
        }

        public void LoadXML(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Card>));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                object obj = ser.Deserialize(stream);
                stream.Flush();
                stream.Close();

                if (obj != null && obj as List<Card> != null)
                {
                    Cards = (List<Card>)obj;
                }
            }
        }

        public void SaveFB2(string path)
        {
            trans.SetStyle(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "style_fb2.xslt"));
            Export(path);
        }

        public void SaveHTM(string path)
        {
            trans.SetStyle(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "style_html.xslt"));
            Export(path);
        }

        private void Export(string path)
        {
            string temp = Path.GetTempFileName();
            SaveXML(temp);
            trans.Transform(temp, path);
            File.Delete(temp);
        }

        public void Sort()
        {
            Cards.Sort();
        }

        public List<Card> Filter(string filterValue)
        {
            List<Card> temp = null;

            if (filterValue.Length != 0)
            {
                temp = new List<Card>();

                var query = from Card c in Cards
                            where (c.Eng == filterValue | c.Rus == filterValue)
                            select c;

                foreach (Card card in query)
                {
                    card.Rank++;
                    temp.Add(card);
                }

                SaveDatabase();
            }

            return temp;
        }

        public Card GetRandom()
        {
            int i = new Random().Next(0, Cards.Count);
            return Cards[i];
        }

        public void SortRank()
        {
            Cards.Sort(new CardRankComparer());
        }

        public void SaveDatabase()
        {
            SaveXML("default.xml");
        }
    }
}
