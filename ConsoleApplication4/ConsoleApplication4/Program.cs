using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //deck of card ordered by suits followed by value
            //Query Syntax
            /*var startingDeck = from s in Suits()
                    from r in Ranks()
                    select new {Suit = s, Rank = r};
            */     
            //Method Syntax
            var startingDeck = Suits().SelectMany(suit => 
                Ranks().Select(rank => 
                    new { Suit = suit, Rank = rank }));


            //Take method return a specified number of contiguous elements from the start of a sequence
            var top = startingDeck.Take(26);
            
            //Skip method bypasses a specified number of elements in a sequence and then returns the remaining elements.
            var bottom = startingDeck.Skip(26);
            
            //using the extension method
            var shuffle = top.InterleaveSequenceWith(bottom);
            
            foreach (var card in shuffle)
            {
                Console.WriteLine(card);
            }


        }
        
        
        
        

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "2";
            yield return "3";
            yield return "4";
            yield return "5";
            yield return "6";
            yield return "7";
            yield return "8";
            yield return "9";
            yield return "10";
            yield return "J";
            yield return "Q";
            yield return "K";
            yield return "A";
        }
    }
}