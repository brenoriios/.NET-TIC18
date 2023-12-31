﻿#region Exercicio 1

(string, int) createTuple(string nome, int idade){
    return (nome, idade);
}

Console.WriteLine($"{createTuple("Breno", 22)}");
Console.WriteLine($"{createTuple("João", 27)}");

#endregion

#region Exercicio 2

Func<int, int, int> sum = (a, b) => a + b;
Console.WriteLine($"Soma 22 com 27: {sum(22, 27)}");
Console.WriteLine($"Soma 18 com 32: {sum(18, 32)}");
Console.WriteLine($"Soma 9 com 12: {sum(9, 12)}");

#endregion

#region Exercicio 3

List<(string, int)> list = new() {
    ("Breno", 22),
    ("João", 27),
    ("Ana", 35),
    ("Maria", 20),
    ("Moisés", 18),
    ("Gabriel", 31)
};

Console.WriteLine($"{string.Join(", ", list.Where(person => person.Item2 > 30).ToList())}");

#endregion

#region Exercicio 4

int[] arrayIntegers = {1, 2, 3, 4, 5, 10, 20, 30, 40, 50};
var orderedEvenIntegers = arrayIntegers.Where(num => num % 2 == 0).OrderByDescending(num => num).ToList();
Console.WriteLine($"{string.Join(" ", orderedEvenIntegers)}");

#endregion

#region Exercicio 5

List<(string, float)> people = new() {
    ("Pessoa 1", 1.70f),
    ("Pessoa 2", 1.51f),
    ("Pessoa 3", 1.62f),
    ("Pessoa 4", 1.83f)
};

Console.WriteLine($"{people.Average(person => person.Item2)}");

#endregion