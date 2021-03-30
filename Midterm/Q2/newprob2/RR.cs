using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    //Preemptive
    public class RR
    {
        // Method to find the waiting time
        // for all processes
        static void findWaitingTime(Process[] proc,
             int n, int[] wt)
        {
            int quantum = 3;

            // Make a copy of burst times bt[] to 
            // store remaining burst times.
            int[] rem_bt = new int[n];

            for (int i = 0; i < n; i++)
                rem_bt[i] = proc[i].bt;

            int t = 0; // Current time

            // Keep traversing processes in round
            // robin manner until all of them are
            // not done.
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
                    if (rem_bt[i] > 0)
                    {

                        // There is a pending process
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            // Increase the value of t i.e.
                            // shows how much time a process
                            // has been processed
                            t += quantum;

                            // Decrease the burst_time of 
                            // current process by quantum
                            rem_bt[i] -= quantum;
                        }

                        // If burst time is smaller than
                        // or equal to quantum. Last cycle
                        // for this process
                        else
                        {

                            // Increase the value of t i.e.
                            // shows how much time a process
                            // has been processed
                            t = t + rem_bt[i];

                            // Waiting time is current
                            // time minus time used by 
                            // this process
                            wt[i] = t - proc[i].bt;

                            // As the process gets fully 
                            // executed make its remaining
                            // burst time = 0
                            rem_bt[i] = 0;
                        }
                    }
                }

                // If all processes are done
                if (done == true)
                    break;
            }
        }

        // Method to calculate turn around time
        static void findTurnAroundTime(Process[] proc,
                   int n, int[] wt, int[] tat)
        {
            // calculating turnaround time by adding
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = proc[i].bt + wt[i];
        }

        //print
        public void findavgTime(Process[] proc, int n)
        {
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_wt = 0, total_tat = 0, service_time = 0;

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
                            "\tService time " +
                            "\tPriority " +
                            "\tWait time");

            // Calculate total waiting time and
            // total turnaround time
            for (int i = 0; i < n; i++)
            {
                //tat = wt
                //serv = wait - art
                total_wt += wt[i];
                total_tat += tat[i];
                service_time = wt[i] - proc[i].art;
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].art + "\t\t " + proc[i].bt + "\t\t" + tat[i] + "\t\t " + proc[i].p
                                + "\t\t" + wt[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
    }
}
