using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Process list
            priorityScheduling myPQ = new priorityScheduling();
            Process[] proc = { new Process(1, 0, 6, 3),
                            new Process(2, 2, 8, 2),
                            new Process(3, 3, 7, 1),
                            new Process(4, 5, 3, 4)};

            //FCFS Table 1
            FCFS myFCFS = new FCFS();
            Console.WriteLine("FCFS:");
            myFCFS.findavgTime(proc, proc.Length);

            //SRTF Table 3
            SRTF mySRTF = new SRTF();
            Console.WriteLine("\nSRTF:");
            mySRTF.findavgTime(proc, proc.Length);

            //RR Table 4
            // Time quantum
            //int quantum = 2;

            RR myRR = new RR();
            Console.WriteLine("\nRound Robin:");
            myRR.findavgTime(proc, proc.Length);

            //PQ Table 5
            Console.WriteLine("\nPriority Scheduling:");
            myPQ.findavgTime(proc, proc.Length);

            /*
            //SJN
            int num, temp;

            cout << "Enter number of Process: ";
            cin >> num;

            cout << "...Enter the process ID...\n";
            for (int i = 0; i < num; i++)
            {
                cout << "...Process " << i + 1 << "...\n";
                cout << "Enter Process Id: ";
                cin >> mat[i][0];
                cout << "Enter Arrival Time: ";
                cin >> mat[i][1];
                cout << "Enter Burst Time: ";
                cin >> mat[i][2];
            }

            cout << "Before Arrange...\n";
            cout << "Process ID\tArrival Time\tBurst Time\n";
            for (int i = 0; i < num; i++)
            {
                cout << mat[i][0] << "\t\t" << mat[i][1] << "\t\t" << mat[i][2] << "\n";
            }

            arrangeArrival(num, mat);
            completionTime(num, mat);
            cout << "Final Result...\n";
            cout << "Process ID\tArrival Time\tBurst Time\tWaiting Time\tTurnaround Time\n";
            for (int i = 0; i < num; i++)
            {
                cout << mat[i][0] << "\t\t" << mat[i][1] << "\t\t" << mat[i][2] << "\t\t" << mat[i][4] << "\t\t" << mat[i][5] << "\n";
            }
            */
        }
    }
}
