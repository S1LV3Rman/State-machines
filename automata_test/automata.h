#pragma once
#include"state.h"

class automata
{
private:
	state* startState; // ��������� ��������� 
	state* currentState; // ������� ���������
public:
	automata();
	automata(state*);

	~automata();

	state* inputWord(string); // ���� ����� � �������
	void reset(); // ����� �������� � ��������� ���������
	void setStart(state*); // ��������� ���������� ���������
};

