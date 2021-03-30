﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class Process
    {
        public int pid; // Process ID
        public int bt; // Burst Time
        public int art; // Arrival Time
        public int p;   //priority

        public Process(int pid, int art, int bt, int p)
        {
            this.pid = pid;
            this.bt = bt;
            this.art = art;
            this.p = p;
        }
        //public Process(int pid, int bt, int p)
    }
    class SRTF
    {

        //SJF(preemtive)
        // Method to find the waiting 
        // time for all processes
        static void findWaitingTime(Process[] proc, int n, int[] wt)
        {
            int[] rt = new int[n];

            // Copy the burst time into rt[]
            for (int i = 0; i < n; i++)
                rt[i] = proc[i].bt;

            int complete = 0, t = 0, minm = int.MaxValue;
            int shortest = 0, finish_time;
            bool check = false;

            // Process until all processes gets
            // completed
            while (complete != n)
            {

                // Find process with minimum
                // remaining time among the
                // processes that arrives till the
                // current time`
                for (int j = 0; j < n; j++)
                {
                    if ((proc[j].art <= t) &&
                    (rt[j] < minm) && rt[j] > 0)
                    {
                        minm = rt[j];
                        shortest = j;
                        check = true;
                    }
                }

                if (check == false)
                {
                    t++;
                    continue;
                }

                // Reduce remaining time by one
                rt[shortest]--;

                // Update minimum
                minm = rt[shortest];
                if (minm == 0)
                    minm = int.MaxValue;

                // If a process gets completely
                // executed
                if (rt[shortest] == 0)
                {

                    // Increment complete
                    complete++;
                    check = false;

                    // Find finish time of current
                    // process
                    finish_time = t + 1;

                    // Calculate waiting time
                    wt[shortest] = finish_time -
                                proc[shortest].bt -
                                proc[shortest].art;

                    if (wt[shortest] < 0)
                        wt[shortest] = 0;
                }
                // Increment time
                t++;
            }
        }

        // Method to calculate turn around time
        static void findTurnAroundTime(Process[] proc, int n,
                                int[] wt, int[] tat)
        {
            // calculating turnaround time by adding
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = wt[i] + proc[i].bt;   //service - arrival
        }

        // Method to calculate average time
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
                service_time = wt[i] + proc[i].art;
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].art + "\t\t " + proc[i].bt + "\t\t" + service_time + "\t\t " + proc[i].p
                                + "\t\t" + wt[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
    }
}
