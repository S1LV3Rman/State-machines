#include "automata.h"



automata::automata() : startState(nullptr), currentState(nullptr)
{
}

automata::automata(state* t) : startState(t), currentState(t)
{

}

automata::~automata()
{
}

state* automata::inputWord(string word)
{
	for (unsigned int i = 0; i < word.length(); ++i)
	{
		currentState = currentState->stateViaSymbol(word[i]);
	}
	return currentState;
}

void automata::reset()
{
	currentState = startState;
}

void automata::setStart(state* t)
{
	startState = t;
	currentState = t;
}
