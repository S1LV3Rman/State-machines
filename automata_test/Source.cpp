#include "Automata.h"
#include <iostream>

using std::cout;
using std::endl;

int main()
{
	vector<int> states = { 0, 1, 2, 3 };

	vector<vector<int>> d = { {1, 1}, {1, 2}, {2, 3}, {3, 0} };

	Automata<int> a(states, "ab", d);
	
	string word = "abbababbba";

	cout << "Word: " << word << endl;

	set<int> s = { 0, 1, 2, 3 };

	s = a.d(s, word);

	for (auto i : s)
		cout << i << ' ';

	system("pause");

	return 0;
}