using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class Program
    {
        //public service time
        public void findTurnAroundTime(Process[] proc, int n,
                                int[] wt, int[] tat)
        {
            // calculating turnaround time by adding
            // bt[i] + wt[i]
            for (int i = 0; i < n; i++)
                tat[i] = wt[i] + proc[i].art;   //wait + arrival
        }
        public static void Main(string[] args)
        {
            //Process list
            priorityScheduling myPQ = new priorityScheduling();
            Process[] proc = { new Process(1, 0, 6, 3),
                            new Process(2, 2, 8, 2),
                            new Process(3, 3, 7, 1),
                            new Process(4, 5, 3, 4)};
            Process[] proc1 = { new Process(1, 0, 6, 3),
                            new Process(2, 2, 8, 2),
                            new Process(3, 3, 7, 1),
                            new Process(4, 5, 3, 4)};
            Process[] proc2 = { new Process(1, 0, 6, 3),
                            new Process(2, 2, 8, 2),
                            new Process(3, 3, 7, 1),
                            new Process(4, 5, 3, 4)};
            Process[] proc3 = { new Process(1, 0, 6, 3),
                            new Process(2, 2, 8, 2),
                            new Process(3, 3, 7, 1),
                            new Process(4, 5, 3, 4)};
            Process[] proc4 = { new Process(1, 0, 6, 3),
                            new Process(2, 2, 8, 2),
                            new Process(3, 3, 7, 1),
                            new Process(4, 5, 3, 4)};
            //FCFS Table 1
            FCFS myFCFS = new FCFS();
            Console.WriteLine("FCFS:");
            myFCFS.findavgTime(proc, proc.Length);

            
            //SJN
            SJN mySJN = new SJN();
            Console.WriteLine("\nSJN:");
            mySJN.findavgTime(proc1, proc1.Length);

            //SRTF Table 3
            SRTF mySRTF = new SRTF();
            Console.WriteLine("\nSRTF:");
            mySRTF.findavgTime(proc2, proc2.Length);
            
            //RR Table 4
            // Time quantum
            //int quantum = 2;

            RR myRR = new RR();
            Console.WriteLine("\nRound Robin:");
            myRR.findavgTime(proc3, proc3.Length);
            
            //PQ Table 5
            Console.WriteLine("\nPriority Scheduling:");
            myPQ.findavgTime(proc4, proc4.Length);
            
        }
    }
}
