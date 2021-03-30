using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    
    public class SJN
    {
        //SJF(non-preemptive)
        static void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void arrangeArrival(int num, int[][] mat)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num - i - 1; j++)
                {
                    if (mat[j][1] > mat[j + 1][1])
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            swap(mat[j][k], mat[j + 1][k]);
                        }
                    }
                }
            }
        }

        static void completionTime(int num, int[][] mat)
        {
            int temp, val = 0;
            mat[0][3] = mat[0][1] + mat[0][2];
            mat[0][5] = mat[0][3] - mat[0][1];
            mat[0][4] = mat[0][5] - mat[0][2];

            for (int i = 1; i < num; i++)
            {
                temp = mat[i - 1][3];
                int low = mat[i][2];
                for (int j = i; j < num; j++)
                {
                    if (temp >= mat[j][1] && low >= mat[j][2])
                    {
                        low = mat[j][2];
                        val = j;
                    }
                }
                mat[val][3] = temp + mat[val][2];
                mat[val][5] = mat[val][3] - mat[val][1];
                mat[val][4] = mat[val][5] - mat[val][2];
                for (int k = 0; k < 6; k++)
                {
                    swap(mat[val][k], mat[i][k]);
                }
            }
        }
        //SJF(preemtive)
        // Method to find the waiting 
        // time for all processes
        // Method to calculate turn around time
        /*
        static void findTurnAroundTime(Process[] proc, int n,
                                int[] ct, int[] tat)
        {
            // calculating turnaround time by subtracting ct - art
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = wt[i] - proc[i].bt + wt[i];
        }

        // Method to calculate average time
        public void findavgTime(Process[] proc, int n)  //print
        {
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_ct = 0, total_tat = 0;

            // Function to find waiting time of all
            // processes
            completionTime(proc, n, ct);

            // Function to find turn around time for
            // all processes
            findTurnAroundTime(proc, n, wt, tat);

            // Display processes along with all
            // details
            Console.WriteLine("Processes " +
                            " Burst time " +
                            " Waiting time " +
                            " Turn around time");

            // Calculate total waiting time and
            // total turnaround time
            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].bt + "\t\t " + wt[i]
                                + "\t\t" + tat[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
        */
    }
}
