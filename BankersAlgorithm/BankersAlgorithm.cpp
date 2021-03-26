// Banker's Algorithm 
#include <iostream> 
//using namespace std;

// This is sub branch 1.
int main()
{
	int input;	// The input that is put as variable k in the midterm.
	int  i, j, k;
	std::cout << "Please enter the k you would like to test for safety:" << std::endl;
	std::cin >> input;
	const int n = 3; // Number of processes 
	const int  m = 2; // Number of resources 
	int need[n][m];
	int allocation[3][1] = { { 15 }, // A // Allocation Matrix 
						{ 8 }, // B 
						{ 7 } }; // C
		

	int max[3][1] = { { 38 }, // A // MAX Matrix 
					{ 24 }, // B
					{ 30 } }; // C 
					

	int avail[1] = { 3 }; // Available Resources, or in the Midterm, it is "free"

	int f[n],ans[n], ind = 0;		
	for (k = 0; k < n; k++) {
		f[k] = 0;
	}

	for (i = 0; i < n; i++) {
		for (j = 0; j < m; j++)
			need[i][j] = max[i][j] - allocation[i][j];	// Need = Max - Available
	}
	int y = 0;
	for (k = 0; k < 5; k++) {
		for (i = 0; i < n; i++) {
			if (f[i] == 0) {

				int flag = 0;
				for (j = 0; j < m; j++) {
					if (need[i][j] > avail[j]) {
						flag = 1;
						break;
					}
				}

				if (flag == 0) {
					ans[ind++] = i;
					for (y = 0; y < m; y++)
						avail[y] += allocation[i][y];
					f[i] = 1;
				}
			}
		}
	}

	std::cout << "Following is the SAFE Sequence..." << std::endl;
	for (i = 0; i < n - 1; i++)
		//if (-500 <= input && input <= 500) {	// This does not work, please REVISE.
		//	std::cout << "The input: " << input << " is not safe!" << std::endl;
		//}
		//else {
			std::cout << " P" << ans[i] << " ->";
			std::cout << " P" << ans[n - 1] << std::endl;
		//}
	return (0);
}

// This code is contributed by SHUBHAMSINGH10 
// ADDITIONAL INFO: This code was modified by willt2021

