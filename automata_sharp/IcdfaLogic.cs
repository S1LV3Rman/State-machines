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
    /// <summary>
    /// Класс содержащий логику исполнения эксперемета Icdfa
    /// </summary>
    public class IcdfaLogic
    {
        public readonly int N;
        public readonly int K;
        /// <summary>
        /// Суммарное кол-во частей
        /// </summary>
        public readonly int TotalParts;
        /// <summary>
        /// Часть с которой необходимо начать выполнение
        /// </summary>
        public readonly int StartPart;
        /// <summary>
        /// Кол-во частей которые необходимо посчитать начиная c StartPart 
        /// </summary>
        public readonly int CountParts;

        public int RowLength => (N - 1) * (N - 1) + 1;
        /// <summary>
        /// Начало подсчета (Время вызова метода Run)
        /// </summary>
        public DateTime LaunchTime { private set; get; }

        /// <summary>
        /// Ключ - часть
        /// Значение - Подсчитанные значения для этой части
        /// </summary>
        public readonly Dictionary<int,int[]> Lengths;

        private Task[] Tasks;

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

            Tasks = new Task[countParts];
            Lengths = new Dictionary<int, int[]>(CountParts);
        }

        /// <summary>
        /// Возврашает одну часть
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public int[] GetLengths(int part)
        {
            if (part < StartPart || part >= CountParts + StartPart) throw new ArgumentOutOfRangeException();
            return Lengths[part];
        }

        //TODO: REMOVE. USE AND IMPROVE GetTotalLenghts
        public void GetTotalLenghts(ulong[] array)
        {
            if (array == null || array.Length != RowLength) throw new ArgumentException();
            var values = Lengths.Values.ToArray();

            for (int j = 0; j < RowLength; j++)
                array[j] = 0;

            for (int i = 0; i < CountParts; i++)
                for(int j = 0; j < RowLength; j++)
                    array[j] += Convert.ToUInt64(values[i][j]);
        }

        //TODO
        /// <summary>
        /// Суммирует все части
        /// </summary>
        /// <returns></returns>
        public ulong[] GetTotalLenghts()
        {
            var array = new ulong[RowLength];
            GetTotalLenghts(array);
            return array;
        }

        //TODO
        public ulong GetCurrentCount()
        {
            ulong sum = 0;
            foreach (var e in GetTotalLenghts())
                sum += e;
            return sum;
        }

        /// <summary>
        /// Запускает вычисления
        /// </summary>
        /// <returns>Задча вычисления</returns>
        public async Task StartAsync()
        {
            Schedule();
            await Run();
        }

        /// <summary>
        /// Планирует задачи.
        /// </summary>
        void Schedule()
        {
            int length = RowLength;
            for (int i = 0; i < CountParts; i++)
            {
                Lengths.Add(i + StartPart, new int[length]);
                Tasks[i] = CreateTask(i + StartPart);
            }
        }

        /// <summary>
        /// Создает задачу
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        Task CreateTask(int num)
        {
            return new Task(() => MainLogic(Lengths[num], num));
        }

        /// <summary>
        /// Запускает все задачи 
        /// </summary>
        /// <returns>Общая задача</returns>
        Task Run()
        {
            //GC.TryStartNoGCRegion(1024*1024*4);
            GCSettings.LatencyMode = GCLatencyMode.Interactive;
            //Запоминаем время запуска
            LaunchTime = DateTime.UtcNow;
            for (int i = 0; i < CountParts; i++)
            {
                Tasks[i].Start(PriorityScheduler.Lowest);//Запускаем все задачи с помощью кастомного планировщика
                /*Задаем минимальный приоритет по двум причинам:
                 - Смысла ебать пользователя нету, если пользователь захочет делать что то на фоне 
                    то он спокойно сможет это делать, хоть в игры играть, основной квант времени будет отдаваться более
                    приоритетным задачам
                 - Даем больше времени для потоков GC (на самом деле это очень критично, даже если мы поставим на normal то GC будет не успевать)
                 (посмотрим что будет на оптимизированном алгоритме)
                 */
            }

            //Возвращем задачу которая будет вывполнена после завершения всех вычислительных задач
            return Task.WhenAll(Tasks);
        }

        /// <summary>
        /// Логика вычисления части
        /// </summary>
        /// <param name="lengths"></param>
        /// <param name="part"></param>
        private void MainLogic(int[] lengths, int part)
        {
            var generator = new Generator(N, K);
            int nm = N - 1;
            int km = K - 1;
            int nmm = N - 2;
            int count = 0;
            int i = 1;
            int total = TotalParts;

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

        /// <summary>
        /// Считает суммарное кол-во автоматов
        /// </summary>
        /// <returns></returns>
        public ulong GetTotalCount()
        {
            Generator temp = new Generator(N, K);
            int nm = N - 1;
            int km = K - 1;
            int nmm = N - 2;
            ulong count_all = 0;

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
