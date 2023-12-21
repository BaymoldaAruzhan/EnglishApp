using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp
{
    class Program
    {
        static Dictionary<string, string> vocabulary = new Dictionary<string, string> //Статический простой словарь 
        {
            {"Hello", "Привет"},
            {"Goodbye", "Прощай"},
            {"Cat", "Кошка"},
            {"Dog", "Собака"},
            {"Sun", "Солнце"},
            {"Apple", "Яблоко"},
            {"Banana", "Банан"},
            {"Tree", "Дерево"},
            {"Computer", "Компьютер"},
            {"Friend", "Друг"},
            {"Book", "Книга"},
            {"City", "Город"},
            {"Ocean", "Океан"},
            {"Mountain", "Гора"},
            {"Music", "Музыка"},
            {"Movie", "Фильм"},
            {"Coffee", "Кофе"},
            {"Rain", "Дождь"},
            {"Fire", "Огонь"},
            {"Star", "Звезда"},
            {"Moon", "Луна"},
        };

        static int score = 0;//переменное для считования правильных ответов (куиз,грамматический тест)

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в программу для изучения английского языка!");

            while (true)
            {
                ShowMenu();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nВыберите опцию:");
            Console.WriteLine("1. Изучение словаря");
            Console.WriteLine("2. Пройти квиз");
            Console.WriteLine("3. Грамматический тест");
            Console.WriteLine("4. Пропущенные буквы");
            Console.WriteLine("5. Выйти");
            Console.WriteLine("6. Добавление слова");
            Console.WriteLine("7. Сохранить словарь в файл");
            Console.WriteLine("8. Загрузить словарь из файла");

            int choice = GetChoice(1, 8);// вызов метода GetChoice

            switch (choice)
            {
                case 1:
                    LearnVocabulary();
                    break;
                case 2:
                    TakeQuiz();
                    break;
                case 3:
                    GrammarTest();
                    break;
                case 4:
                    MissingLetters();
                    break;
                case 5:
                    Environment.Exit(0);//успешное завершение программы 
                    break;
                case 6:
                    AddWordToVocabulary();
                    break;
                case 7:
                    SaveVocabularyToFile();
                    break;
                case 8:
                    LoadVocabularyFromFile();
                    break;
            }
        }

        static int GetChoice(int minValue, int maxValue)//запрашивает у пользователя ввод числа в заданном диапозоне и возвращает введенное значение
        {
            int choice;//содержить ввод пользователя
            while (true)//бесконечный цикл
            {
                Console.Write("Введите ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Пожалуйста, введите число от {minValue} до {maxValue}.");//бесконечно запрашивает корректный ввод
                }
            }
            return choice;//возвращается значение choise  
        }

        static void LearnVocabulary()
        {
            Console.WriteLine("\nСловарь слов:");

            foreach (var wordPair in vocabulary)
            {
                Console.WriteLine($"{wordPair.Key} - {wordPair.Value}");
            }

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в главное меню.");
            Console.ReadLine();
        }

        static void TakeQuiz()
        {
            Console.WriteLine("\nКвиз:");

            foreach (var wordPair in GetRandomWords())
            {
                AskQuestion(wordPair.Key, wordPair.Value);
            }

            Console.WriteLine($"\nПоздравляю! Вы завершили квиз. Ваш счет: {score}");

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в главное меню.");
            Console.ReadLine();
        }

        static IEnumerable<KeyValuePair<string, string>> GetRandomWords()
        {
            // Перемешиваем словарь для случайного порядка
            var shuffledVocabulary = vocabulary.OrderBy(x => Guid.NewGuid()).ToDictionary(item => item.Key, item => item.Value);

            // Берем первые несколько слов для квиза (в данном случае, первые 4)
            return shuffledVocabulary.Take(4);
        }

        static void AskQuestion(string englishWord, string correctTranslation)
        {
            Console.Write($"\nПереведите '{englishWord}' на русский: ");
            string userAnswer = Console.ReadLine();

            if (string.Equals(userAnswer, correctTranslation, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Верно!");
                score++;
            }
            else
            {
                Console.WriteLine($"Неверно. Правильный перевод: {correctTranslation}");
            }
        }

        static void GrammarTest()
        {
            Console.WriteLine("\nГрамматический тест:");

             // Вопрос 1
            Console.WriteLine("1. What ______ your name?");
            Console.WriteLine("a) is");
            Console.WriteLine("b) are");
            Console.WriteLine("c) am");

            char userAnswer1 = Console.ReadKey().KeyChar;//сохраняется значения введенное пользователем
            CheckAnswer(userAnswer1, 'a');

            // Вопрос 2
            Console.WriteLine("\n2. She _____ a teacher.");
            Console.WriteLine("a) is");
            Console.WriteLine("b) are");
            Console.WriteLine("c) am");

            char userAnswer2 = Console.ReadKey().KeyChar;
            CheckAnswer(userAnswer2, 'a');

            // Вопрос 3
            Console.WriteLine("\n3. They _______ from Canada.");
            Console.WriteLine("a) is");
            Console.WriteLine("b) are");
            Console.WriteLine("c) am");

            char userAnswer3 = Console.ReadKey().KeyChar;
            CheckAnswer(userAnswer3, 'b');

            // Вопрос 4
            Console.WriteLine("\n4. I have _____ interesting book.");
            Console.WriteLine("a) is");
            Console.WriteLine("b) are");
            Console.WriteLine("c) an");

            char userAnswer4 = Console.ReadKey().KeyChar;
            CheckAnswer(userAnswer4, 'c');

            // Вопрос 5
            Console.WriteLine("\n5. They are going _____ the park.");
            Console.WriteLine("a) to");
            Console.WriteLine("b) on");
            Console.WriteLine("c) in");

            char userAnswer5 = Console.ReadKey().KeyChar;
            CheckAnswer(userAnswer5, 'a');

            Console.WriteLine($"\nВаш текущий счет: {score}");

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в главное меню.");
            Console.ReadLine();
        }

        static void CheckAnswer(char userAnswer, char correctAnswer)
        {
             if (userAnswer == correctAnswer) //сравнивает корректный ответ с ответом пользователя
             {
                Console.WriteLine("\nВерно!");
                score++;
             }
             else
             {
                Console.WriteLine($"\nНеверно. Правильный ответ: {correctAnswer}");
              }
        }


        static void MissingLetters()//метод для нахождения пропущенных букв в словах
        {
            Console.WriteLine("\nПропущенные буквы:");

            foreach (var wordPair in vocabulary)
            {
                AskMissingLettersQuestion(wordPair.Key);
            }

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в главное меню.");
            Console.ReadLine();
        }

        static void AskMissingLettersQuestion(string englishWord)
        {
            // Заменяем случайную букву в слове на "_"
            Random random = new Random();
            int missingLetterIndex = random.Next(englishWord.Length);
            StringBuilder wordWithMissingLetter = new StringBuilder(englishWord);
            wordWithMissingLetter[missingLetterIndex] = '_';

            Console.Write($"Введите пропущенную букву в слове '{wordWithMissingLetter}': ");
            string userAnswer = Console.ReadLine();

            // Сравниваем введенную букву с пропущенной
            if (userAnswer.ToLower() == englishWord[missingLetterIndex].ToString().ToLower())
            {
                Console.WriteLine("Верно!");
                score++;
            }
            else
            {
                Console.WriteLine($"Неверно. Правильная буква: {englishWord[missingLetterIndex]}");
            }
        }

        static void AddWordToVocabulary()//добавление нового слова в словарь
        {
            Console.Write("Введите новое слово на английском: ");
            string newWord = Console.ReadLine();

            Console.Write("Введите перевод слова на русском: ");
            string translation = Console.ReadLine();

            // Проверяем, что слово ещё не существует в словаре
            if (!vocabulary.ContainsKey(newWord))
            {
                vocabulary.Add(newWord, translation);
                Console.WriteLine($"Слово '{newWord}' успешно добавлено в словарь.");
            }
            else
            {
                Console.WriteLine($"Слово '{newWord}' уже существует в словаре.");
            }
        }
        static void SaveVocabularyToFile()//сохранение словаря
        {
            using (StreamWriter writer = new StreamWriter("vocabulary.csv")) //для записи в файл "vocabulary.csv". Файл будет создан или перезаписан, если уже существует.
            {
                foreach (var wordPair in vocabulary)
                {
                    writer.WriteLine($"{wordPair.Key},{wordPair.Value}");
                }
            }

            Console.WriteLine("Словарь успешно сохранен в файле.");
        }

        static void LoadVocabularyFromFile()//выгрузка словаря
        {
            if (File.Exists("vocabulary.csv"))
            {
                vocabulary.Clear(); // Очищаем текущий словарь перед загрузкой новых данных

                using (StreamReader reader = new StreamReader("vocabulary.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            string word = parts[0].Trim();
                            string translation = parts[1].Trim();

                            vocabulary[word] = translation;
                        }
                    }
                }

                Console.WriteLine("Словарь успешно загружен из файла.");
            }
            else
            {
                Console.WriteLine("Файл со словарем не найден.");
            }
        }




    }
}