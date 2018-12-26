using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata_sharp
{
    public class IcdfaLogic
    {
        public readonly int n = 6;
        public readonly int k = 2;
        public readonly int totalParts = 12;
        public readonly int startPart = 1;
        public readonly int countParts = 12;
        public int RowLength => (n - 1) * (n - 1) + 1;

        public readonly Dictionary<int,int[]> Lengths;

        private Task[] Tasks;

        public IcdfaLogic()
        {
            Tasks = new Task[countParts];
            Lengths = new Dictionary<int, int[]>(countParts);

        }

        public int[] GetLengths(int part)
        {
            if (part < 0 || part >= countParts) throw new ArgumentOutOfRangeException();
            return Lengths[part];
        }

        public void GetTotalLenghts(int[] array)
        {
            if (array == null || array.Length != RowLength) throw new ArgumentException();
            var values = Lengths.Values.ToArray();

            for (int j = 0; j < RowLength; j++)
                array[j] = 0;

            for (int i = 0; i < countParts; i++)
                for(int j = 0; j < RowLength; j++)
                    array[j] += values[i][j];
        }

        //public IcdfaLogic(int n,int k,int totalParts, int startPart, int countParts)
        //    :this()
        //{

        //}

        public async Task StartAsync()
        {
            Schedule();
            await Run();
        }

        [Obsolete("Use StartAsync")]
        public void Start()
        {
            Schedule();
            Run();
        }

        void Schedule()
        {
            int length = RowLength;
            for (int i = 0; i < countParts; i++)
            {
                Lengths.Add(i + startPart, new int[length]);
                Tasks[i] = CreateTask(i + startPart);
            }
        }

        Task CreateTask(int num)
        {
            return new Task(() => MainLogic(Lengths[num], num));
        }

        Task Run()
        {
            for (int i = 0; i < countParts; i++)
                Tasks[i].Start();
            return Task.WhenAll(Tasks);
        }

        private void MainLogic(int[] lengths, int part)
        {
            var generator = new Generator(n, k);
            int nm = n - 1;
            int km = k - 1;
            int nmm = n - 2;
            int count = 0;
            int i = 1;

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
                    if (i == totalParts)
                        i = 0;
                    generator.NextICDFA(nm, km);
                    i++;
                }
                generator.NextFlags(nmm);
            }
        }
        private int CountAll()
        {
            Generator temp = new Generator(n, k);
            int nm = n - 1;
            int km = k - 1;
            int nmm = n - 2;
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

        private void IcdfaGeneratorCreatePartLoop(int part, int parts)
        {
            List<int> lengths = new List<int>();

            int nm = n - 1;
            int km = k - 1;
            int nmm = n - 2;
            Generator generator = new Generator(n, k);
            int count = 0;
            int i = 1;

            //Generator temp = new Generator(n, k);
            //int count_all = 0;
            //while (!temp.IsLastFlags)
            //{
            //    while (!temp.IsLastSequences)
            //    {
            //        count_all++;
            //        temp.NextICDFA(nm, km);
            //    }
            //    temp.NextFlags(nmm);
            //}

            //for (int j = 0, t = nm * nm + 1; j < t; ++j)
            //    lengths.Add(0);


            //while (!generator.IsLastFlags && i != part)
            //{
            //    while (!generator.IsLastSequences && i != part)
            //    {
            //        i++;
            //        generator.NextICDFA(nm, km);
            //    }
            //    generator.NextFlags(nmm);
            //}

            //i = 1;
            //while (!generator.IsLastFlags)
            //{
            //    while (!generator.IsLastSequences)
            //    {
            //        count++;
            //        if (i == part)
            //            lengths[generator.getWordLength()]++;
            //        if (i == parts)
            //            i = 0;
            //        generator.NextICDFA(nm, km);
            //        i++;
            //    }
            //    generator.NextFlags(nmm);
            //}


        }
    }
}
