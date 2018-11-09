#pragma once
#include"state.h"

class automata
{
private:
	state* startState; // Начальное состояние 
	state* currentState; // Текущее состояние
public:
	automata();
	automata(state*);

	~automata();

	state* inputWord(string); // Ввод слова в автомат
	void reset(); // Сброс автомата в начальное состояние
	void setStart(state*); // Установка начального состояния
};

