using OwnArrayList;

ArrayList<int> list = new ArrayList<int>(5);

list.Append(1);
list.Append(2);
list.Append(3);
list.Append(4);
list.Append(5);

Console.WriteLine(list[1]);
Console.WriteLine(list[0]);

Console.WriteLine(list.BinarySearch(-11));

Console.ReadKey();
