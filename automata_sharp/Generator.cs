﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata_sharp
{
    class Generator
    {
        private List<int> flags = new List<int>();
        private List<int> sequence = new List<int>();
        private int numStates = 0;
        private int numLetters = 0;
        private Automata automata = new Automata();
        public bool IsLastFlags { private set;  get; }
        public bool IsLastSequences { private set; get; }

        public Generator() { }

        public Generator(int n, int k)
        {
            numStates = n;
            numLetters = k;

            for (int i = 0; i < n - 1; ++i)
                flags.Add(0);

            for (int i = 0, j = n * k; i < j; ++i)
                sequence.Add(0);

            for (int i = 1; i < n; ++i)
                flags[i - 1] = k * i - 1;

            resetSequences();

            var states = new List<int>(numStates);
            for (int i = 0; i < numStates; ++i)
                states.Add(i);

            var letters = String.Empty;
            for (int i = 0; i < numLetters; ++i)
                letters += Convert.ToChar('a' + i);

            Dictionary<int, Dictionary<char, int>> transitions = new Dictionary<int, Dictionary<char, int>>();
            for (int i = 0, l = numStates; i < l; ++i)
            {
                Dictionary<char, int> temp = new Dictionary<char, int>(numStates);
                transitions.Add(i, temp);
                for (int j = 0, m = numLetters; j < m; ++j)
                    temp.Add(Convert.ToChar('a' + j), sequence[i * numLetters + j]);
            }

            automata = new Automata(states, letters, transitions);
        }

        private void updateTransitions()
        {
            for (int i = 0, l = numStates; i < l; ++i)
                for (int j = 0, m = numLetters; j < m; ++j)
                    automata._transitions[i][Convert.ToChar('a' + j)] = sequence[i * numLetters + j];
        }

        private bool containe(int a)
        {
            bool f = false;
            for (int i = 0, n = numStates - 1; !f && i < n; ++i)
                f = a == flags[i];

            return f;
        }

        private int nearest(int a)
        {
            for (int i = numStates - 2; i >= 0; --i)
                if (flags[i] <= a)
                    return flags[i];

            IsLastSequences = true;
            return flags[0];
        }

        private void resetSequences()
        {
            for (int i = 0, j = 0, n = numStates * numLetters; i < n; ++i)
            {
                if (j < numStates - 1 && i == flags[j])
                    sequence[i] = ++j;
                else
                    sequence[i] = 0;
            }
            IsLastSequences = false;
        }

        public void NextFlags(int i)
        {
            if (i == 0)
                if (flags[i] != 0)
                {
                    --flags[i];
                    resetSequences();
                }
                else
                    IsLastFlags = true;
            else
                if (flags[i] - 1 == flags[i - 1])
            {
                flags[i] = numLetters * (i + 1) - 1;
                NextFlags(i - 1);
            }
            else
            {
                flags[i] = flags[i] - 1;
                resetSequences();
            }
        }

        public void NextICDFA(int a, int b)
        {
            int j = a * numLetters + b;
            if (a < numStates - 1)
            {
                while (containe(j))
                {
                    if (b == 0)
                    {
                        --a;
                        b = numLetters - 1;
                    }
                    else
                        --b;
                    --j;
                }
            }
            int m = nearest(j);
            if (!IsLastSequences)
                if (sequence[j] == sequence[m])
                {
                    sequence[j] = 0;
                    if (b == 0)
                        NextICDFA(a - 1, numLetters - 1);
                    else
                        NextICDFA(a, b - 1);
                }
                else
                    sequence[j] = sequence[j] + 1;
        }

        public int getWordLength()
        {
            updateTransitions();

            string word = automata.FindShortestResetWord_WithoutAsync();

            return word.Length;
        }

    }
}
