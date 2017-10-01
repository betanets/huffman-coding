using System;
using System.Collections.Generic;

namespace Huffman
{
    public class TextKeeper
    {
        private List<String> text = new List<String>();
        public Int64 textLength { get; set; }

        public String getText()
        {
            String textToString = "";
            foreach(String str in text)
            {
                textToString += (str + " ");
            }
            return textToString.ToLower();
        }

        public void addLine(String str)
        {
            text.Add(str);
        }

        public void clearText()
        {
            this.text.Clear();
        }
    }
}
