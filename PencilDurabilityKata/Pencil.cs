using System;
using System.Collections.Generic;
using System.Text;

namespace PencilDurabilityKata
{
    public class Pencil
    {
        Paper _paper = new Paper();

        int pencilLength;

        public String FullText { get { return _paper.fullText; } }

        public int PencilLength { get { return pencilLength; } }

        int originalPoint;
        int pointDegradation;
        public int PointDegradation { get { return pointDegradation; } }

        int originalErase;
        int eraseDegradation;
        public int EraseDegradation { get { return eraseDegradation; } }

        int eraseStartIndex = -1;

        public Pencil(int pencilLength, int originalPoint, int originalErase)
        {
            this.pencilLength = pencilLength;
            this.originalPoint = originalPoint;
            this.originalErase = originalErase;
            this.pointDegradation = originalPoint;
            this.eraseDegradation = originalErase;
        }

        public string Write(string text)
        {
            int _availableLength = lowerPointD(text);

            if (_availableLength >= text.Length)
            {
                return _paper.fullText += text;
            }
            else return _paper.fullText += text.Substring(0, _availableLength);

        }

        public void Sharpen()
        {
            if (pencilLength > 0)
            {
                pencilLength -= 1;
                pointDegradation = originalPoint;
            }

        }

        public string Erase(string text)
        {
            String emptySpaces = "";
            lowerEraseD(text);

            int _lastIndexErase = _paper.fullText.LastIndexOf(text);
            if (_lastIndexErase > -1)
            {
                eraseStartIndex = _lastIndexErase + text.Length;
                eraseStartIndex -= (originalErase > text.Length) ? text.Length : originalErase;
            }

            if (originalErase > text.Length)
            {

                char[] singleText = text.ToCharArray();
                foreach (char letter in singleText)
                {
                    emptySpaces += " ";
                }
                return ReplaceLastOccurrence(_paper.fullText, text, emptySpaces);
            }
            else return ReplaceWordLowErase(_paper.fullText, text);
        }

        public string Edit(string Text)
        {
            if (eraseStartIndex > -1)
            {
                _paper.fullText = ReplaceAtWithCollide(_paper.fullText, eraseStartIndex, Text, '@');
            }
            return _paper.fullText;
        }

        #region Helpers

        int lowerPointD(string text)
        {
            int i = 0, j = 0; 
            for (; (j < originalPoint) && (i < text.Length); i++)
            {
                if (char.IsUpper(text[i]))
                {
                    pointDegradation -= 2;
                    j += 2;
                }
                else if (char.IsLower(text[i]))
                {
                    pointDegradation--;
                    j++;
                }
            }
            return i;
        }

        int lowerEraseD(string text)
        {
            int totalCount = new int();
            char[] textArray = text.ToCharArray();
            foreach (var singleText in textArray)
            {
                if (char.IsLetter(singleText))
                {
                    totalCount++;
                }
            }
            if (eraseDegradation - totalCount > 0)
            {
                return eraseDegradation -= totalCount;
            }
            else return eraseDegradation = 0;

        }
        string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return _paper.fullText = result;
        }
        string ReplaceWordLowErase(String fullText, string text)
        {
            String emptySpaces = "";
            string updatedText = "";


            char[] singleText = text.ToCharArray();
            foreach (char letter in singleText)
            {
                emptySpaces += " ";
            }
            string[] words = _paper.fullText.Split(" ");
            foreach (string word in words)
            {

                if (word == text)
                {
                    updatedText += word.Replace(text.Substring(text.Length - originalErase, originalErase), emptySpaces.Substring(0, 3));

                }
                else
                {
                    updatedText += word + " ";
                }
            }
            return _paper.fullText = updatedText;

        }

        string ReplaceAtWithCollide(string input, int index, string newString, char collideChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            for (int i = index, j = 0; j < newString.Length && i < input.Length; i++, j++)
            {

                if (Char.IsWhiteSpace(chars[i]))
                {
                    chars[i] = newString[j];
                }
                else
                {
                    chars[i] = collideChar;
                }
            }
            return new string(chars);
        }
        #endregion
    }
}
