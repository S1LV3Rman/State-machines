#include "automata.h"
#include <iostream>
#include <vector>

using std::cout;
using std::endl;
using std::vector;

int main()
{
	state s0("0");
	state s1("1");
	state s2("2");
	state s3("3");

	s0.addNearState('a', &s1);
	s0.addNearState('b', &s1);

	s1.addNearState('a', &s1);
	s1.addNearState('b', &s2);

	s2.addNearState('a', &s2);
	s2.addNearState('b', &s3);

	s3.addNearState('a', &s3);
	s3.addNearState('b', &s0);

	automata a;
	
	string word = "abbbabbba";

	cout << "Word: " << word << endl;

	vector<state*> states { &s0, &s1, &s2, &s3 };

	for (auto i : states)
	{
		a.setStart(i);
		cout << "Starting is " << i->getLabel() << ", ending is - " << (a.inputWord(word)->getLabel()) << endl;
	}

	system("pause");

	return 0;
}