#include "Generator.h"
#include <conio.h>
#include <fstream>

using std::cin;
using std::to_string;

int main()
{
	char ch;
	int n, k;
	vector<int> lengths;

	do
	{
		system("cls");
		/*
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
		*/

		cout << "n = ";
		cin >> n;
		cout << "k = ";
		cin >> k;

		int count = 0;
		vector<int> lengths((n - 1)*(n - 1) + 1);

		Generator generator(n, k);

		while (!generator.lastFlags())
		{
			while(!generator.lastSequences())
			{
				count++;
				lengths[generator.getWordLength()]++;
				generator.nextICDFA(n - 1, k - 1);
			}
			cout << count << endl;
			generator.nextFlags(n - 2);
		}
		cout << "Done!" << endl << endl;

		string filename = "Protocol" + to_string(n) + "x" + to_string(k) + ".txt";

		std::ofstream out(filename);

		for (int i = 0, m = lengths.size(); i < m; ++i)
			out << i << ": " << lengths[i] << endl;

		out.close();

		ch = _getch();
	} while (ch != 27);

	return 0;
}