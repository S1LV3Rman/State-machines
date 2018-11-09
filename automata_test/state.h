#pragma once
#include<string>
#include<map>

using std::string;

class state
{
private:
	std::string label; // Название состояния
	std::map<char, state*> nearStates; // Карта доступных состояний из текущего состояния 
public:
	state();
	state(string);

	~state();

	void addNearState(char, state*); // Добавить новое смежное состояние в карту
	state* stateViaSymbol(char); // Возвращает указатель на состояние по символу
	string getLabel();
};

