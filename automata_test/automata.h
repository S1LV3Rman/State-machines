#pragma once
#include <vector>
#include <set>
#include <string>
#include <map>


using std::string;
using std::set;
using std::vector;
using std::map;

template <typename State>
class Automata
{
private:
	vector<State> _states;
	string _letters;
	map<State, map<char, State>> _transitions;

public:
	Automata() {}

	Automata(set<State> states, set<char> letters, vector<vector<State>> transitions)
	{
		for (auto i : states)
			_states.push_back(i);

		for (auto i : letters)
			_letters.push_back(i);

		for (int i = 0, n = transitions.size(); i < n; ++i)
			for (int j = 0, m = transitions[i].size(); j < m; ++j)
				_transitions[_states[i]][_letters[j]] = transitions[i][j];
	}

	Automata(vector<State> states, string letters, vector<vector<State>> transitions)
	{
		_states = states;
		_letters = letters;

		for (int i = 0, n = transitions.size(); i < n; ++i)
			for (int j = 0, m = transitions[i].size(); j < m; ++j)
				_transitions[_states[i]][_letters[j]] = transitions[i][j];
	}

	Automata(vector<State> states, string letters, map<State, map<char, State>> transitions)
	{
		_states = states;
		_letters = letters;
		_transitions = transitions;
	}


	~Automata()
	{
		_states.clear();
		_letters.clear();
		_transitions.clear();
	}

	set<State> d(set<State> states, string word)
	{
		for (auto letter : word)
		{
			set<State> nextStates;

			for (auto state : states)
				nextStates.insert(_transitions[state][letter]);

			states = nextStates;
		}

		return states;
	}

	set<State> d(set<State> states, char letter)
	{
		set<State> nextStates;

		for (auto state : states)
			nextStates.insert(_transitions[state][letter]);

		states = nextStates;

		return states;
	}

	string findShortestResetWord()
	{
		vector<set<State>> usedStates, currentStates, nextStates;
		vector<string> currentWords, nextWords;
		set<State> start;

		for (auto s : _states)
			start.insert(s);

		currentStates.push_back(start);
		currentWords.push_back("");
			

		while (!currentStates.empty())
		{
			for (auto state : currentStates)
				usedStates.push_back(state);

			for (int i = 0, n = currentStates.size(); i < n; ++i)
				for (int j = 0, l = _letters.size(); j < l; ++j)
				{
					set<State> temp = d(currentStates[i], _letters[j]);
					
					bool isNew = true;
					for (int k = 0, m = usedStates.size(); isNew && k < m; ++k)
						isNew = temp != usedStates[k];

					if (isNew)
					{
						nextStates.push_back(temp);
						nextWords.push_back(currentWords[i] + _letters[j]);
					}
				}

			currentStates.clear();
			currentWords.clear();

			for (int i = 0, n = nextStates.size(); i < n; ++i)
			{
				if (nextStates[i].size() == 1)
					return nextWords[i];
				else
				{
					currentWords.push_back(nextWords[i]);
					currentStates.push_back(nextStates[i]);
				}
			}

			nextStates.clear();
			nextWords.clear();
		}
		return "";
	}

	/*
	‘ункци€ нахождени€ кратчайшего синхр. слова
	{
		N - список множеств состо€ний, которые уже были рассмотрены (изначально пустое)
		C - список множеств состо€ний, которые рассматриваютс€ на данном шаге
		W - список слов, которыми получены соответствующие множества состо€ний из C

		ƒобавл€ем в C множество всех состо€ний

		÷икл пока(C не пусто)
		{
			 опируем все множества из C в N

			ѕоочерЄдно действуем каждой буквой алфавита на все множества из C
				и добавл€ем в T каждое полученное множество, не наход€щеес€ в N

			ƒл€ добавленных множеств дописываем в W слова, которыми они получены

			≈сли в T есть множество из 1 элемента, то возвращаем слово, которым мы его получили
				иначе замен€ем C на T и очищаем T
		}
		јвтомат несинхронизируемый!
	}
	*/

	string findResetWord()
	{
		set<set<State>> pairs;
		string word;
		vector<set<set<State>>> usedStates;
		map<char, set<set<States>>> nextStates;

		for(int i = 0, n = _states.size() - 1; i < n; ++i)
			for (int j = i + 1, m = n + 1; j < m; ++j)
			{
				set<State> pair = { _states[i], _states[j] };
				pairs.insert(pair);
			}

		while (!pairs.empty())
		{
			usedStates.push_back(pairs);

			for(auto pair : pairs)
				for (auto letter : _letters)
					nextStates.push_back(d(pair, _letter));

			char minSet = _letters[0];
			for (auto letter : _letters)
			{
				for (auto state : usedStates)
				{
					
				}
			}
		}
		return word;
	}

	/*
	‘ункци€ нахождени€ синхр. слова
	{
		P - множество пар состо€ний
		W - синхр. слово
		U - использованные множества пар состо€ний

		«аписываем в P все пары состо€ний

		÷икл пока(P не пусто)
		{
			«аписываем P в U

			ѕримен€ем каждую букву алфавита к парам из P записыва€ результаты в T

			¬ыбираем из T первое, не наход€щеес€ в U, множество с наименьшим кол-вом
				пар и дописываем в W букву, которой оно было получено (если выбрать нечего => автомат не синхр.)

			«амен€ем P на выбранное слово и очищаем T
		}
		¬озвращаем W
	}
	*/
};

