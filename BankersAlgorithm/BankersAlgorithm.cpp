#include <iostream> 
using namespace std;

#define n 3

bool SafeCheck(int free, int allocation[n], int max[n]);

int main()
{
    int input;    // The input that is put as variable k in the midterm.
    cout << "Please enter the k you would like to test for safety:" << std::endl;
    cin >> input;


    int allocation[n] = { 15,     // A // Allocation Matrix 
                         8 ,             // B 
                         7 };         // C



    int max[n] = { input,            // A // MAX Matrix 
                     24 ,                // B
                     30 };            // C 
    int free = 17;


    if (SafeCheck(free, allocation, max) == true)
    {
        cout << "That value of K allows for a safe sequence\n";
    }
    else
    {
        cout << "That value of k does not allow for a safe sequence\n";
    }

    max[0] = allocation[0];    //allocation[A] = 15
    while (SafeCheck(free, allocation, max) == true)
    {
        max[0] = max[0] + 1;
    }

    cout << "The range of safe values of k are: k <= " << max[0];
    cout << "\nThe range of unsafe values of k are k > " << max[0];


    return 0;

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