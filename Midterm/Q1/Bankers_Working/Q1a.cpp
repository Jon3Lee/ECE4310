#include <iostream> 
using namespace std;

#define n 3

bool SafeCheck(int free, int allocation[n], int max[n]);

int main()
{
	int input;	// The input that is put as variable k in the midterm.
	cout << "Please enter the k you would like to test for safety:" << std::endl;
	cin >> input;

	int allocation[n] = {  15,			 // A // Allocation Matrix 
						 8 ,			 // B 
						 7  };			 // C
		

	int max[n] = {   input,				// A // MAX Matrix 
					 24 ,				// B
					 30 };				// C 
	int free = 17;


	if (SafeCheck(free,allocation,max) == true)		// the funtion SafeCheck determines if there exists a safe sequence
	{
		cout << "That value of k allows for a safe sequence\n";
	}
	else
	{
		cout << "That value of k does not allow for a safe sequence\n";
	}

	max[0] = allocation[0]; // max = alocation[A] = 15
	while (SafeCheck(free, allocation, max) == true)	// this loop will check each incrementing k values
	{													// until there is no longer a safe sequence
		max[0] = max[0] + 1;
	}

	cout << "The range of safe values of k are: k <= " << free ;
	cout << "\nThe range of unsafe values of k are k > " << free ;

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