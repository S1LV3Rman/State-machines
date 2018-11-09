#include "Automata.h"



Automata::Automata() : startState(nullptr), currentState(nullptr)
{
}

Automata::Automata(State* t) : startState(t), currentState(t)
{

}

Automata::~Automata()
{
}

State* Automata::inputWord(string word)
{
	for (unsigned int i = 0; i < word.length(); ++i)
	{
		currentState = currentState->stateViaSymbol(word[i]);
	}
	return currentState;
}

void Automata::reset()
{
	currentState = startState;
}

void Automata::setStart(State* t)
{
	startState = t;
	currentState = t;
}
