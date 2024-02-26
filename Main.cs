// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// V1.3

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
    }
}

static public class NinetyNineGame
{
    public Player[] players;
    public Deck deck;
    // public Score[] cardValues
}

public class Player 
{
    public List<Card> hand;
    public int maxHandSize;
    public string name;
    public int tokens;
    
    public Player(int handSize)
    {
        maxHandSize = handSize;
    }
    
    public void Discard(Deck deck, Card toDiscard)
    {
        hand.Remove(toDiscard);
        deck.Discard(toDiscard);
    }
    
    public void Draw(Deck deck)
    {
        if (hand.Count <= maxHandSize) 
        {
            Card drawn = deck.Draw();
            hand.Add(drawn);
        }
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
    
    public Card Draw()
    {
        Card drawn = drawPile[0];
        drawPile.RemoveAt(0);
        notInDeck.Add(drawn);
        return drawn;
    }
    
    public void Discard(Card toDiscard)
    {
        notInDeck.Remove(toDiscard);
        discardPile.Add(toDiscard);
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
