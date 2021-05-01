// report4problem4.cpp : This file contains the 'main' function. Program execution begins and ends there.
/*
Do simulations (write computer programs) for a restaurant with n1 = 10 tables, where 
the number of seats in each table ranges from 1 to n2 = 15 seats (i.e. you’ll have a nested loop, 
with the outer loop i = 1 to n1 = 10 looping through the tables, and the inner loop j = 1 to n2 = 15 
looping through the possible number of seats in each table). Assume the number of guest parties 
is n3 = 8, with the size of each party ranging from 1 to n4 = 7.

•	How many possible combinations are run by this simulation?
•	Among these combinations, how many can be satisfied by both first fit and best fit?
•	Among these combinations, how many can be satisfied by first fit only, but not best fit?
•	Among these combinations, how many can be satisfied by best fit only, but not first fit?
•	Among these combinations, how many can be satisfied by neither first fit nor best fit?

*/

#include <iostream>

using namespace std;

int main()
{
    cout << "Problem 4:\n";
    int n1 = 10;    //n1 = 10 tables
    int n2 = 15;    //n2 = 15 seats

    int n3 = 8; //num of guest parties
    int n4 = 7; //size of each party from 1 to n4 = 7

    int party_size = 0;
    int group_num = n3;
    int seats_available = 0;

    for (int i = 1; i <= n1; i++) { //a nested loop, with the outer loop i = 1 to n1 = 10 looping through the tables
        seats_available = n2;
        for (int j = n2; j >= 1; j--) { //and the inner loop j = 1 to n2 = 15 seats
            party_size = rand() % n4 + 1;
            if( group_num > 1 && seats_available >= party_size > 0)
            {
                seats_available -= party_size;
                cout << "Table # " << i << ": party of " << party_size << " with " << seats_available << " seats left at the table"
                    << "(group# " << group_num << ")" <<  endl;
                group_num--;
            }
        }
    }
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
