using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace automata_sharp
{
    /// <summary>
    /// Класс содержащий логику исполнения эксперемета Icdfa
    /// </summary>
    public sealed class IcdfaLogic
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

        public readonly CancellationTokenSource CancellationTokenSource;

        public int RowLength => (N - 1) * (N - 1) + 1;
        /// <summary>
        /// Начало подсчета (Время вызова метода Run)
        /// </summary>
        public DateTime LaunchTime { private set; get; }

        /// <summary>
        /// Ключ - часть
        /// Значение - Подсчитанные значения для этой части
        /// </summary>
        public readonly Dictionary<int, ulong[]> Lengths;


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
            Lengths = new Dictionary<int, ulong[]>(CountParts);

            CancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Возврашает одну часть
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public ulong[] GetLengths(int part)
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
            checked
            {
                foreach (var e in GetTotalLenghts())
                    sum += e;
            }
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
                Lengths.Add(i + StartPart, new ulong[length]);
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
            return new Task(() => MainLogic(Lengths[num], num, CancellationTokenSource.Token));
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
        private void MainLogic(ulong[] lengths, int part)
        {
            var generator = new Generator(N, K);
            int nm = N - 1;
            int km = K - 1;
            int nmm = N - 2;
            ulong count = 0;
            int i = 1;
            int total = TotalParts;

            i = 1;
            while (!generator.IsLastFlags)
            {
                while (!generator.IsLastSequences)
                {
                    if (i == part)
                        lengths[generator.getWordLength()]++;
                    if (i == total)
                        i = 0;
                    generator.NextICDFA(nm, km);
                    checked
                    {
                        count++;
                    }
                    i++;
                }
                generator.NextFlags(nmm);
            }
        }

        private void MainLogic(ulong[] lengths, int part, CancellationToken cancellationToken)
        {
            var generator = new Generator(N, K);
            int nm = N - 1;
            int km = K - 1;
            int nmm = N - 2;
            ulong count = 0;
            int i = 1;
            int total = TotalParts;

            i = 1;
            while (!generator.IsLastFlags)
            {
                while (!generator.IsLastSequences)
                {
                    if (i == part)
                        lengths[generator.getWordLength()]++;
                    if (i == total)
                    {
                        i = 0;
                        if (cancellationToken.IsCancellationRequested)
                            return;
                    }
                    generator.NextICDFA(nm, km);
                    checked
                    {
                        count++;
                    }
                    i++;   
                }
                generator.NextFlags(nmm);
                
            }
        }

        public void Cancel()
        {
            CancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Считает суммарное кол-во автоматов
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use IcdfaHelper.GetTotalCountAsync")]
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
                    checked
                    {
                        count_all++;
                        temp.NextICDFA(nm, km);
                    }
                }
                temp.NextFlags(nmm);
            }

            return count_all;
        }
    }

    /// <summary>
    /// Класс содержащий тулзы Icdfa
    /// </summary>
    public static class IcdfaHelper
    {
        /// <summary>
        /// Путь к файлу с кэшем
        /// </summary>
        const string FILEPATH_CACHE = "CachedTotalCounts.cache";
        /// <summary>
        /// Словрь задач кэширования
        /// </summary>
        readonly static IDictionary<Tuple<int, int>, Task<ulong>> CachedTotalCounts;

        static IcdfaHelper()
        {
            CachedTotalCounts = new Dictionary<Tuple<int, int>, Task<ulong>>(10);
            //Загружаем кэш из файла
            LoadCache();
        }

        /// <summary>
        /// Возвращает кэш если тот существует и подсчитан, иначе веренет null
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ulong? GetTotalCountNullable(int n, int k)
        {
            //Запрашиваем задачу кэширования
            var task = GetTotalCountTask(n, k);
            //Если задача завершена возвращаем результат
            return task.IsCompleted ? (ulong?)task.GetAwaiter().GetResult() : null;
        }

        /// <summary>
        /// Возвращает задачу кэширования для заданных n и k
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Task<ulong> GetTotalCountTask(int n, int k)
        {
            if (n < 0 || k < 0) throw new ArgumentException();

            //Пытаемся получить данные из кэша 
            var key = new Tuple<int, int>(n,k);
            if(CachedTotalCounts.ContainsKey(key))
                //Если получается то возвращаем таску 
                return CachedTotalCounts[key];

            //Иначе создаем задачу
            var task = new Task<ulong>(() => GetTotalCount(n,k));
            //Запускаем
            task.Start(PriorityScheduler.AboveNormal);

            //Добавляем в словарь задач кэширования
            CachedTotalCounts.Add(key, task);

            //Подписываемся на завершение задачи
            //По завершению сохраняем кэш
            task.GetAwaiter().OnCompleted(SaveCache);

            return task;
        }

        /// <summary>
        /// Алгоритм подсчета
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static ulong GetTotalCount(int n, int k)
        {
            Generator temp = new Generator(n, k);
            int nm = n - 1;
            int km = k - 1;
            int nmm = n - 2;
            ulong count_all = 0;

            while (!temp.IsLastFlags)
            {
                while (!temp.IsLastSequences)
                {
                    checked
                    {
                        count_all++;
                        temp.NextICDFA(nm, km);
                    }
                }
                temp.NextFlags(nmm);
            }

            return count_all;
        }

        /// <summary>
        /// Сохранение кэша в файл
        /// </summary>
        private static void SaveCache()
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(new FileStream(FILEPATH_CACHE, FileMode.Create));
                /* Преобразуем в массив, потому что в процессе записи CachedTotalCounts может изминиться 
                (Это маловероятно, конечно, но возможно) */
                foreach (var e in CachedTotalCounts.ToArray())
                {
                    //Если задача кэширования завершена - можем записать ее в файл
                    if(e.Value.IsCompleted)
                        //Формат : N,K,TOTAL_COUNT
                        writer.WriteLine($"{e.Key.Item1},{e.Key.Item2},{e.Value.GetAwaiter().GetResult()}");
                }
            }
            //В любом случае нам нужно освободить системные ресурсы
            finally { writer?.Dispose(); }
        }
        private static void LoadCache()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(new FileStream(FILEPATH_CACHE, FileMode.OpenOrCreate));
                var temp = new Dictionary<Tuple<int, int>, ulong>(10);
                var readed = reader.ReadToEnd().Split('\n');
                reader.Close();
                
                foreach (var e in readed)
                {
                    //Разбиваем строчку на части по знаку ','
                    var args = e.Split(',');
                    //Если кол-во агрументов не рано 3, то пропускаем сторочку
                    if (args.Length != 3) continue;
                    //Записываем во временный словарь
                    temp.Add(new Tuple<int, int>(int.Parse(args[0]), int.Parse(args[1])), ulong.Parse(args[2]));
                }

                /* Переносим все данные из временного кэша в постоянный
                Временный кэш нужен из-за возможных проблем на этапе чтения и
                преобразования данных из файла. Если данные будут поврежденными 
                то в постоянном кэше могут быть не корректные данные
                */
                foreach(var e in temp)
                    CachedTotalCounts.Add(e.Key, Task.FromResult(e.Value));
            }
            //В любом случае нам нужно освободить системные ресурсы
            finally { reader?.Dispose(); }
        }
    }
}
