#pragma once
#include <string>
#include <map>

using std::string;
using std::map;
using std::pair;

class State
{
private:
	string label; // �������� ���������
	map<char, State*> transitions; // ����� ��������� � ������ ��������� 
public:
	State();
	State(string);

	~State();

	void addTransition(char, State*); // �������� ����� ������� � �����
	State* stateViaSymbol(char); // ���������� ��������� �� ��������� �� �������
	string getLabel();
};

