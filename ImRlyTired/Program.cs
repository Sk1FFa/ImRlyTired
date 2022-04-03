using System; //Содержит фундаментальные и базовые классы, определяющие часто используемые типы значений и ссылочных данных, события и обработчики событий, интерфейсы, атрибуты и исключения обработки.
using System.IO; //Содержит типы, позволяющие осуществлять чтение и запись в файлы

namespace FileSystem
{
    class Test1
    {
        static void Main()
        {
            Console.WriteLine("Другалёк, ты нолик нигде не вводи, а то я try-catch убрал.");

            Console.Write("Введите путь к директории файлов: ");
            var path = Console.ReadLine();                                                  //Путь к директории

            Console.Write("Введите кол-во случайных файлов, которые хотите создать: ");
            int count = int.Parse(Console.ReadLine());                                      // Кол-во файлов

            for (int i = 1; i <= count; i++)                                                // Цикл
            {
                string pathzero = @"";                                                      // Пуcтой путь к папке
                pathzero = System.IO.Path.Combine(pathzero, path);                          // Комбинирование пустого пути с путём пользователя
                string fileName = System.IO.Path.GetRandomFileName();                       // Создние случайного имени для файла
                pathzero = System.IO.Path.Combine(pathzero, fileName);                      // Комбинирование имени файла в путь
                Console.Write("Создан Файл: {0}\n", pathzero);                              // Название файла и вывод о создании
                System.IO.File.Create(pathzero);                                            // Создание файла
            }

            Console.Write("Введите первый фильтр поиска файлов: ");
            var filter1 = Console.ReadLine();

            Console.Write("Введите второй фильтр поиска файлов: ");
            var filter2 = Console.ReadLine();

            Console.Write("Введите третий фильтр поиска файлов: ");
            var filter3 = Console.ReadLine();

            //Н1Ф
            string catalogfilter1 = $@"\{filter1}";                                         //Путь каталога с именем первого фильтра
            string catalogfile1 = $"{path}{catalogfilter1}";                                //Путь К каталогу
            Directory.CreateDirectory(catalogfile1);                                        //Создание каталога

            foreach (var file in Directory.GetFiles(path, $"*{filter1}*.*"))                //Возвращает список файлов (с именем,расширением и путями) подходящих условию
            {
                var f1 = Path.GetFileName(file);                                            //Возвращает имя файла с расширением
                var ff1 = catalogfile1 + "/" + f1;                                          //Конечный путь для перемещения

                File.Move(file, ff1);                                                       //Перемещение
            }
            //К1Ф

            //Н2Ф
            string catalogfilter2 = $@"\{filter2}";
            string catalogfile2 = $"{path}{catalogfilter2}";
            Directory.CreateDirectory(catalogfile2);

            foreach (var file in Directory.GetFiles(path, $"*{filter2}*.*"))                //Тоже самое как и в первом фильтре
            {
                var f2 = Path.GetFileName(file);
                var ff2 = catalogfile2 + "/" + f2;

                File.Move(file, ff2);
            }
            //К2Ф

            //Н3Ф
            string catalogfilter3 = $@"\{filter3}";
            string catalogfile3 = $"{path}{catalogfilter3}";
            Directory.CreateDirectory(catalogfile3);

            foreach (var file in Directory.GetFiles(path, $"*{filter3}*.*"))                //Тоже самое как и в первом фильтре
            {
                var f3 = Path.GetFileName(file);
                var ff3 = catalogfile3 + "/" + f3;

                File.Move(file, ff3);
            }
            //К3Ф
        }
    }
}