using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automata_sharp
{
    public class IcdfaLogic
    {
        public readonly int N;
        public readonly int K;
        public readonly int TotalParts;
        public readonly int StartPart;
        public readonly int CountParts;

        public int RowLength => (N - 1) * (N - 1) + 1;
        public DateTime LaunchTime { private set; get; }

        public readonly Dictionary<int,int[]> Lengths;

        private Thread[] Threads;

        IcdfaLogic()
            :this(1,1,1,1,1)
        {
            
        }

        public IcdfaLogic(int n, int k, int totalParts, int startPart, int countParts)
        {
            N = n;
            K = k;
            TotalParts = totalParts;
            StartPart = startPart;
            CountParts = countParts;

            

            Threads = new Thread[countParts];
            Lengths = new Dictionary<int, int[]>(CountParts);
        }

        public int[] GetLengths(int part)
        {
            if (part < 0 || part >= CountParts) throw new ArgumentOutOfRangeException();
            return Lengths[part];
        }

        //TODO: REMOVE. USE AND IMPROVE GetTotalLenghts
        public void GetTotalLenghts(int[] array)
        {
            if (array == null || array.Length != RowLength) throw new ArgumentException();
            var values = Lengths.Values.ToArray();

            for (int j = 0; j < RowLength; j++)
                array[j] = 0;

            for (int i = 0; i < CountParts; i++)
                for(int j = 0; j < RowLength; j++)
                    array[j] += values[i][j];
        }

        //TODO
        public int[] GetTotalLenghts()
        {
            var array = new int[RowLength];
            GetTotalLenghts(array);
            return array;
        }

        //TOD
        public int GetCurrentCount()
        {
            int sum = 0;
            foreach (var e in GetTotalLenghts())
                sum += e;
            return sum;
        }

        public async Task StartAsync()
        {
            Schedule();
            await Run();
        }

        void Schedule()
        {
            int length = RowLength;
            for (int i = 0; i < CountParts; i++)
            {
                Lengths.Add(i + StartPart, new int[length]);
                Threads[i] = CreateThread(i + StartPart);
            }
        }

        Thread CreateThread(int num)
        {
            return new Thread(() => MainLogic(Lengths[num], num))
            {
                IsBackground = true,
                Priority = ThreadPriority.Lowest,
                Name = $"{nameof(IcdfaLogic)} Thread, Part№ {num} of {StartPart + CountParts - 1}"
            };
        }

        Task Run()
        {
            //GC.TryStartNoGCRegion(1024*1024*4);
            GCSettings.LatencyMode = GCLatencyMode.Interactive;
            LaunchTime = DateTime.UtcNow;
            for (int i = 0; i < CountParts; i++)
            {
                Threads[i].Start();
            }

            return new Task(()=> { Thread.Sleep(15000); });
        }

        private void MainLogic(int[] lengths, int part)
        {
            var generator = new Generator(N, K);
            int nm = N - 1;
            int km = K - 1;
            int nmm = N - 2;
            int count = 0;
            int i = 1;
            int total = TotalParts;

            
            while (!generator.IsLastFlags && i != part)
            {
                while (!generator.IsLastSequences && i != part)
                {
                    i++;
                    generator.NextICDFA(nm, km);
                }
                generator.NextFlags(nmm);
            }

            i = 1;
            while (!generator.IsLastFlags)
            {
                while (!generator.IsLastSequences)
                {
                    count++;
                    if (i == part)
                        lengths[generator.getWordLength()]++;
                    if (i == total)
                        i = 0;
                    generator.NextICDFA(nm, km);
                    i++;
                }
                generator.NextFlags(nmm);
            }
            

        }
        public int GetTotalCount()
        {
            Generator temp = new Generator(N, K);
            int nm = N - 1;
            int km = K - 1;
            int nmm = N - 2;
            int count_all = 0;

            while (!temp.IsLastFlags)
            {
                while (!temp.IsLastSequences)
                {
                    count_all++;
                    temp.NextICDFA(nm, km);
                }
                temp.NextFlags(nmm);
            }

            return count_all;
        }
    }
}
