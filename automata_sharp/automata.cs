using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace automata_sharp
{
    public class SortedSetCustomComparer : IComparer<SortedSet<int>>
    {
        public int Compare(SortedSet<int> x, SortedSet<int> y)
        {
            // x > y - 1; x == y - 0; x < y - -1
            List<int> a = x.ToList();
            List<int> b = y.ToList();

            for (int i = 0; i < a.Count && i < b.Count; ++i)
            {
                if (a[i] < b[i]) return -1;
                if (a[i] > b[i]) return 1;
            }
            return 0;
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

        public SortedSet<int> Delta(SortedSet<int> states, String word)
        {
            foreach(var letter in word)
            {
                SortedSet<int> nextStates = new SortedSet<int>();

                foreach (var state in states)
                    nextStates.Add(_transitions[state][letter]);

                states = nextStates;
            }

            return states;
        }

        public List<int> Delta(List<int> states, String word)
        {
            foreach(var letter in word)
            {
                List<int> nextStates = new List<int>();

                foreach (var state in states)
                    nextStates.Add(_transitions[state][letter]);

                states = nextStates;
            }

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

        public int Delta(int state, String word)
        {
            int nextState = state;
            foreach(var letter in word)
                nextState = _transitions[nextState][letter];
            return nextState;         
        }
        
        public String FindShortestResetWord()
        {
            List<SortedSet<int>> usedStates = new List<SortedSet<int>>(),
                            currentStates = new List<SortedSet<int>>(), 
                               nextStates = new List<SortedSet<int>>();
            List<String> currentWords = new List<String>(), 
                            nextWords = new List<String>();
            SortedSet<int> start = new SortedSet<int>();

            foreach (var s in _states)
                start.Add(s);

            currentStates.Add(start);
            currentWords.Add("");

            while (currentStates.Count != 0)
            {
                foreach (var state in currentStates)
                    usedStates.Add(state);

                for (int i = 0, n = currentStates.Count; i < n; ++i)
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
            }
            return "";
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
        private bool IsTwoSetsOfSetsAreEqual(SortedSet<SortedSet<int>> a, SortedSet<SortedSet<int>> b)
        {
            List<SortedSet<int>> x = a.ToList();
            List<SortedSet<int>> y = b.ToList();

            if (x.Count != y.Count) return false;
            
            bool flag = true;

            for (int i = 0; i < x.Count && i < y.Count && flag; ++i)
                flag = x[i].SetEquals(y[i]);

            return flag;
        }

        public String FindResetWord()
        {
            SortedSet<SortedSet<int>> pairs = new SortedSet<SortedSet<int>>(new SortedSetCustomComparer());
            String word = String.Empty;
            List<SortedSet<SortedSet<int>>> usedStates = new List<SortedSet<SortedSet<int>>>();
            Dictionary<char, SortedSet<SortedSet<int>>> nextStates = new Dictionary<char, SortedSet<SortedSet<int>>>();
            
            for (int i = 0, n = _states.Count - 1; i < n; ++i)
                for(int j = i + 1, m = n + 1; j < m; ++j)
                {
                    SortedSet<int> pair = new SortedSet<int>
                    {
                        _states[i],
                        _states[j],
                    };
                    pairs.Add(pair);
                }
            
            while (pairs.Count != 0)
            {
                usedStates.Add(pairs);

                foreach (var letter in _letters)
                {
                    SortedSet<SortedSet<int>> temp = new SortedSet<SortedSet<int>>(new SortedSetCustomComparer());

                    foreach (var pair in pairs)
                    {
                        SortedSet<int> next = Delta(pair, letter);
                        if (next.Count == 2)
                            temp.Add(next);
                    }

                    nextStates.Add(letter, temp);
                }

                char nextLetter = Convert.ToChar(0);
                int minState = pairs.Count;
                
                foreach(var letter in _letters)
                {
                    bool isNew = true;
                    for (int i = 0, n = usedStates.Count; isNew && i < n; ++i)
                        isNew = !IsTwoSetsOfSetsAreEqual(nextStates[letter], usedStates[i]);

                    if(isNew && nextStates[letter].Count <= minState)
                    {
                        minState = nextStates[letter].Count;
                        nextLetter = letter;
                    }
                }

                usedStates.Add(pairs);

                if (nextLetter != Convert.ToChar(0))
                {
                    pairs = nextStates[nextLetter];
                    word += nextLetter;
                }
                else
                    pairs.Clear();

                nextStates.Clear();
            }

            return word;
        }

        // String findResetWord()
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
