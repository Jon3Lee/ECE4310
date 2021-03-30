#include <iostream> 
using namespace std;

// sub branch 1
#define n 3

bool SafeCheck(int free, int allocation[n], int max[n]);
bool nSafeCheck(int N, int allocation[n], int max[n]);
bool mSafeCheck(int N, int allocation3[n], int max3[n]);

int main()
{
    int input;    // The input that is put as variable k in the midterm.
    cout << "Please enter the k you would like to test for safety:" << std::endl;
    cin >> input;

    int N;  // The N for part b.
    cout << "Please enter the N you would like to test for safety:" << std::endl;
    cin >> N;

    int M; 
    cout << "Please enter the M you would like to test for safety:" << endl;
    cin >> M;


    int allocation[n] = { 15,               // A // Allocation Matrix 
                         8 ,                // B 
                         7 };               // C

    int max[n] = { input,                   // A // MAX Matrix 
                     24 ,                   // B
                     30 };                  // C 
    int free = 17;


    int allocation2[n] = { 15,               // A // Allocation Matrix 
                         8 ,                // B 
                         7 };               // C

    int max2[n] = { 42,                   // A // MAX Matrix 
                     24 ,                   // B
                     30 };                  // C 
    int free2 = N;


    int allocation3[n] = { 15,               // A // Allocation Matrix 
                         M ,                // B 
                         7 };               // C

    int max3[n] = { 46,                   // A // MAX Matrix 
                    24,                   // B
                    30 };                  // C 
    int free3 = 14;


    if (SafeCheck(free, allocation, max) == true)
    {
        cout << "That value of K allows for a safe sequence\n";
    }
    else
    {
        cout << "That value of k does not allow for a safe sequence\n";
    }

    max[0] = allocation[0];    //allocation[A] = 15 into 'input'
    while (SafeCheck(free, allocation, max) == true)
    {
        max[0] = max[0] + 1;
    }

    cout << "The range of safe values of k are: k <= " << max[0];
    cout << "\nThe range of unsafe values of k are k > " << max[0] << endl;


    if (nSafeCheck(free2, allocation2, max2) == true) {
        cout << "\nThat value of N allows for a safe sequence." << endl;
    }
    else {
        cout << "That value of N does not allow for a safe sequence." << endl;
    }

    max2[0] = allocation2[0];
    while (nSafeCheck(free2, allocation2, max2) == true) {
        max2[0] = max2[0] + 1;
    }
    cout << "The range of safe values of N are: N <= " << max2[0];
    cout << "\nThe range of unsafe values of N are N > " << max2[0] << endl;

    if (mSafeCheck(free3, allocation3, max3) == true) {
        cout << "\nThat value of M allows for a safe sequence." << endl;
    }
    else {
        cout << "That value of M does not allow for a safe sequence." << endl;
    }

    max3[0] = allocation3[0];
    while (mSafeCheck(free3, allocation3, max3) == true) {
        max3[0] = max3[0] + 1;
    }
    cout << "The range of safe values of M are: M <= " << max3[0];
    cout << "\nThe range of unsafe values of M are M > " << max3[0];

    return 0;
}

   


bool nSafeCheck(int N, int allocation2[n], int max2[n]) {  // Checks the safety of n for part b.
    int flag = 0;
    int need[n];

    for (int i = 0; i < n; i++) {
        need[i] = max2[i] - allocation2[i];       // Finding the need from the max and available
    }

    for (int i = 0; i < n; i++)
    {
        if (N > need[i])
        {
            for (int j = 0; j < n; j++)
            {
                if ((j != i) && (N + allocation2[i] > need[j]))
                {
                    for (int k = 0; k < n; k++)
                    {
                        if ((k != i) && (k != j) && (N + allocation2[i] + allocation2[j] > need[k]))
                        {
                            return true;
                            flag = 1;
                        }
                    }
                }
            }
        }
    }
    if (flag == 0) {
        return false;
    }

}

bool mSafeCheck(int N, int allocation3[n], int max3[n]) {  // Checks the safety of n for part b.
    int flag = 0;
    int need[n];

    for (int i = 0; i < n; i++) {
        need[i] = max3[i] - allocation3[i];       // Finding the need from the max and available
    }

    for (int i = 0; i < n; i++)
    {
        if (N > need[i])
        {
            for (int j = 0; j < n; j++)
            {
                if ((j != i) && (N + allocation3[i] > need[j]))
                {
                    for (int k = 0; k < n; k++)
                    {
                        if ((k != i) && (k != j) && (N + allocation3[i] + allocation3[j] > need[k]))
                        {
                            return true;
                            flag = 1;
                        }
                    }
                }
            }
        }
    }
    if (flag == 0) {
        return false;
    }

}
bool SafeCheck(int free, int allocation[n], int max[n])
{
    int flag = 0;
    int need[n];

    for (int i = 0; i < n; i++)
    {
        need[i] = max[i] - allocation[i];    // Need = Max - Available
    }

    for (int i = 0; i < n; i++)
    {
        if (free > need[i])
        {
            for (int j = 0; j < n; j++)
            {
                if ((j != i) && (free + allocation[i] > need[j]))
                {
                    for (int k = 0; k < n; k++)
                    {
                        if ((k != i) && (k != j) && (free + allocation[i] + allocation[j] > need[k]))
                        {
                            return true;
                            flag = 1;
                        }
                    }
                }
            }
        }
    }
    if (flag == 0)
    {
        return false;
    }
}