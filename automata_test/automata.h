#pragma once
#include"State.h"

class Automata
{
private:
	State* startState; // Начальное состояние 
	State* currentState; // Текущее состояние
public:
	Automata();
	Automata(State*);

	~Automata();

	State* inputWord(string); // Ввод слова в автомат
	void reset(); // Сброс автомата в начальное состояние
	void setStart(State*); // Установка начального состояния
};

