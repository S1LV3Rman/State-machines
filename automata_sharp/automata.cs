using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

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
    }

    public class Automata
    {
        private List<int> _states;
        private String _letters;
        Dictionary<int, Dictionary<char, int>> _transitions;

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

            _transitions = new Dictionary<int, Dictionary<char, int>>();
            for (int i = 0, n = states; i < n; ++i)
            {
                Dictionary<char, int> temp = new Dictionary<char, int>();
                _transitions.Add(i, temp);
                for (int j = 0, m = letters; j < m; ++j)
                    temp.Add(Convert.ToChar('a' + j), Convert.ToInt32(dataTable.Rows[i][j + 1]));
            }
        }

        Automata(List<int> states, String letters, Dictionary<int, Dictionary<char, int>> transitions)
        {
            _states = states;
            _letters = letters;
            _transitions = transitions;
        }

        public List<int> GetStates()
        {
            return _states;
        }

        public String GetLetters()
        {
            return _letters;
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
        
        public Task<string> FindShortestResetWord(CancellationTokenSource cancellationTokenSource)
        {
            var token = cancellationTokenSource.Token;

            return Task.Run(() =>
            {
                var usedStates = new List<SortedSet<int>>();
                var currentStates = new List<SortedSet<int>>();
                var nextStates = new List<SortedSet<int>>();
                var currentWords = new List<string>();
                var nextWords = new List<string>();
                var start = new SortedSet<int>();

                foreach (var s in _states)
                    start.Add(s);

                currentStates.Add(start);
                currentWords.Add("");

                while (currentStates.Count != 0)
                {
                    foreach (var state in currentStates)
                        usedStates.Add(state);

                    for (int i = 0, n = currentStates.Count; i < n; ++i)
                    {
                        for (int j = 0, l = _letters.Length; j < l; ++j)
                        {
                            SortedSet<int> temp = Delta(currentStates[i], _letters[j]);

                            bool isNew = true;
                            for (int k = 0, m = usedStates.Count; isNew && k < m; ++k)
                                isNew = !temp.SetEquals(usedStates[k]);

                            if (isNew)
                            {
                                nextStates.Add(temp);
                                nextWords.Add(currentWords[i] + _letters[j]);
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

        /*
        Функция нахождения кратчайшего синхр.слова
        {
            N - список множеств состояний, которые уже были рассмотрены (изначально пустое)

        C - список множеств состояний, которые рассматриваются на данном шаге

        W - список слов, которыми получены соответствующие множества состояний из C


        Добавляем в C множество всех состояний


        Цикл пока(C не пусто)
        {
            Копируем все множества из C в N

            Поочерёдно действуем каждой буквой алфавита на все множества из C
                и добавляем в T каждое полученное множество, не находящееся в N

            Для добавленных множеств дописываем в W слова, которыми они получены


            Если в T есть множество из 1 элемента, то возвращаем слово, которым мы его получили

                иначе заменяем C на T и очищаем T

        }
        Автомат несинхронизируемый!

    }
    */
    
        public Task<string> FindResetWord(CancellationTokenSource cancellationTokenSource)
        {
            var token = cancellationTokenSource.Token;

            return Task.Run(() =>
            {
                var pairs = new SortedSet<Pair>();
                var word = string.Empty;
                var usedStates = new List<SortedSet<Pair>>();
                var nextStates = new Dictionary<char, SortedSet<Pair>>();

                for (int i = 0, n = _states.Count - 1; i < n; ++i)
                    for (int j = i + 1, m = n + 1; j < m; ++j)
                    {
                        var pair = new Pair(_states[i], _states[j]);
                        pairs.Add(pair);
                    }

                while (pairs.Count != 0)
                {
                    usedStates.Add(pairs);

                    foreach (var letter in _letters)
                    {
                        token.ThrowIfCancellationRequested();
                        var temp = new SortedSet<Pair>();
                        
                        foreach (var pair in pairs)
                        {
                            token.ThrowIfCancellationRequested();
                            Pair next = Delta(pair, letter);
                            if (next.IsValid())
                                temp.Add(next);
                        }

                        nextStates.Add(letter, temp);
                    }

                    char nextLetter = Convert.ToChar(0);
                    int minState = pairs.Count;

                    foreach (var letter in _letters)
                    {
                        token.ThrowIfCancellationRequested();

                        bool isNew = true;
                        for (int i = 0, n = usedStates.Count; isNew && i < n; ++i)
                            isNew = !nextStates[letter].SetEquals(usedStates[i]);

                        if (isNew && nextStates[letter].Count <= minState)
                        {
                            minState = nextStates[letter].Count;
                            nextLetter = letter;
                        }
                    }

                    if (nextLetter != Convert.ToChar(0))
                    {
                        pairs = nextStates[nextLetter];
                        word += nextLetter;
                    }
                    else pairs.Clear();

                    nextStates.Clear();

                    token.ThrowIfCancellationRequested();
                }  
                return word;
            }, token);
        }

        /*
        Функция нахождения синхр. слова
        {
            P - множество пар состояний
            W - синхр. слово
            U - использованные множества пар состояний

            Записываем в P все пары состояний

            Цикл пока(P не пусто)
            {
                Записываем P в U

                Применяем каждую букву алфавита к парам из P записывая результаты в T

                Выбираем из T последнее, не находящееся в U, множество с наименьшим кол-вом
                    пар и дописываем в W букву, которой оно было получено (если выбрать нечего => автомат не синхр.)

                Заменяем P на выбранное слово и очищаем T
            }
            Возвращаем W
        }
        */

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
        /*
        public static Automata Random(int numStates, int numLetters)
        {
            List<int> states = new List<int>();
            for (int i = 0; i < numStates; ++i)
                states.Add(i);

            String letters = String.Empty;
            for (int i = 0; i < numLetters; ++i)
                letters += Convert.ToChar(Convert.ToInt32('a') + i);

            Dictionary<int, Dictionary<char, int>> transitions = new Dictionary<int, Dictionary<char, int>>();
            Random rand = new Random();

            for (int i = 0; i < numStates; ++i)
            {
                Dictionary<char, int> temp = new Dictionary<char, int>();
                transitions.Add(i, temp);
                for (int j = 0; j < numLetters; ++j)
                    transitions[i].Add(Convert.ToChar(Convert.ToInt32('a') + j), rand.Next(numStates));
            }

            Automata generatedAutomata = new Automata(states, letters, transitions);
            return generatedAutomata;
            // Серега сказал так во всех учебниках пишут, хотя упростить можно
        }
        */
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
