using PalabrasApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalabrasApp.Client.Services
{
    public class WordsList
    {
        public List<Palabra> palabras = new List<Palabra>();

        //public void getPalabras()
        //{
        //    //Testing List
        //    palabras.Add(new Palabra()
        //    {
        //        SpanishWord = "Perro",
        //        EnglishWord = "Dog"
        //    });
        //    palabras.Add(new Palabra()
        //    {
        //        SpanishWord = "Gato",
        //        EnglishWord = "Cat"
        //    });
        //    palabras.Add(new Palabra()
        //    {
        //        SpanishWord = "Oso",
        //        EnglishWord = "Bear"
        //    });
        //}

        public void ListDataHasChanged ()
        {
            NotifyDataHasChanged();
        }

        public event Action OnChange;

        private void NotifyDataHasChanged() => OnChange?.Invoke();
        
    }
}
