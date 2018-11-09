#include "State.h"



State::State() : label("")
{
}

State::State(string t) : label(t)
{
}


void State::addTransition(char symbol, State* state)
{
	transitions.insert(pair<char, State*>(symbol, state));
}

State* State::stateViaSymbol(char symbol)
{
	State* temp = transitions.at(symbol);
	return temp;
}

string State::getLabel()
{
	return label;
}


State::~State()
{
	label.clear();
	transitions.clear();
}


