#pragma once
#include <string>
#include <map>

using std::string;
using std::map;
using std::pair;

class State
{
private:
	string label; // Название состояния
	map<char, State*> transitions; // Карта переходов в другие состояния 
public:
	State();
	State(string);

	~State();

	void addTransition(char, State*); // Добавить новый переход в карту
	State* stateViaSymbol(char); // Возвращает указатель на состояние по символу
	string getLabel();
};

