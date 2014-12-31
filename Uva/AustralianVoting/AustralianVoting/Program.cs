using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AustralianVoting
{
    class Program
    {
        static int ballotSize = 10;

        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "0")
            {
                int numCandidates = Convert.ToInt32(input);
                string[] candidates = new string[numCandidates+1];
                candidates[0] = string.Empty;

                for (int i = 1; i < numCandidates+1 ; i++)
                {
                    candidates[i] = Console.ReadLine();
                }

                ManageVoting(candidates);
            }
        }

        static void ManageVoting(string[] candidates)
        {
            int len = candidates.Length - 1;
            Queue<int>[] voteBank = new Queue<int>[ballotSize + 1];
            List<int>[] candidateToBallotsMapping = new List<int>[candidates.Length + 1];

            for (int i = 1; i <= ballotSize; i++)
            {
                string[] votes = Console.ReadLine().Split(' ');
                for (int j = 0; j < votes.Length; j++)
                {
                    voteBank[i].Enqueue(Convert.ToInt32(votes[j]));
                }
                candidateToBallotsMapping[Convert.ToInt32(votes[0])].Add(i) ;
            }

            while (true)
            {
                int maxIndex = -1, max = 0, min = Int32.MaxValue;
                List<int> minIndices = new List<int>();

                for (int i = 1; i < candidates.Length; i++)
                {
                    if (candidateToBallotsMapping[i] != null)
                    {
                        int count = candidateToBallotsMapping[i].Count;

                        if (count > max)
                        {
                            max = count;
                            maxIndex = i;
                        }
                        if (count < min)
                        {
                            min = count;
                        }
                    }
                }
                for (int i = 1; i < candidates.Length; i++)
                {
                    if (candidateToBallotsMapping[i] != null && candidateToBallotsMapping[i].Count == min)
                    {
                        minIndices.Add(i);
                    }
                }

                if (minIndices.Count == len)
                {
                    return;
                }

                if (max > ballotSize / 2)
                {
                    Console.WriteLine(candidates[maxIndex]);
                    return;
                }
                else
                {
                    foreach (int i in minIndices)
                    {
                        foreach (int j in candidateToBallotsMapping[i])
                        {
                            voteBank[j].Dequeue();
                            candidateToBallotsMapping[voteBank[j].Peek()].Add(j);
                        }
                        candidateToBallotsMapping[i].Clear();
                        candidateToBallotsMapping[i] = null;
                    }
                    len = len - minIndices.Count;
                }
            }
        }
    }
}
