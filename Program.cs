using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapChuong5;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhập số phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Nhập các phần tử:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Phần tử [{i}]: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        if (n <= 0)
        {
            Console.WriteLine("Số phần tử không hợp lệ.");
            return;
        } else if (n == 1)
        {
            Console.WriteLine("Mảng chỉ có một phần tử, không thể thực hiện các thao tác yêu cầu.");
            return;
        }
        // 1. Đọc và in các phần tử trong mảng vừa nhập.
        Console.WriteLine("\n1. Mảng vừa nhập:");
        PrintArray(array);

        // 2. In mảng dữ liệu trên theo chiều đảo ngược.
        Console.WriteLine("\n2. Mảng theo chiều đảo ngược:");
       for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        // 3. Tìm số phần tử giống nhau trong mảng và hiển thị số lượng giống nhau ra màn hình.
        Console.WriteLine("\n3. Số phần tử giống nhau trong mảng:");
        DuplicatedElement(array);

        // 4. In các phần tử duy nhất trong mảng.
        Console.WriteLine("\n4. Các phần tử duy nhất trong mảng:");
        UniqueElements(array);

        // 5. Chia mảng dữ liệu ban đầu thành mảng chẵn và mảng lẻ.
        Console.WriteLine("\n5. Mảng chẵn và mảng lẻ:");
        var evenArray = array.Where(x => x % 2 == 0).ToArray();
        var oddArray = array.Where(x => x % 2 != 0).ToArray();
        Console.Write("Mảng chẵn: ");
        PrintArray(evenArray);
        Console.Write("Mảng lẻ: ");
        PrintArray(oddArray);

        // 6. Sắp xếp mảng theo thứ tự giảm dần.
        DescendedArray(array);

        // 7. Tìm kiếm phần tử lớn thứ hai trong mảng dữ liệu ban đầu.
        Console.WriteLine("\n7. Phần tử lớn thứ hai:");
        SecondLargestNumber(array);

        Console.ReadKey();
    }
    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }

    static Dictionary<int,int> GetDictionary(int[] arr)
    {
        var elementCounts = new Dictionary<int, int>();
        foreach (var item in arr)
        {
            if (elementCounts.ContainsKey(item))
                elementCounts[item]++;
            else
                elementCounts[item] = 1;
        }
        return elementCounts;
    }

    static void DuplicatedElement(int[] arr)
    {
        var dict = GetDictionary(arr);
        bool isDuplicated = false;
        foreach (var keyAndValue in dict)
        {
            if (keyAndValue.Value > 1)
            {
                Console.WriteLine($"Số {keyAndValue.Key} xuất hiện {keyAndValue.Value} lần");
                isDuplicated = true;
            }
        }
        if (!isDuplicated) Console.WriteLine("Không có phần tử nào bị trùng.");
    }

    static void UniqueElements(int[] arr)
    {
        var dict = GetDictionary(arr);
        var uniqueElements = dict.Where(keyAndValue => keyAndValue.Value == 1).Select(keyAndValue => keyAndValue.Key).ToArray();
        if (uniqueElements.Length > 0) Console.WriteLine(string.Join(" ", uniqueElements));
        else Console.WriteLine("Không có phần tử duy nhất nào.");
    }

    static void DescendedArray(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                Swap(arr, i, j);
            }
        }

        Console.WriteLine("\n6. Mảng sắp xếp giảm dần:");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }
    static void Swap(int[] arr, int i, int j)
    {
        if (arr[i] < arr[j])
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    static void SecondLargestNumber(int[] arr)
    {   
        var uniqueValues = arr.Distinct().OrderByDescending(x => x).ToList();

        int secondLargest = uniqueValues[1];
        int count = arr.Count(x => x == secondLargest);

        if (count > 1)
        {
            Console.WriteLine($"Mảng không có phần tử lớn thứ hai (vì số {secondLargest} bị lặp lại).");
        }
        else
        {
            Console.WriteLine($"Phần tử lớn thứ hai là: {secondLargest}");
        }
    
    }
    
}

