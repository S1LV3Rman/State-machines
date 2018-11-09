#pragma once
#include<string>
#include<map>

using std::string;

class state
{
private:
	std::string label; // �������� ���������
	std::map<char, state*> nearStates; // ����� ��������� ��������� �� �������� ��������� 
public:
	state();
	state(string);

	~state();

	void addNearState(char, state*); // �������� ����� ������� ��������� � �����
	state* stateViaSymbol(char); // ���������� ��������� �� ��������� �� �������
	string getLabel();
};

