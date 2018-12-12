#pragma once
#include <vector>
#include <set>
#include <string>
#include <map>
#include <iostream>

using std::cout;
using std::endl;
using std::string;
using std::set;
using std::vector;
using std::map;

class Automata
{
private:
	vector<int> _states;
	string _letters;
	map<int, map<char, int>> _transitions;

public:
	Automata() {}

	Automata(set<int> states, set<char> letters, vector<vector<int>> transitions)
	{
		for (auto i : states)
			_states.push_back(i);

		for (auto i : letters)
			_letters.push_back(i);

		for (int i = 0, n = transitions.size(); i < n; ++i)
			for (int j = 0, m = transitions[i].size(); j < m; ++j)
				_transitions[_states[i]][_letters[j]] = transitions[i][j];
	}

	Automata(vector<int> states, string letters, vector<vector<int>> transitions)
	{
		_states = states;
		_letters = letters;

		for (int i = 0, n = transitions.size(); i < n; ++i)
			for (int j = 0, m = transitions[i].size(); j < m; ++j)
				_transitions[_states[i]][_letters[j]] = transitions[i][j];
	}

	Automata(vector<int> states, string letters, map<int, map<char, int>> transitions)
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

	vector<int> getStates()
	{
		return _states;
	}

	set<int> d(set<int> states, string word)
	{
		for (auto letter : word)
		{
			set<int> nextStates;

			for (auto state : states)
				nextStates.insert(_transitions[state][letter]);

			states = nextStates;
		}

		return states;
	}

	vector<int> d(vector<int> states, string word)
	{
		for (auto letter : word)
		{
			vector<int> nextStates;

			for (auto state : states)
				nextStates.push_back(_transitions[state][letter]);

			states = nextStates;
		}

		return states;
	}

	set<int> d(set<int> states, char letter)
	{
		set<int> nextStates;

		for (auto state : states)
			nextStates.insert(_transitions[state][letter]);

		return nextStates;
	}

	vector<int> d(vector<int> states, char letter)
	{
		vector<int> nextStates;

		for (auto state : states)
			nextStates.push_back(_transitions[state][letter]);

		return nextStates;
	}

	string findShortestResetWord()
	{
		vector<set<int>> usedStates, currentStates, nextStates;
		vector<string> currentWords, nextWords;
		set<int> start;

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
					set<int> temp = d(currentStates[i], _letters[j]);
					
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
		set<set<int>> pairs;
		string word;
		vector<set<set<int>>> usedStates;
		map<char, set<set<int>>> nextStates;

		for(int i = 0, n = _states.size() - 1; i < n; ++i)
			for (int j = i + 1, m = n + 1; j < m; ++j)
			{
				set<int> pair = { _states[i], _states[j] };
				pairs.insert(pair);
			}

		while (!pairs.empty())
		{
			usedStates.push_back(pairs);

			for (auto letter : _letters)
			{
				set<set<int>> temp;
				
				for (auto pair : pairs)
				{
					set<int> next = d(pair, letter);
					if(next.size() == 2)
						temp.insert(next);
				}

				nextStates[letter] = temp;
			}

			char nextLetter = 0;
			size_t minState = pairs.size();

			for (auto letter : _letters)
			{
				bool isNew = true;
				for (int i = 0, n = usedStates.size(); isNew && i < n; ++i)
					isNew = nextStates[letter] != usedStates[i];

				if (isNew && nextStates[letter].size() <= minState)
				{
					minState = nextStates[letter].size();
					nextLetter = letter;
				}
			}

			usedStates.push_back(pairs);

			if (nextLetter != 0)
			{
				pairs = nextStates[nextLetter];
				word += nextLetter;
			}
			else
			{
				pairs.clear();
			}

			nextStates.clear();
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

			¬ыбираем из T последнее, не наход€щеес€ в U, множество с наименьшим кол-вом
				пар и дописываем в W букву, которой оно было получено (если выбрать нечего => автомат не синхр.)

			«амен€ем P на выбранное слово и очищаем T
		}
		¬озвращаем W
	}
	*/

	static Automata random(int numStates, int numLetters)
	{
		vector<int> states;
		for (int i = 0; i < numStates; ++i)
			states.push_back(i);

		string letters;
		for (int i = 0; i < numLetters; ++i)
			letters += char('a' + i);

		map<int, map<char, int>> transitions;
		for (int i = 0; i < numStates; ++i)
			for (int j = 0; j < numLetters; ++j)
				transitions[i]['a' + j] = rand() % numStates;

		return Automata(states, letters, transitions);
	}

	void output()
	{
		cout << "States: ";
		for (int i = 0, n = _states.size(); i < n; ++i)
			cout << _states[i] << ' ';
		cout << endl;

		cout << "Language: ";
		for (int i = 0, n = _letters.size(); i < n; ++i)
			cout << _letters[i] << ' ';
		cout << endl;


		cout << "Transitions: " << endl << "   ";
		for (int j = 0, m = _letters.size(); j < m; ++j)
			cout << _letters[j] << ' ';
		cout << endl;

		for (int i = 0, n = _states.size(); i < n; ++i)
		{
			cout << _states[i] << ": ";
			for (int j = 0, m = _letters.size(); j < m; ++j)
				cout << _transitions[_states[i]][_letters[j]] << ' ';
			cout << endl;
		}
	}
};

