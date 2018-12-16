using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace automata_sharp
{
    public class Automata
    {
        private List<int> _states;
        private String _letters;
        Dictionary<int, Dictionary<char, int>> _transitions;

        public Automata() { }

        Automata(HashSet<int> states, HashSet<char> letters, List<List<int>> transitions)
        {
            foreach (var i in states)
                _states.Add(i);

            foreach (var i in letters)
                _letters += i;

            for (int i = 0, n = transitions.Count; i < n; ++i)
                for (int j = 0, m = transitions[i].Count; j < m; ++j)
                    _transitions[_states[i]][_letters[j]] = transitions[i][j];
        }

        Automata(List<int> states, String letters, List<List<int>> transitions)
        {
            _states = states;
            _letters = letters;

            for (int i = 0, n = transitions.Count; i < n; ++i)
                for (int j = 0, m = transitions[i].Count; j < m; ++j)
                    _transitions[_states[i]][_letters[j]] = transitions[i][j];
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

        public HashSet<int> Delta(HashSet<int> states, String word)
        {
            foreach(var letter in word)
            {
                HashSet<int> nextStates = new HashSet<int>();

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

        public HashSet<int> Delta(HashSet<int> states, char letter)
        {
            HashSet<int> nextStates = new HashSet<int>();

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
            int? nextState = null;
            foreach(var letter in word)
                nextState = _transitions[state][letter];
            if (nextState.HasValue)
                return nextState.Value;
            else
                return -1;              
        }
        
        public String FindShortestResetWord()
        {
            List<HashSet<int>> usedStates = new List<HashSet<int>>(),
                            currentStates = new List<HashSet<int>>(), 
                               nextStates = new List<HashSet<int>>();
            List<String> currentWords = new List<String>(), 
                            nextWords = new List<String>();
            HashSet<int> start = new HashSet<int>();

            foreach (var s in _states)
                start.Add(s);

            currentStates.Add(start);
            currentWords.Add("");

            while (currentStates.Count != 0)
            {
                for (int i = 0, n = currentStates.Count; i < n; ++i)
                    for (int j = 0, l = _letters.Length; j < l; ++j)
                    {
                        HashSet<int> temp = Delta(currentStates[i], _letters[j]);

                        bool isNew = true;
                        for (int k = 0, m = usedStates.Count; isNew && k < m; ++k)
                            isNew = temp != usedStates[k];

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

        public String FindResetWord()
        {
            HashSet<HashSet<int>> pairs = new HashSet<HashSet<int>>();
            String word = String.Empty;
            List<HashSet<HashSet<int>>> usedStates = new List<HashSet<HashSet<int>>>();
            Dictionary<char, HashSet<HashSet<int>>> nextStates = new Dictionary<char, HashSet<HashSet<int>>>();

            for(int i = 0, n = _states.Count - 1; i < n; ++i)
                for(int j = i + 1, m = n + 1; j<m; ++j)
                {
                    HashSet<int> pair = new HashSet<int>();
                    pair.Add(_states[i]);
                    pair.Add(_states[j]);
                    pairs.Add(pair);
                }

            while (pairs.Count != 0)
            {
                usedStates.Add(pairs);

                foreach (var letter in _letters)
                {
                    HashSet<HashSet<int>> temp = new HashSet<HashSet<int>>();

                    foreach (var pair in pairs)
                    {
                        HashSet<int> next = Delta(pair, letter);
                        if (next.Count == 2)
                            temp.Add(next);
                    }

                    nextStates[letter] = temp;
                }

                char nextLetter = '\0';
                int minState = pairs.Count;

                foreach(var letter in _letters)
                {
                    bool isNew = true;
                    for (int i = 0, n = usedStates.Count; isNew && i < n; ++i)
                        isNew = nextStates[letter] != usedStates[i];

                    if(isNew && nextStates[letter].Count <= minState)
                    {
                        minState = nextStates[letter].Count;
                        nextLetter = letter;
                    }
                }

                usedStates.Add(pairs);

                if (nextLetter != '\0')
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
