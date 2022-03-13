using System;

namespace Kitabxana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length;
            string lengthStr;

            Console.WriteLine("Kitablarin sayi:");
            lengthStr = Console.ReadLine();

            while (CheckInput(lengthStr) != true) {


                Console.WriteLine("Kitablarin sayi:");
                lengthStr = Console.ReadLine();

            }

            length = Convert.ToInt32(lengthStr);

            Book[] books = new Book[length];
            for (int i = 0; i < length; i++)
            {
                int no = GetInputInt($"{i + 1} Kitabin nomresi:", 0, 1000);

                string name = GetInputStr($"{i + 1} Kitabin Adi:", 3, 30);

                double price = GetinputDouble($"{i + 1} Kitabin Qiymeti:", 0, double.MaxValue);

                int count = GetInputInt($"{i + 1} Kitab sayi:", 0, int.MaxValue);

                string genre = GetInputGenre($"{i + 1} Kitabin Janri:",3 ,30);

                books[i] = new Book(no, name, price, genre);
                {
                    count = count;

                };

            }
            Console.WriteLine("\n================================\n");




            do
            {
                Console.WriteLine("\n\nHome:\n1.Butun kitablari goster");
                Console.WriteLine("2.Kitablari qiymete gore filterle");
                Console.WriteLine("3. Adi ile Filtrle daxil et:");
                Console.WriteLine("0. Proqrami bagla");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine("Books:");
                    for (int i = 0; i < books.Length; i++)
                    {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"{i + 1}.ci Kitab: ");
                        Console.WriteLine(books[i].GetInfo());
                    }
                    continue;

                }
                else if (input == 2)
                {
                    Console.WriteLine("Minimum Deyeri Daxil et ");
                    double minprice = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Maks Deyeri daxil et");
                    double maxprice = Convert.ToDouble(Console.ReadLine());


                    var filteredProducts = FilterByPrice(books, ref minprice, ref maxprice);

                    Console.WriteLine("Filtered products:");
                    foreach (var item in filteredProducts)
                    {
                        Console.WriteLine(item.GetInfo());
                    }


                }
                else if (input == 3)
                {
                    Console.WriteLine("Adi daxil edin :");
                    string name = Console.ReadLine();
                    FiteredBooksName(books, name);
                    var filteredProducts = FiteredBooksName(books, name);

                    Console.WriteLine("Axtarilan Kitab");
                    foreach (var item in filteredProducts)
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    continue;
                }
                else if (input == 0)
                {
                    break;
                }
                else
                    continue;



            } while (true);





        }
        static string GetInputStr(string name, int min, int max)
        {
            string input;


            do
            {
                Console.WriteLine(name);
                input = Console.ReadLine();

            } while (input.Length < 3 || input.Length > 30);

            return input;
        }
        static string GetInputGenre(string name , int min ,int max)
        {
            string input;


            do
            {
                Console.WriteLine(name);
                input = Console.ReadLine();

            } while (input.Length < 3 || input.Length > 30);

            while (CheckInputDouble(input)!=false)
            {
                Console.WriteLine(name);
                input = Console.ReadLine();
            }

            return input;



        }
        static int GetInputInt (string name , int min , int max)
        {
            string inputStr;
            int input;

            Console.WriteLine(name);
            inputStr = Console.ReadLine();

            while (CheckInput(inputStr)!=true)
            {
                Console.WriteLine(name);
                inputStr = Console.ReadLine();
            }
            input = Convert.ToInt32(inputStr);

            return input;

        }
        static double GetinputDouble(string name, double min ,double max)
        {
            string inputStr;
            double input;

            Console.WriteLine(name);
            inputStr = Console.ReadLine();
            while (CheckInputDouble(inputStr)!= true)
            {
                Console.WriteLine(name);
                inputStr = Console.ReadLine();
            }
            input= Convert.ToDouble(inputStr);
            


            return input;
        }

        static Book[] FilterByPrice(Book[] books, ref  double minPrice, ref double maxPrice)
        {
            Book[] filteredProducts = new Book [books.Length];
            int count = 0;


            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Price >= minPrice && books[i].Price <= maxPrice)
                {
                    filteredProducts[count] = books[i];
                    count++;
                }
            }

            Book[] newFilteredProducts = new Book [count];

            for (int i = 0; i < count; i++)
            {
                newFilteredProducts[i] = filteredProducts[i];
            }

            return newFilteredProducts;
        }

        static Book [] FiteredBooksName( Book [] books ,string name)
        {
            Book[] filteredProducts = new Book[books.Length];
            int count = 0;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Name == name )
                {
                    filteredProducts[count] = books[i];
                    count++;
                }
            }
            Book[] NewFilteredBook = new Book[count];
            for (int i = 0; i < count; i++)
            {
                NewFilteredBook[i] = filteredProducts[i];
            }
            return NewFilteredBook;

        }

        static bool CheckInput(string input)
        {
            char[] Arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Arr.Length; j++)
                {
                    if (input[i] == Arr[j])
                    {
                        count++;
                    }
                }
            }
            if (count == input.Length)
            {
                return true;
            }
            else
                return false;
        }
        static bool CheckInputDouble(string input)
        {
            char[] Arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.' };
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Arr.Length; j++)
                {
                    if (input[i] == Arr[j])
                    {
                        count++;
                    }
                }
            }
            if (count == input.Length)
            {
                return true;
            }
            else
                return false;
        }


    }
    
}
