using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class priorityScheduling
    {
        // Function to find the waiting time for all
        // processes
        public void findWaitingTime(Process[] proc, int n, int[] wt)
        {
            //sorting of priority times
            int i = 0;
            int j = 0;
            Process temp = new Process(0, 0, 0, 0); //temp var
            int pos = 0;
            for (i = 0; i < n; i++)
            {
                pos = i;
                for (j = i + 1; j < n; j++)
                {
                    if (proc[j].p < proc[pos].p)
                        pos = j;
                }
                //sorting
                temp = proc[i];
                proc[i] = proc[pos];
                proc[pos] = temp;
            }
            // waiting time for first process is 0
            wt[0] = 0;

            // calculating waiting time
            for (i = 1; i < n; i++)
                wt[i] = proc[i - 1].bt + wt[i - 1]; //proc[i].art;

        }
        // Function to calculate turn around time
        //public service time
        public void findTurnAroundTime(Process[] proc, int n,
                                int[] wt, int[] tat)
        {
            // calculating turnaround time by adding
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = wt[i] + proc[i].art;   //wait + arrival
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
                service_time = tat[i] - proc[i].art;
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
