#include "state.h"



state::state() : label("")
{
}

state::state(string t) : label(t)
{
}


void state::addNearState(char symbol, state* nearState)
{
	nearStates.insert(std::pair<char, state*>(symbol, nearState));
}

state* state::stateViaSymbol(char symbol)
{
	state* temp = nearStates.at(symbol);
	return temp;
}

string state::getLabel()
{
	return label;
}


state::~state()
{
	label.clear();
	nearStates.clear();
}


