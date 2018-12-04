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
		vector<set<State>> used, states, nextStates;
		vector<string> words, nextWords;
		set<State> start;

		for (auto s : _states)
			start.insert(s);

		states.push_back(start);
		words.push_back("");
			

		while (!states.empty())
		{
			for (auto state : states)
				used.push_back(state);

			for (int i = 0, n = states.size(); i < n; ++i)
				for (int j = 0, l = _letters.size(); j < l; ++j)
				{
					set<State> temp = d(states[i], _letters[j]);
					
					bool isNew = true;
					for (int k = 0, m = used.size(); isNew && k < m; ++k)
						isNew = temp != used[k];

					if (isNew)
					{
						nextStates.push_back(temp);
						nextWords.push_back(words[i] + _letters[j]);
					}
				}

			states.clear();
			words.clear();

			for (int i = 0, n = nextStates.size(); i < n; ++i)
			{
				if (nextStates[i].size() == 1)
					return nextWords[i];
				else
				{
					words.push_back(nextWords[i]);
					states.push_back(nextStates[i]);
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
};

