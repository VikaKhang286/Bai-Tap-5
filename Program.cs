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
        }
        else if (n == 1)
        {
            Console.WriteLine("Mảng chỉ có một phần tử, không thể thực hiện các thao tác yêu cầu.");
            return;
        }
        // 1. Đọc và in các phần tử trong mảng vừa nhập.
        Console.WriteLine("\n1. Mảng vừa nhập:");
        PrintArray(array);

        // 2. In mảng dữ liệu trên theo chiều đảo ngược.
        Console.WriteLine("\n2. Mảng theo chiều đảo ngược:");
        ReverseArray(array);

        // 3. Tìm số phần tử giống nhau trong mảng và hiển thị số lượng giống nhau ra màn hình.
        Console.WriteLine("\n3. Số phần tử giống nhau trong mảng:");
        DuplicatedElement(array);

        // 4. In các phần tử duy nhất trong mảng.
        Console.WriteLine("\n4. Các phần tử duy nhất trong mảng:");
        UniqueElements(array);

        // 5. Chia mảng dữ liệu ban đầu thành mảng chẵn và mảng lẻ.
        Console.WriteLine("\n5. Mảng chẵn và mảng lẻ:");
        EvenOddSplitArray(array);

        // 6. Sắp xếp mảng theo thứ tự giảm dần.
        Console.WriteLine("\n6. Mảng sắp xếp giảm dần:");
        DescendedArray(array);

        // 7. Tìm kiếm phần tử lớn thứ hai trong mảng dữ liệu ban đầu.
        Console.WriteLine("\n7. Phần tử lớn thứ hai:");
        SecondLargestNumber(array, n);

        Console.ReadKey();
    }
    
    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }

    // 2. In mảng dữ liệu trên theo chiều đảo ngược.
    static void ReverseArray(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    // 3. Tìm số phần tử giống nhau trong mảng và hiển thị số lượng giống nhau ra màn hình.
    static void FoundElement(int[] arr, bool[] isFound, int i, int j, ref int count)
    {
        if (arr[i] == arr[j])
        {
            isFound[j] = true;
            count++;
        }
    }
    static void DuplicatedElement(int[] arr)
    {
        bool[] isFound = new bool[arr.Length];
        bool isDuplicated = false;

        for (int i = 0; i < arr.Length; i++)
        {
            if (isFound[i]) continue;

            int count = 1;
            for (int j = i + 1; j < arr.Length; j++)
            {
                FoundElement(arr, isFound, i, j, ref count);
            }

            if (count > 1)
            {
                Console.WriteLine($"Số {arr[i]} xuất hiện {count} lần");
                isDuplicated = true;
            }
        }
        if (!isDuplicated) Console.WriteLine("Không có phần tử nào bị trùng.");
    }

    // 4. In các phần tử duy nhất trong mảng.
    static void UniqueElements(int[] arr)
    {
        bool isUnique = false;

        for (int i = 0; i < arr.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[i] == arr[j]) count++;
            }

            if (count == 1)
            {
                Console.Write(arr[i] + " ");
                isUnique = true;
            }
        }

        if (!isUnique) Console.WriteLine("Không có phần tử duy nhất nào.");
        else Console.WriteLine(); 
    }

    // 5. Chia mảng dữ liệu ban đầu thành mảng chẵn và mảng lẻ.
    static void EvenOddSplitArray(int[] arr)
    {
        int evenCount = 0, oddCount = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 0) evenCount++;
            else oddCount++;
        }

        int[] evenArr = new int[evenCount];
        int[] oddArr = new int[oddCount];

        int evenIndex = 0, oddIndex = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 0) evenArr[evenIndex++] = num;
            else oddArr[oddIndex++] = num;
        }

        Console.Write("Mảng chẵn: ");
        PrintArray(evenArr);
        Console.Write("Mảng lẻ: ");
        PrintArray(oddArr);
    }

    // 6. Sắp xếp mảng theo thứ tự giảm dần.
    static void DescendedArray(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                SwapInArray(arr, i, j);
            }
        }
        foreach (int num in arr) Console.Write(num + " ");
        Console.WriteLine();
    }
    static void SwapInArray(int[] arr, int i, int j)
    {
        if (arr[i] < arr[j])
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    // 7. Tìm kiếm phần tử lớn thứ hai trong mảng dữ liệu ban đầu.
    static void SecondLargestNumber(int[] arr, int n)
    {
        int firstMax = int.MinValue;
        int secondMax = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] > firstMax)
            {
                secondMax = firstMax;
                firstMax = arr[i];
            }
            else if (arr[i] > secondMax && arr[i] < firstMax)
            {
                secondMax = arr[i];
            }
        }
        if (secondMax == int.MinValue) Console.WriteLine("Không có phần tử lớn thứ hai.");
        else Console.WriteLine($"Phần tử lớn thứ hai là: {secondMax}");
    }
    
}

