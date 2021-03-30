#include <iostream> 
using namespace std;

#define n 3

bool SafeCheck(int free, int allocation[n], int max[n]);

int main()
{
	int input;	// The input that is put as variable m in the midterm.
	cout << "Please enter the m you would like to test for safety:" << std::endl;
	cin >> input;

	int allocation[n] = { 15,			 // A // Allocation Matrix 
						 input ,			 // B 
						 7 };			 // C


	int max[n] = { 46,				// A // MAX Matrix 
					 24 ,				// B
					 30 };				// C 
	int free = 14;


	if (SafeCheck(free, allocation, max) == true)		// the funtion SafeCheck determines if there exists a safe sequence
	{
		cout << "That value of m allows for a safe sequence\n";
	}
	else
	{
		cout << "That value of m does not allow for a safe sequence\n";
	}

	allocation[1] = 0;
	while (SafeCheck(free, allocation, max) == false)	// this loop will check each incrementing m values
	{													// until there is a safe sequence
		allocation[1] = allocation[1] + 1;
	}

	cout << "The range of safe values of m are: m >= " << allocation[1];
	cout << "\nThe range of unsafe values of m are m < " << allocation[1];

	return 0;
}

bool SafeCheck(int free, int allocation[n], int max[n])
{
	int flag = 0;
	int need[n];

	for (int i = 0; i < n; i++)				// this loop calculates the need matrix
	{
		need[i] = max[i] - allocation[i];	// Need = Max - Available
	}
	for (int i = 0; i < n; i++)				// for each process
	{
		if (free >= need[i])					// check if any process can be completed
		{
			for (int j = 0; j < n; j++)		// for each process
			{
				if ((j != i) && (free + allocation[i] >= need[j]))	// check if a second process can be completed
				{
					for (int k = 0; k < n; k++)						// for each process
					{
						if ((k != i) && (k != j) && (free + allocation[i] + allocation[j] >= need[k]))	//check if the third process can be completed
						{
							return true;							// if yes then the sequence is safe
							flag = 1;
						}
					}
				}
			}
		}
	}
	if (flag == 0)							// if not then the sequence is unsafe
	{
		return false;
	}
}