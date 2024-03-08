// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// V1.4

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
        
        Card card1 = new Card(Suit.Spades, 1);
        Card card2 = new Card(Suit.Hearts, 2);
        Card card3 = new Card(Suit.Clubs, 3);
        
        Player person = new Player(99, "Test Player 1");
        //person.hand.Add(new Card(Suit.Spades, 1));
        //player.hand.Add(card2);
        //player.hand.Add(card3);
        //Console.WriteLine(player);
        
    }
}

public class NinetyNineGame
{
    public Player[] players;
    public Deck deck;
    public Score[] cardValues = {
        new Score(1, 1),
        new Score(2, 2),
        new Score(3, 0),
        new Score(4, 0),
        new Score(5, 5),
        new Score(6, 6),
        new Score(7, 7),
        new Score(8, 8),
        new Score(9, 0),
        new Score(10, -10),
        new Score(11, 10),
        new Score(12, 10),
        new Score(13, 10)
    };
}

public struct Score 
{
    public int number;
    public int modifier;
    
    public Score(int number_, int modifier_)
    {
        number = number_;
        modifier = modifier_;
    }
}

public class Player 
{
    public List<Card> hand;
    public int maxHandSize;
    public string name;
    public int tokens;
    
    public Player(int handSize, string name_)
    {
        maxHandSize = handSize;
        name = name_;
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
    
    public override string ToString() // Returns string as a hand
    {
        int last = hand.Count - 1;
        string toReturn = name + " has";
        for (int i = 0; i < hand.Count; i++)
        {
            if (i == last)
            {
                toReturn += " and";
            }
            toReturn += " a " + hand[i];
            if (i < last)
            {
                toReturn += ",";
            }
        }
        toReturn += ".";
        return toReturn;
        
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
    
    public override string ToString()
    {
        return suit + " of " + number;
    }
}

public enum Suit 
{
    Spades = 4,
    Hearts = 3,
    Clubs = 2,
    Diamonds = 1
}
