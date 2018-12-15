using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata_sharp
{
    /*
     * TO DO:
     * 
     * Поиск слова, поиск кратчайшего слова
     
         */
    class Automata
    {
        private List<int> _states;
        private String _letters;
        Dictionary<int, Dictionary<char, int>> _transitions;

        Automata() { }

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

        // String findShortestResetWord()
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

        public String Output()
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
    }
}
