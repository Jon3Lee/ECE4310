// Banker's Algorithm 
#include <iostream> 
using namespace std;

// This is sub branch 1.
int main()
{
	// P0, P1, P2, P3, P4 are the Process names here 

	int  i, j, k;
	const int n = 3; // Number of processes 
	const int  m = 2; // Number of resources 
	int need[n][m];
	int allocation[3][1] = { { 0 }, // A // Allocation Matrix 
						{ 2 }, // B 
						{ 3 }, // C
		

	int max[3][2] = { { 7 }, // A // MAX Matrix 
					{ 3 }, // B
					{ 9 }, // C 
					

	int avail[3] = { 3, 3, 2 }; // Available Resources 

	int f[n],ans[n], ind = 0;
	for (k = 0; k < n; k++) {
		f[k] = 0;
	}

	for (i = 0; i < n; i++) {
		for (j = 0; j < m; j++)
			need[i][j] = max[i][j] - allocation[i][j];
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

	cout << "Following is the SAFE Sequence" << endl;
	for (i = 0; i < n - 1; i++)
		cout << " P" << ans[i] << " ->";
	cout << " P" << ans[n - 1] << endl;

	return (0);
}

// This code is contributed by SHUBHAMSINGH10 

