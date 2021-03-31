using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class SJN
    {
        static void findWaitingTime(Process[] proc, int n, int[] wt, int[] service_time)
        {
            service_time[0] = 0;
            wt[0] = 0;

            proc[1].bt = 7;
            proc[2].bt = 3;
            proc[3].bt = 8;

            // calculating waiting time
            for (int i = 1; i < n; i++)
            {
                // Add burst time of previous processes
                service_time[i] = service_time[i - 1] + proc[i - 1].bt;

                // Find waiting time for current process =
                // sum - at[i]
                wt[i] = service_time[i] - proc[i].art;

                // If waiting time for a process is in negative
                // that means it is already in the ready queue
                // before CPU becomes idle so its waiting time is 0
                if (wt[i] < 0)
                    wt[i] = 0;
            }
        }


        //SJF(preemtive)
        public void findavgTime(Process[] proc, int n)
        {
            int[] service_time = new int[n];    //serv
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;

            // Function to find waiting time of all
            // processes
            findWaitingTime(proc, n, wt, service_time);

            // Function to find turn around time for
            // all processes
            //findTurnAroundTime(proc, n, wt, tat);

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
                //service_time = wt[i] + proc[i].art;
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].art + "\t\t " + proc[i].bt + "\t\t" + service_time[i] + "\t\t " + proc[i].p
                                + "\t\t" + wt[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
    }
}
