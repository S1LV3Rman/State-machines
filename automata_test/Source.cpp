#include "Automata.h"
#include <conio.h>

int main()
{
	char ch;

	do
	{
		system("cls");

		Automata a = Automata::random(4, 2);

		string sword = a.findShortestResetWord();
		string word = a.findResetWord();

		a.output();

		cout << endl << "Shortest reset word: " << sword << endl;
		cout << "Verification: " << endl;

		cout << "\tInput: ";
		vector<int> input = a.getStates();
		for (int i = 0, n = input.size(); i < n; ++i)
			cout << input[i] << ' ';
		cout << endl;

		cout << "\tOutput: ";
		vector<int> output = a.d(input, sword);
		for (int i = 0, n = output.size(); i < n; ++i)
			cout << output[i] << ' ';
		cout << endl;

		cout << endl << "Short reset word: " << word << endl;
		cout << "Verification: " << endl;

		cout << "\tInput: ";
		for (int i = 0, n = input.size(); i < n; ++i)
			cout << input[i] << ' ';
		cout << endl;

		cout << "\tOutput: ";
		output = a.d(input, word);
		for (int i = 0, n = output.size(); i < n; ++i)
			cout << output[i] << ' ';
		cout << endl;

		ch = _getch();
	} while (ch != 'q');

	return 0;
}