#pragma once
#include"State.h"

class Automata
{
private:
	State* startState; // ��������� ��������� 
	State* currentState; // ������� ���������
public:
	Automata();
	Automata(State*);

	~Automata();

	State* inputWord(string); // ���� ����� � �������
	void reset(); // ����� �������� � ��������� ���������
	void setStart(State*); // ��������� ���������� ���������
};

