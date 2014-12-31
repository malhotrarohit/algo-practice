using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptKicker
{
    class Decrypter
    {
        List<string>[] words;
        IDictionary<string, string> wordToWord;
        IDictionary<char, char> map;

        public Decrypter(string[] dict, int maxLen)
        {
            words = new List<string>[maxLen + 1];
            foreach (string word in dict)
            {
                words[word.Length] = new List<string>();
                words[word.Length].Add(word);
            }
            wordToWord = new Dictionary<string, string>();
            map = new Dictionary<char, char>();
        }

        public void Decrypt(IList<string> encryptedLines)
        {
            if (encryptedLines.Count > 0)
            {
                foreach (string ecLine in encryptedLines)
                {
                    string[] ecWords = ecLine.Split(' ');

                    if (ecWords.Length > 0)
                    {
                        Decode(ecWords, 0);
                    }
                }
            }
        }

        private bool Decode(string[] ecWords, int i)
        {
            if(i > ecWords.Length - 1) return true;
            if(wordToWord.ContainsKey(ecWords[i]))
            {
                return true;
            }
            bool isValid;
            foreach (string word in words[ecWords[i].Length])
            {
                isValid = true;
                if (!wordToWord.Values.Contains(word))
                {
                    char[] wordCharArray = word.ToCharArray();
                    char[] ecWordCharArray = ecWords[i].ToCharArray();

                    for (int j = 0; j < wordCharArray.Length; j++)
                    {
                        if (map.ContainsKey(ecWordCharArray[j]) && map[ecWordCharArray[j]] != wordCharArray[j])
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        wordToWord.Add(ecWords[i], word);
                        for (int j = 0; j < wordCharArray.Length; j++)
                        {
                            map.Add(ecWordCharArray[j], wordCharArray[j]);
                        }
                        if (Decode(ecWords, i + 1))
                        {
                            return true;
                        }
                        else
                        {
                            wordToWord.Remove(ecWords[i]);
                            for (int j = 0; j < ecWordCharArray.Length; j++)
                            {
                                map.Remove(ecWordCharArray[j]);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
