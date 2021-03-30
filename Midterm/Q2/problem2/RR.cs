using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class RR
    {
        // Method to find the waiting time
        // for all processes
        static void findWaitingTime(Process[] proc, int n,
                                        int[] wt)
        {
            int[] rt = new int[n];

            // Copy the burst time into rt[]
            for (int i = 0; i < n; i++)
                rt[i] = proc[i].bt;

            int t = 0;
            int quantum = 3;

            // Process until all processes gets
            // completed
            while (true)
            {
                bool done = true;

                // Traverse all processes one by
                // one repeatedly
                for (int i = 0; i < n; i++)
                {
                    // If burst time of a process
                    // is greater than 0 then only
                    // need to process further
                    if (rt[i] > 0)
                    {

                        // There is a pending process
                        done = false;

                        if (rt[i] > quantum)
                        {
                            // Increase the value of t i.e.
                            // shows how much time a process
                            // has been processed
                            t += quantum;

                            // Decrease the burst_time of 
                            // current process by quantum
                            rt[i] -= quantum;   //quantum
                        }

                        // If burst time is smaller than
                        // or equal to quantum. Last cycle
                        // for this process
                        else
                        {

                            // Increase the value of t i.e.
                            // shows how much time a process
                            // has been processed
                            t = t + rt[i];

                            // Waiting time is current
                            // time minus time used by 
                            // this process
                            wt[i] = t - proc[i].bt;

                            // As the process gets fully 
                            // executed make its remaining
                            // burst time = 0
                            rt[i] = 0;
                        }
                    }
                }

                // If all processes are done
                if (done == true)
                    break;
            }
        }
        // Method to calculate turn around time
        static void findTurnAroundTime(Process[] proc, int n,
                                int[] wt, int[] tat)
        {
            // calculating turnaround time by adding
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = proc[i].bt + wt[i];
        }

        // Method to calculate average time
        public void findavgTime(Process[] proc, int n)
        {
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;

            // Function to find waiting time of all
            // processes
            findWaitingTime(proc, n, wt);

            // Function to find turn around time for
            // all processes
            findTurnAroundTime(proc, n, wt, tat);

            // Display processes along with all
            // details
            Console.WriteLine("Processes " +
                            "\tArrival time " +
                            "\tBurst time " +
                            "\tPriority " +
                            "\tWaiting time " +
                            "\tTurn around time");

            // Calculate total waiting time and
            // total turnaround time
            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].art + "\t\t " + proc[i].bt + "\t\t " + proc[i].p + "\t\t " + wt[i]  //print format
                                + "\t\t" + tat[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
    }
}
