using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace automata_sharp
{
    public class Pair : IComparable<Pair>
    {
        public int? f;
        public int? s;

        public Pair()
        {
            f = s = null;
        }

        public Pair(int a, int b)
        {
            if (a < b)
            {
                f = a;
                s = b;
            }
            else
            {
                f = b;
                s = a;
            }
        }

        public void Set(int a, int b)
        {
            if (a < b)
            {
                f = a;
                s = b;
            }
            else
            {
                f = b;
                s = a;
            }
        }

        public bool IsValid()
        {
            return f != s;
        }

        public static bool operator==(Pair L, Pair R)
        {
            return L.f == R.f && L.s == R.s;
        }

        public static bool operator!=(Pair L, Pair R)
        {
            return L.f != R.f || L.s != R.s;
        }

        public int CompareTo(Pair p)
        {
            if(this.f.Value.CompareTo(p.f.Value) == 0)
                return this.s.Value.CompareTo(p.s.Value);
            else
                return this.f.Value.CompareTo(p.f.Value);
        }

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;
            return pair != null && pair == this;
        }

        public override int GetHashCode()
        {
            return f.GetHashCode() + s.GetHashCode();
        }
    }

    public class Automata
    {
        public List<int> _states { private set; get; }
        public String _letters { private set; get; }
        public Dictionary<int, Dictionary<char, int>> _transitions { set; get; }

        public Automata() { }

        public Automata(DataTable dataTable)
        {
            int states = dataTable.Rows.Count;
            int letters = dataTable.Columns.Count - 1;

            _states = new List<int>();
            for (int i = 0; i < states; ++i)
                _states.Add(i);

            _letters = String.Empty;
            for (int i = 0; i < letters; ++i)
                _letters += Convert.ToChar('a' + i);

            _transitions = new Dictionary<int, Dictionary<char, int>>(states);
            for (int i = 0, n = states; i < n; ++i)
            {
                Dictionary<char, int> temp = new Dictionary<char, int>(letters);
                _transitions.Add(i, temp);
                for (int j = 0, m = letters; j < m; ++j)
                    temp.Add(Convert.ToChar('a' + j), Convert.ToInt32(dataTable.Rows[i][j + 1]));
            }
            ListUniqueListPool = new CollectionPool<List<UniqueList<int>>, UniqueList<int>>(() => new List<UniqueList<int>>());
            UniqueListPool = new CollectionPool<UniqueList<int>, int>(() => new UniqueList<int>());
        }

        public Automata(List<int> states, String letters, Dictionary<int, Dictionary<char, int>> transitions)
        {
            _states = states;
            _letters = letters;
            _transitions = transitions;
            ListUniqueListPool = new CollectionPool<List<UniqueList<int>>, UniqueList<int>>(() => new List<UniqueList<int>>());
            UniqueListPool = new CollectionPool<UniqueList<int>, int>(() => new UniqueList<int>());
        }

        public SortedSet<int> Delta(SortedSet<int> states, String word)
        {
            foreach (var letter in word)
                states = Delta(states, letter);
            
            return states;
        }

        public List<int> Delta(List<int> states, String word)
        {
            foreach (var letter in word)
                states = Delta(states, letter);

            return states;
        }

        public SortedSet<int> Delta(SortedSet<int> states, char letter)
        {
            SortedSet<int> nextStates = new SortedSet<int>();

            foreach (var state in states)
                nextStates.Add(_transitions[state][letter]);

            return nextStates;
        }

        public void Delta(UniqueList<int> result, UniqueList<int> states, char letter)
        {
            result.Clear();

            for(int i = 0; i < states.Count; i++)
                result.Add(_transitions[states[i]][letter]);

            //foreach (var state in states)
            //    result.Add(_transitions[state][letter]);
        }

        public List<int> Delta(List<int> states, char letter)
        {
            List<int> nextStates = new List<int>();

            foreach (var state in states)
                nextStates.Add(_transitions[state][letter]);

            return nextStates;
        }

        public Pair Delta(Pair pair, char letter)
        {
            var nextPair = new Pair();

            nextPair.Set(_transitions[pair.f.Value][letter], _transitions[pair.s.Value][letter]);

            return nextPair;
        }

        public int Delta(int state, String word)
        {
            int nextState = state;
            foreach (var letter in word)
                nextState = _transitions[nextState][letter];
            return nextState;
        }

        Dictionary<int, List<UniqueList<int>>> usedStates = new Dictionary<int, List<UniqueList<int>>>();
        List<UniqueList<int>> currentStates = new List<UniqueList<int>>();
        List<UniqueList<int>> nextStates = new List<UniqueList<int>>();
        List<string> currentWords = new List<string>();
        List<string> nextWords = new List<string>();
        //UniqueList<int> start = new UniqueList<int>();

        UniqueList<int> tempStates = new UniqueList<int>();

        CollectionPool<List<UniqueList<int>>, UniqueList<int>> ListUniqueListPool;
        CollectionPool<UniqueList<int>, int> UniqueListPool;

        public string FindShortestResetWord_WithoutAsync()
        {
            foreach (var e in usedStates)
            {
                var list = e.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    UniqueListPool.Push(list[i]);
                }

                ListUniqueListPool.Push(list);
            }
            usedStates.Clear();

            currentStates.Clear();
            nextStates.Clear();
            currentWords.Clear();
            nextWords.Clear();
            
            tempStates.Clear();

            var start = UniqueListPool.Pop();

            for (int i = 0; i < _states.Count; i++)
                start.Add(_states[i]);

            currentStates.Add(start);
            currentWords.Add("");

            usedStates.Add(start.Count, ListUniqueListPool.Pop());
            usedStates[start.Count].Add(start);

            while (currentStates.Count != 0)
            {
                for (int i = 0, n = currentStates.Count; i < n; ++i)
                {
                    for (int j = 0, l = _letters.Length; j < l; ++j)
                    {
                        Delta(tempStates, currentStates[i], _letters[j]);

                        bool isNew = true;
                        for (int k = 0, m = usedStates.ContainsKey(tempStates.Count) ? usedStates[tempStates.Count].Count : 0; isNew && k < m; ++k)
                            isNew = !tempStates.SetEquals(usedStates[tempStates.Count][k]);

                        if (isNew)
                        {
                            var temp = UniqueListPool.Pop();
                            temp.Override(tempStates);

                            nextStates.Add(temp);
                            nextWords.Add(currentWords[i] + _letters[j]);

                            if (!usedStates.ContainsKey(temp.Count))
                                usedStates.Add(temp.Count, ListUniqueListPool.Pop());
                            usedStates[temp.Count].Add(temp);
                        }
                    }
                }

                currentStates.Clear();
                currentWords.Clear();

                for (int i = 0, n = nextStates.Count; i < n; ++i)
                {
                    if (nextStates[i].Count == 1)
                    {
                        return nextWords[i];
                    }
                    else
                    {
                        currentWords.Add(nextWords[i]);
                        currentStates.Add(nextStates[i]);
                    }
                }

                nextStates.Clear();
                nextWords.Clear();
                
            }
            
            return "";
        }

        public Task<string> FindShortestResetWord(CancellationTokenSource cancellationTokenSource)
        {
            var token = cancellationTokenSource.Token;

            return Task.Run(() =>
            {
                var usedStates = new Dictionary<int, List<SortedSet<int>>>();
                var currentStates = new List<SortedSet<int>>();
                var nextStates = new List<SortedSet<int>>();
                var currentWords = new List<string>();
                var nextWords = new List<string>();
                var start = new SortedSet<int>();

                foreach (var s in _states)
                    start.Add(s);

                currentStates.Add(start);
                currentWords.Add("");
                
                usedStates.Add(start.Count, new List<SortedSet<int>>());
                usedStates[start.Count].Add(start);

                while (currentStates.Count != 0)
                {
                    for (int i = 0, n = currentStates.Count; i < n; ++i)
                    {
                        for (int j = 0, l = _letters.Length; j < l; ++j)
                        {
                            SortedSet<int> temp = Delta(currentStates[i], _letters[j]);

                            bool isNew = true;
                            for (int k = 0, m = usedStates.ContainsKey(temp.Count) ? usedStates[temp.Count].Count : 0; isNew && k < m; ++k)
                                isNew = !temp.SetEquals(usedStates[temp.Count][k]);

                            if (isNew)
                            {
                                nextStates.Add(temp);
                                nextWords.Add(currentWords[i] + _letters[j]);

                                if (!usedStates.ContainsKey(temp.Count))
                                    usedStates.Add(temp.Count, new List<SortedSet<int>>());
                                usedStates[temp.Count].Add(temp);
                            }
                        }
                        token.ThrowIfCancellationRequested();
                    }

                    currentStates.Clear();
                    currentWords.Clear();

                    for (int i = 0, n = nextStates.Count; i < n; ++i)
                    {
                        if (nextStates[i].Count == 1)
                            return nextWords[i];
                        else
                        {
                            currentWords.Add(nextWords[i]);
                            currentStates.Add(nextStates[i]);
                        }
                    }

                    nextStates.Clear();
                    nextWords.Clear();

                    token.ThrowIfCancellationRequested();
                }
                return "";
            }, token);
        }
         
        public Task<string> FindResetWord(CancellationTokenSource cancellationTokenSource)
        {
            var token = cancellationTokenSource.Token;

            return Task.Run(() =>
            {
                var usedPairs = new List<SortedSet<Pair>>();
                var currentPairs = new List<SortedSet<Pair>>();
                var nextPairs = new List<SortedSet<Pair>>();
                var currentWords = new List<string>();
                var nextWords = new List<string>();
                var start = new SortedSet<Pair>();

                for (int i = 0, n = _states.Count - 1; i < n; ++i)
                    for (int j = i + 1, m = n + 1; j < m; ++j)
                        start.Add(new Pair(_states[i], _states[j]));

                int min = start.Count;

                currentPairs.Add(start);
                currentWords.Add("");
                usedPairs.Add(start);

                while (currentPairs.Count != 0)
                {
                    for (int i = 0, n = currentPairs.Count; i < n; ++i)
                    {
                        for (int j = 0, m = _letters.Length; j < m; ++j)
                        {
                            var temp = new SortedSet<Pair>();

                            foreach (var pair in currentPairs[i])
                            {
                                Pair next = Delta(pair, _letters[j]);
                                if (next.IsValid())
                                    temp.Add(next);
                            }

                            bool isNew = true;
                            for (int k = 0, s = usedPairs.Count; isNew && k < s; ++k)
                                isNew = !temp.SetEquals(usedPairs[k]);
                            
                            if(isNew)
                            {
                                nextPairs.Add(temp);
                                nextWords.Add(currentWords[i] + _letters[j]);
                                usedPairs.Add(temp);
                            }
                        }
                        token.ThrowIfCancellationRequested();
                    }

                    currentPairs.Clear();
                    currentWords.Clear();

                    for (int i = 0, n = nextPairs.Count; i < n; ++i)
                        if (nextPairs[i].Count < min)
                        {
                            min = nextPairs[i].Count;
                            usedPairs.Clear();
                        }

                    for (int i = 0, n = nextPairs.Count; i < n; ++i)
                    {
                        if (nextPairs[i].Count == min)
                        {
                            if (min == 0)
                                return nextWords[i];

                            currentPairs.Add(nextPairs[i]);
                            currentWords.Add(nextWords[i]);
                            usedPairs.Add(nextPairs[i]);

                            if (usedPairs.Count == 1)
                                break;
                        }
                    }

                    nextPairs.Clear();
                    nextWords.Clear();

                    token.ThrowIfCancellationRequested();
                }
                return "";
            }, token);
        }

        public static Automata Random(int numStates, int numLetters)
        {
            Random rand = new Random();

            var flags = new List<int>();
            flags.Add(rand.Next(0, numLetters - 1));
            for (int i = 1, n = numStates - 1; i < n; ++i)
                flags.Add(rand.Next(flags[i - 1] + 1, (i + 1) * numLetters - 1));

            var str = new List<int>();
            for(int i = 0, n = numStates * numLetters, k = 0; i < n; ++i)
                if (k < numStates - 1 && i == flags[k])
                    str.Add(++k);
                else
                    str.Add(rand.Next(0, k));

            var states = new List<int>();
            for (int i = 0; i < numStates; ++i)
                states.Add(i);

            var letters = String.Empty;
            for (int i = 0; i < numLetters; ++i)
                letters += Convert.ToChar(Convert.ToInt32('a') + i);

            var transitions = new Dictionary<int, Dictionary<char, int>>();
            for (int i = 0; i < numStates; ++i)
            {
                var temp = new Dictionary<char, int>();
                transitions.Add(i, temp);
                for (int j = 0; j < numLetters; ++j)
                    transitions[i].Add(letters[j], str[i * numLetters + j]);
            }

            var a = new Automata(states, letters, transitions);
            return a;
        }

        public bool Verificate(String word)
        {
            var states = _states;
            states = Delta(states, word);

            var reference = states[0];
            for (int i = 0; i < states.Count; ++i)
                if (states[i] != reference) return false;
            return true;
        }

        public String OutputToString()
        {
            String output = "States: ";
            for (int i = 0, n = _states.Count; i < n; ++i)
                output += $"{_states[i]} ";
            output += '\n';

            output += "Language: ";
            for (int i = 0, n = _letters.Length; i < n; ++i)
                output += $"{_letters[i]} ";
            output += '\n';


            output += "Transitions: \n   ";
            for (int j = 0, m = _letters.Length; j < m; ++j)
                output += $"{_letters[j]} ";
            output += '\n';

            for (int i = 0, n = _states.Count; i < n; ++i)
            {
                output += $"{_states[i]}: ";
                for (int j = 0, m = _letters.Length; j < m; ++j)
                    output += $"{_transitions[_states[i]][_letters[j]]} ";
                output += '\n';
            }
            return output;
        }

        public DataTable OutputToDataTable()
        {
            DataTable output = new DataTable();

            output.Columns.Add("State");

            for (int j = 0, m = _letters.Length; j < m; ++j)
                output.Columns.Add($"by {_letters[j].ToString()}");

            for (int i = 0, n = _states.Count; i < n; ++i)
            {
                output.Rows.Add(_states[i].ToString());
                for (int j = 0, m = _letters.Length; j < m; ++j)
                    output.Rows[i][j + 1] = _transitions[_states[i]][_letters[j]];
            }

            return output;
        }
    }
}
