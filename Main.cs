// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// V1.2

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
    }
}

public class Deck
{
    public Suit[] possibleSuits;
    public int[] possibleNumbers;
    public List<Card> drawPile;
    public List<Card> discardPile;
    public List<Card> notInDeck;
    
    public Deck(Suit[] suits, int[] numbers)
    {
        for (int s = 0; s < suits.Length; s++)
        {
            for (int n = 0; n < numbers.Length; n++)
            {
                drawPile.Add(new Card(suits[s], numbers[n]));
            }
        }
    }
}

public class Card
{
    public Suit suit;
    public int number;
    
    public Card(Suit suit2, int number2)
    {
        suit = suit2;
        number = number2;
    }
}

public enum Suit 
{
    Spades = 4,
    Hearts = 3,
    Clubs = 2,
    Diamonds = 1
}
