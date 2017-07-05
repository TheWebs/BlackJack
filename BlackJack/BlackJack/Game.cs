using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Game //TODO: REPLACE QUEEN, ACE, KING, JACK with proper game values (special values in blackJack)
    {
        private const int MAX_CARDS = 52;
        private const int CARDS_PER_SUIT = 13; //yup, 9 cards numbered + queen + king + ace + jack xD
        private const int NUM_SUITS = 4;
        private int player1, player2, totalTurns, current;
        private bool turn;
        private Card[] deck;


        public Game()
        {
            current = 0;
            player1 = 0;
            player2 = 0;
            turn = true;
            totalTurns = 0;
            deck = createDeck();
        }

        public int getPlayer1()
        {
            return player1;
        }

        public int getPlayer2()
        {
            return player2;
        }

        public bool getTurn()
        {
            return turn;
        }

        public int getTotalTurns()
        {
            return totalTurns;
        }

        public void changeTurn()
        {
            turn = !turn;
        }

        public void increasePlayer(int player, int amount)
        {
            if (player == 1)
                player1 += amount;
            else
                player2 += amount;
        }

        public void increaseTotalTurns()
        {
            totalTurns++;
        }

        private Card[] createDeck()
        {
            Card[] cards = new Card[MAX_CARDS];
            int counter = 0;
            for (int i = 0; i < NUM_SUITS; i++) //loop through suits
            {
                for (int j = 0; j < CARDS_PER_SUIT; j++)
                {
                    Card temp = new Card(j+1, i);
                    cards[counter++] = temp;
                }
            }
            cards = scrambleDeck(cards);
            return cards;
        }

        private Card[] scrambleDeck(Card[] cards)
        {
            Random random = new Random((int)System.DateTime.Now.Ticks);
            int rnd;
            for (int i = 0; i < MAX_CARDS; i++)
            {
                rnd = random.Next(0, 52);
                Card auxiliar = cards[i];
                cards[i] = cards[rnd];
                cards[rnd] = auxiliar;
            }
            return cards;
        }

        public void testDeck()
        {
            for (int i = 0; i < MAX_CARDS; i++)
            {
                Console.WriteLine(deck[i].ToString());
            }
        }

        public Card turnCard() //worth it? yup cause we need to represent the suit in the main GUI
        {
            if (current < 52)
                return deck[current++];
            else
                return null;
        }

        public string getCurrentScore(int player)
        {
            if( player == 1)
                return string.Format("Player 1\n    {0}", player1);
            else
                return string.Format("Player 2\n    {0}", player2);
        }

        public bool checkIfBlow(int player)
        {
            if(player == 1)
            {
                if (player1 > 21)
                {
                    player1 = -1;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if (player2 > 21)
                {
                    player2 = -1;
                    return true;
                }
                else
                    return false;
            }
        }

        public int getWinner()
        {
            if (player1 > player2)
                return 1;
            else if (player2 > player1)
                return 2;
            else
                return 3;

        }

    }

    public class Card
    {
        private int number;
        private string suit;

        public Card(int number, int suit)
        {
            this.number = number;
            switch(suit)
            {
                case 0: //clubs xD
                    this.suit = "Clubs";
                    break;
                case 1: //coins
                    this.suit = "Coins";
                    break;
                case 2: //swords
                    this.suit = "Swords";
                    break;
                case 3: //cups
                    this.suit = "Cups";
                    break;
            }
        }

        public int getNumber()
        {
            return number;
        }

        public string getSuit()
        {
            return suit;
        }

        
        override public string ToString()
        {
            return string.Format("{0} - {1}", this.number, this.suit);
        }
    }
}
