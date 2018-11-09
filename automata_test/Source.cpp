#include "Automata.h"
#include <iostream>
#include <vector>

using std::cout;
using std::endl;
using std::vector;

int main()
{
	State s0("0");
	State s1("1");
	State s2("2");
	State s3("3");

	s0.addTransition('a', &s1);
	s0.addTransition('b', &s1);

	s1.addTransition('a', &s1);
	s1.addTransition('b', &s2);

	s2.addTransition('a', &s2);
	s2.addTransition('b', &s3);

	s3.addTransition('a', &s3);
	s3.addTransition('b', &s0);

	Automata a;
	
	string word = "abbababbba";

	cout << "Word: " << word << endl;

	vector<State*> States { &s0, &s1, &s2, &s3 };

	for (auto i : States)
	{
		a.setStart(i);
		cout << "Starting is " << i->getLabel() << ", ending is - " << (a.inputWord(word)->getLabel()) << endl;
	}

	system("pause");

	return 0;
}