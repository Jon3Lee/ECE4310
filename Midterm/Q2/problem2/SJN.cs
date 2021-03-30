using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class SJN
    {
        public void findavgTime(Process[] proc, int n)
        {
            //sorting of burst times
            int i = 0;
            int j = 0;
            int temp = 0;
            int pos = 0;
            for (i = 0; i < n; i++)
            {
                pos = i;
                for (j = i + 1; j < n; j++)
                {
                    if (proc[j].bt < proc[pos].bt)
                        pos = j;
                }
                temp = proc[i].bt;
                proc[i].bt = proc[pos].bt;
                proc[pos].bt = temp;
                temp = proc[i].pid;
                proc[i].pid = proc[pos].pid;
                proc[pos].pid = temp;
            }
            //applying FCFS
            FCFS newFCFS = new FCFS();
            newFCFS.findavgTime(proc, n);
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
