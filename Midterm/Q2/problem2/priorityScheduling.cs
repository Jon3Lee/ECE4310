using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class priorityScheduling
    {

        // Function to sort the Process acc. to priority
        static bool comparison(Process a, Process b)
        {
            return (a.p > b.p);
        }
        // Function to find the waiting time for all
        // processes
        static void findWaitingTime(Process[] proc, int n, int[] wt)
        {
            // waiting time for first process is 0
            wt[0] = 0;

            // calculating waiting time
            for (int i = 1; i < n; i++)
                wt[i] = proc[i - 1].bt + wt[i - 1];
        }
        // Function to calculate turn around time
        static void findTurnAroundTime(Process[] proc, int n, int[] wt, int[] tat)
        {
            // calculating turnaround time by adding
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = proc[i].bt + wt[i];
        }

        //Function to calculate average time
        public void findavgTime(Process[] proc, int n)
        {
            int[] wt = new int[n];
            int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;

            //Function to find waiting time of all processes
            findWaitingTime(proc, n, wt);

            //Function to find turn around time for all processes
            findTurnAroundTime(proc, n, wt, tat);

            //Display processes along with all details
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
            /*
            sort(proc, proc + n, comparison);
            Console.WriteLine("Order in which processes gets executed");
            for (int i = 0; i < n; i++)
                Console.WriteLine(proc[i].pid + " ");
            */

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
    }
}
