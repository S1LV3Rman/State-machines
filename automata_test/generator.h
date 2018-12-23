#pragma once
#include "automata.h"

class Generator
{
	vector<int> flags;
	vector<int> sequence;
	int numStates;
	int numLetters;
	bool isLastFlags;
	bool isLastSequences;

	bool containe(int a)
	{
		bool f = false;
		for (int i = 0, n = numStates - 1; !f && i < n; ++i)
			f = a == flags[i];

		return f;
	}

	int nearest(int a)
	{
		for (int i = numStates - 2; i >= 0; --i)
			if (flags[i] <= a)
				return flags[i];
		
		isLastSequences = true;
		return flags[0];
	}

	void resetSequences()
	{
		for (int i = 0, j = 0, n = numStates * numLetters; i < n; ++i)
		{
			if (j < numStates - 1 && i == flags[j])
				sequence[i] = ++j;
			else
				sequence[i] = 0;
		}
		isLastSequences = false;
	}

public:

	Generator()
	{
		numStates = 0;
		numLetters = 0;
		isLastFlags = false;
		isLastSequences = false;
	};

	Generator(int n, int k)
	{
		isLastFlags = false;

		numStates = n;
		numLetters = k;

		flags.resize(n - 1);
		sequence.resize(n * k);

		for (int i = 1; i < n; ++i)
			flags[i - 1] = k * i - 1;

		resetSequences();
	}
	
	void nextFlags(int i)
	{
		if (i == 0)
			if (flags[i] != 0)
			{
				--flags[i];
				resetSequences();
			}
			else
				isLastFlags = true;
		else
			if (flags[i] - 1 == flags[i - 1])
			{
				flags[i] = numLetters * (i + 1) - 1;
				nextFlags(i - 1);
			}
			else
			{
				flags[i] = flags[i] - 1;
				resetSequences();
			}
	}

	void nextICDFA(int a, int b)
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
		if (!isLastSequences)
			if (sequence[j] == sequence[m])
			{
				sequence[j] = 0;
				if (b == 0)
					nextICDFA(a - 1, numLetters - 1);
				else
					nextICDFA(a, b - 1);
			}
			else
				sequence[j] = sequence[j] + 1;

	}

	int getWordLength()
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
				transitions[i][letters[j]] = sequence[i * numLetters + j];

		Automata a(states, letters, transitions);

		string word = a.findShortestResetWord();

		return word.length();
	}

	bool lastFlags()
	{
		return isLastFlags;
	}

	bool lastSequences()
	{
		return isLastSequences;
	}

	void outputFlags()
	{
		cout << "Flags: ";
		for (int i = 0; i < numStates - 1; ++i)
			cout << flags[i] << ' ';
		cout << endl;
	}

	void outputSequences()
	{
		cout << "\tSecuences: ";
		for (int i = 0, n = numStates * numLetters; i < n; ++i)
			cout << sequence[i] << ' ';
		cout << endl;
	}
};