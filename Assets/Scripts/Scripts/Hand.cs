using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Hand : MonoBehaviour {

	//string of card names, value + suit, suits C D H S (alphabetical)
	public static string[] cardNames = new string[]{"2C","3C","4C","5C","6C","7C","8C","9C","10C","JC","QC","KC","AC","2D","3D","4D","5D","6D","7D","8D","9D","10D","JD","QD","KD","AD","2H","3H","4H","5H","6H","7H","8H","9H","10H","JH","QH","KH","AH","2S","3S","4S","5S","6S","7S","8S","9S","10S","JS","QS","KS","AS"};

	public static string[] pokerHandsArray = new string[]{"HIGH_CARD","PAIR","TWO_PAIR","THREE_OF_A_KIND","STRAIGHT","FLUSH","FULL_HOUSE","FOUR_OF_A_KIND","STRAIGHT_FLUSH"};

	public string[] cards;

	public List<string> twoCardList;
	public string[] commCardList= new string[5];

	//initializer

	//NEED TO MAKE THIS WORK FOR TWO CARD HAND, 5,6, AND 7!!!!!!!!
	public Hand(string[] cArray)
	{
		cards = cArray;
		commCardList[0] = cards[2];
		commCardList[1] = cards[3];
		commCardList[2] = cards[4];
		commCardList[3] = cards[5];
		commCardList[4] = cards[6];
		//this removes the 5 comm cards at the end of the list
		twoCardList = cards.ToList ();
		twoCardList.RemoveRange (2, 5);
	}
		
	List<int> cardsToSuitlessIntRanksList(string[] cardsToBeIntRanked) 
	{

		//USE A LIST INSTEAD OF ARRAY
		List<int> cardsRankInt = new List<int>();

		for (int i = 0; i < cardsToBeIntRanked .Length; i++) 
		{
			string cardSuitless = cardsToBeIntRanked[i];

			//remove last character from string (the suit)
			cardSuitless = cardSuitless.Substring(0, cardSuitless.Length - 1);

			//changing suitless face cards to a number for ranking. Used to check if numbers are in order
			if (cardSuitless == "J")
			{
				cardSuitless = "11";
			} else if (cardSuitless == "Q") {
				cardSuitless = "12";
			} else if (cardSuitless == "K") {
				cardSuitless = "13";

			} else if (cardSuitless == "A") {

				cardSuitless = "14";
			}

			//card value as an integer. int.Parse to convert string to int
			int cardRankInt = int.Parse(cardSuitless);
			cardsRankInt.Add(cardRankInt);


		}

		return cardsRankInt;        
	}

	//get the flush suit. If not flush, returns "N"
	string getFlushSuit()
	{
		//dictionary showing how many of each card suit there is		
		Dictionary<string,int> counts = new Dictionary<string,int>();
		List<string> cardsSuit = new List<string>();

		//create a list of the cards suit only
		for (var i = 0; i < cards.Length; i++)
		{
			string cardSuit = cards[i];
			cardSuit = cardSuit.Substring(cardSuit.Length-1);

			cardsSuit.Add(cardSuit);
		}

		//sort the suits alphabetically
		cardsSuit.Sort();

		//hashset of the suits present in hand (unique)
		HashSet<string> suitsUnique = new HashSet<string>(cardsSuit);

		string flushSuit = "N";

		//create dictionary of suit:number in hand
		//for each suit present, loop through array of playerCardsSuit and count how many of each suit 		
		foreach (string suit in suitsUnique)
		{
			int count = 0;

			for (int j = 0; j < cardsSuit.Count; j++)
			{
				if (cardsSuit[j] == suit)
				{
					count++;
				}
			}

			counts.Add (suit, count);

			//flush exists, get the flush suit
			if (count >= 5)
			{
				//isFlush = true;
				flushSuit = suit;
			}

			//reset count when going to a different suit
			count = 0;
		}

		return flushSuit;
	}


	double checkForMultiples()
	{

		//FIRST CHECKS FOR QUAD, THEN FULL HOUSE, THEN TRIPLE, THEN 2 PAIR, THEN 1 PAIR (THEN HIGH CARD IF EVERYTHING FALSE)

		//put cards into array of suitless int values
		List<int> cardsRankInt = cardsToSuitlessIntRanksList (cards);

		//sort rank values in high to low order
		cardsRankInt.Sort();
		cardsRankInt.Reverse();

		//get unique values of ranks and put in HashSet
		var intRanksUnique = new HashSet<int>(cardsRankInt);

		bool isTwoOfAKind = false;
		bool isThreeOfAKind = false;
		bool isFourOfAKind = false;
		bool isFullHouse = false;
		bool isTwoPair = false;

		int numberOfPairs = 0;
		int numberOfTriples = 0;

		//the ranks (independent of suit) of cards in pairs, triples and quads as Int
		List<int> pairValues = new List<int>();
		List<int> tripleValues = new List<int>();
		int quadValue = new int ();

		//create dictionary of int rank:number in hand
		Dictionary<int,int> counts = new Dictionary<int,int>();

		//for each rank present, loop through list of cardsRankInt and count how many of each rank 		
		foreach (int rank in intRanksUnique) 
		{
			int count = 0;

			for (int j = 0; j < cardsRankInt.Count; j++)
			{				
				//only works with sorted array
				if (cardsRankInt[j] == rank)
				{
					count++;
				}
			}

			//assign key:value pair to dictionary
			counts.Add(rank,count);

			if (count == 2)
			{
				isTwoOfAKind = true;

				pairValues.Add(rank);
				//alert("Pair Values: "+pairValues);

				numberOfPairs++;
				//alert("Number of pairs: "+numberOfPairs)

				//IF NUMBER OF PAIRS >= 2, two pair is true
				if (numberOfPairs >= 2)
				{
					isTwoPair = true;
				}
			}
			else if (count == 3)
			{
				isThreeOfAKind = true;
				numberOfTriples++;
				tripleValues.Add(rank);

				//alert("Number of 3 of a kinds: "+numberOfTriples);

				//IF NUMBER OF TRIPLES (3 OF A KIND) IS 2, FULL HOUSE
				if (numberOfTriples == 2)
				{
					isFullHouse = true;
					//alert("Full House! 2 triples");
				}
			}
			else if (count == 4)
			{
				isFourOfAKind = true;
				quadValue = rank;
				//alert("Four of a kind!");
			}

			//reset count when going to a different rank
			count = 0;
		}	//END FOR LOOP FOR EACH RANK

		//FULL HOUSE
		if (isTwoOfAKind && isThreeOfAKind)
		{
			isFullHouse = true;
			//print("full house");

		}

		//============CHECKING DIFFERENT CASES AND ASSIGNING HANDRANK======================

		//need this declaration inside of function to use it
		//var pokerHandsArray = ["HIGH_CARD","PAIR","TWO_PAIR","THREE_OF_A_KIND","STRAIGHT","FLUSH","FULL_HOUSE","FOUR_OF_A_KIND","STRAIGHT_FLUSH"];

		double handRank = -1;

		double divisor = 100f;
		if (isFourOfAKind)
		{

			handRank = System.Array.IndexOf(pokerHandsArray,"FOUR_OF_A_KIND");
			handRank += quadValue/divisor;

			divisor *= 100;

			//int counter = 0;
			//add the next highest card after the four-of-a-kind value to handRank
			foreach (int rank in intRanksUnique)
			{
				if (rank != quadValue)
				{
					handRank += rank/divisor;
					//counter++;
					break;
				}
			}

			//handRank = handRank.toFixed(2 + 2*counter);

			print("4kind hand rank: "+handRank);

			//alert("four of a kind " + handRank);

		}
		else if (isFullHouse)
	    {
	        handRank = System.Array.IndexOf(pokerHandsArray,"FULL_HOUSE");
	        
	        //CASE 2 TRIPLES
	        if (numberOfTriples == 2)
	        {
	            //use higher triple for 3 of a kind, other triple becomes the pair
				foreach (int tripleValue in tripleValues)
	            {
	                handRank += tripleValue/divisor;
	                
	                divisor *= 100;
	            }
	        }
	        else //triple and double
	        {
	            //append the three of a kind value, then the highest pair value
	            handRank += tripleValues[0]/divisor;
	            divisor *= 100;
	            handRank += pairValues[0]/divisor;
	        }
	        
	        //handRank = handRank.toFixed(4);
	        
	        //alert("full house: "+handRank);
	    }
	    else if (isThreeOfAKind)
	    {
			handRank = System.Array.IndexOf(pokerHandsArray,"THREE_OF_A_KIND");
	        handRank += tripleValues[0]/divisor;
	        
	        divisor *= 100;
	        
	        int counter = 0;
	        //add the next 2 highest cards after the three-of-a-kind value
			foreach (int rank in intRanksUnique)
	        {
				if (rank != tripleValues[0])
	            {
	                handRank += rank/divisor;
	                divisor *= 100;
	                counter++;
	            }
	            
	            //counter represents the number of cards added to handRank after the triple
	            if (counter == 2)
	            {
	                break;
	            }
	        }
	        
	        //handRank = handRank.toFixed(2 + 2*counter);
	        
	        //alert("Three of a kind: "+handRank);
	    }
	    else if (isTwoPair)
	    {
			handRank = System.Array.IndexOf(pokerHandsArray,"TWO_PAIR");
	        
			//if there are 3 pair values, remove lowest pair
			if (pairValues.Count == 3) {
			
				pairValues.RemoveAt (pairValues.Count - 1);
			
			}

	        //add the 2 pair values to handRank
			foreach (int pairValue in pairValues)
	        {
	            handRank += pairValue/divisor;
	            divisor *= 100;

	        }
	        
	        //find the highest 5th card in hand that is not one of the pairs in pairValues, add to handRank
			foreach (int rank in intRanksUnique)
	        {
				if (!pairValues.Contains(rank))
	            {
	                handRank += rank/divisor;
	                //counter++;
	                break;
	            }
	        }
	        
	        //handRank = handRank.toFixed(4 + 2*counter);
	        
	        //alert("2 pair: "+handRank);
	    }
	    else if (isTwoOfAKind)
	    {
			handRank = System.Array.IndexOf(pokerHandsArray,"PAIR");
	        
	        //add pair value to handRank
	        handRank += pairValues[0]/divisor;
	        
	        divisor *= 100;
	        
	        int counter = 0;
	        
	        //add values of 3 highest non-pair cards (in diminishing order) to handRank
			foreach (int rank in intRanksUnique)
	        {
				if (!pairValues.Contains(rank))
	            {
					handRank += rank/divisor;
	                divisor *= 100;
	                counter++;
	            }
	            
	            //counter represents the number of cards added after the only pair
	            if (counter == 3)
	            {
	                break;
	            }
	        }
	        
	        //handRank = handRank.toFixed(2 + 2*counter);
	        
	        //alert("pair: "+handRank);
	    }
	    else //HIGH_CARD
	    {
			handRank = System.Array.IndexOf(pokerHandsArray,"HIGH_CARD");
	        
	        int counter = 0;
	        //add values of up to 5 highest cards from highest to lowest to handRank
			foreach (int rank in intRanksUnique)
	        {
	            handRank += rank/divisor;
	            divisor *= 100;
	            counter++;
	            
	            if (counter == 5)
	            {
	            	break;
	            }
	        }
	        
	        //handRank = handRank.toFixed(2*counter);
	        //alert("high card: "+handRank);
	    }
			
		return handRank;

	}//CLOSE CHECKFORMULTIPLES FUNCTION

	List<string> getFlushCards(string flushSuit)
	{
		//initialize flush list as full player cards list, then remove non-flush cards
		List<string> flushCards = cards.ToList();

		//remove non-flush cards from flushCards. Must go through in reverse            
		for (int i=flushCards.Count-1; i>=0; i--)
		{
			string cardSuit = flushCards[i];
			cardSuit = cardSuit.Substring(cardSuit.Length-1);

			if (cardSuit != flushSuit)
			{
				flushCards.RemoveAt (i);
			}            
		}

		return flushCards;
	
	}

	//CHECK FOR FLUSH
	double checkForFlush() 
	{   

		bool isFlush = false;
		string flushSuit = getFlushSuit();

		//getFlushSuit returns "N" or the flush suit
		if (flushSuit != "N")
		{
			isFlush = true;
		}

		double handRank = -1;

		//eliminate non-flush cards from hand, put the rest in highest to lowest order, use top 5 in handRank
		if (isFlush)
		{
			handRank = System.Array.IndexOf(pokerHandsArray,"FLUSH");

			//list of the flush cards.
			List<string> flushCards = getFlushCards(flushSuit);

			//list of Int ranks of the flush cards. Put in high-to-low order
			List<int> flushCardsRankInt = cardsToSuitlessIntRanksList(flushCards.ToArray());
			flushCardsRankInt.Sort();
			flushCardsRankInt.Reverse();

			//divide the Int value by this number to add decimal amount to handRank
			double divisor = 100;


			int count = 0;
			//add values of ordered flush cards to hand rank. Only top 5 cards
			foreach (int rank in flushCardsRankInt)
			{            	
				count++;
				handRank += rank/divisor;
				divisor *= 100;

				if (count == 5) 
				{
					break;
				}
			}

			//handRank = handRank.toFixed(10);

			//alert("flush: "+handRank);
		}


		return handRank;
	}

	//CHECK FOR STRAIGHT	
	double checkForStraight()
	{

		List<int> cardsRankInt = cardsToSuitlessIntRanksList(cards);

		//sort rank values in high to low order
		cardsRankInt.Sort();
		cardsRankInt.Reverse();

		//get unique values of ranks and put in HashSet
		HashSet<int> intRanksUnique = new HashSet<int>(cardsRankInt);

		//intRanksUnique.ToList ();

		bool isStraight = false;

		double handRank = -1;

		//LOWEST STRAIGHT CASE: Ace becomes low card
		List<int> lowestStraight = new List<int>{14,2,3,4,5};

		//check if intRanksUnique is a superset of lowestStraight
		bool isLowStraight = intRanksUnique.IsSupersetOf(lowestStraight);

		//if intRanksUnique contains all elements in lowestStraight, change Ace value (14) to 1
		if (isLowStraight)
		{
			intRanksUnique.Remove (14);
			intRanksUnique.Add (1);

		}
		//LOWEST STRAIGHT CASE END

		int numberOfCardsInARow = 1;

		//put values in low to high order using a list
		List<int> intRanksUniqueList = intRanksUnique.ToList ();
		intRanksUniqueList.Sort ();

		//the saved number of cards in a row in the case of straight
		int actualNumberOfCardsInARow = new int();// = Int()

		//the index of the high card in the case of straight
		int indexOfStraightHighCard = new int(); // = Int()

		int i = 0;
		//increment through entire ranked list to see if 5 in a row
		while (i < intRanksUniqueList.Count-1)
		{
			if (intRanksUniqueList[i+1] - intRanksUniqueList[i] == 1)
			{
				numberOfCardsInARow++;
				if (numberOfCardsInARow >= 5)
				{
					actualNumberOfCardsInARow = numberOfCardsInARow;
					indexOfStraightHighCard = i+1;
				}

			} 
			else	//if cards not in a row, restart at 1
			{
				numberOfCardsInARow = 1;
			}

			i++;
		}

		if (actualNumberOfCardsInARow >= 5)
		{
			double divisor = 100;

			isStraight = true;
			handRank = System.Array.IndexOf(pokerHandsArray,"STRAIGHT");
			handRank += intRanksUniqueList[indexOfStraightHighCard]/divisor;

			//limit to 2 decimals
			//handRank = handRank.toFixed(2);
		}

		return handRank;		
	} 	//END CHECK FOR STRAIGHT

	//takes flush cards, sees if they make a straight. USE THE HIGHEST CARD AS RANK DESCRIPTOR
	double checkForStraightFlush()
	{

		bool isStraightFlush = false;

		double handRank = -1;

		//if hand is a flush and a straight
		if (Mathf.Floor((float)checkForFlush()) == System.Array.IndexOf(pokerHandsArray,"FLUSH") && Mathf.Floor((float)checkForStraight()) == System.Array.IndexOf(pokerHandsArray,"STRAIGHT"))
		{
			//alert("flush and straight");

			string flushSuit = getFlushSuit();
			//alert(flushSuit);

			//list of flush cards only
			List<string> flushCards = getFlushCards(flushSuit);

			//assign the flush card list (as array) as the current Hand's cards
			cards = flushCards.ToArray();

			//the hand rank of straight (if not straight, = -1). Need just the decimal value
			double handRankStraight = checkForStraight();

			//can only be straight flush if the flush cards are a straight
			if (handRankStraight != -1)
			{
				isStraightFlush = true;

				//use straight flush index .(high card of straight) for hand rank
				handRank = handRankStraight - System.Array.IndexOf(pokerHandsArray,"STRAIGHT") + System.Array.IndexOf(pokerHandsArray,"STRAIGHT_FLUSH");

				//handRank = handRank.toFixed(2);

				//alert("Straight flush: " +handRank)
			}
		}

		return handRank;
	}

	public string getRankstring() {

		if (Mathf.Floor((float)checkForStraightFlush()) == System.Array.IndexOf(pokerHandsArray, "STRAIGHT_FLUSH"))
		{
			return ("Straight Flush");
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "FOUR_OF_A_KIND"))
		{
			return ("4 of a Kind");
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "FULL_HOUSE"))
		{
			return ("Full House");
		}
		else if (Mathf.Floor((float)checkForFlush()) == System.Array.IndexOf(pokerHandsArray, "FLUSH"))
		{
			return ("Flush");
		}
		else if (Mathf.Floor((float)checkForStraight()) == System.Array.IndexOf(pokerHandsArray, "STRAIGHT"))
		{
			return ("Straight");
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "THREE_OF_A_KIND"))
		{
			return ("3 of a Kind");
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "TWO_PAIR"))
		{
			return ("2 Pair");
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "PAIR"))
		{
			return ("1 Pair");
		}
		else // if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray,"HIGH_CARD"))
		{
			return ("High Card");
		}
	}
	public double getRank()
	{

		if (Mathf.Floor((float)checkForStraightFlush()) == System.Array.IndexOf(pokerHandsArray, "STRAIGHT_FLUSH"))
		{
			print("Straight Flush Rank: " + checkForStraightFlush());
			return checkForStraightFlush();
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "FOUR_OF_A_KIND"))
		{
			print("4 of a Kind Rank: " + checkForMultiples());
			return checkForMultiples();
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "FULL_HOUSE"))
		{
			print("Full House Rank: " + checkForMultiples());
			return checkForMultiples();
		}
		else if (Mathf.Floor((float)checkForFlush()) == System.Array.IndexOf(pokerHandsArray, "FLUSH"))
		{
			print("Flush Rank: " + checkForFlush());
			return checkForFlush();
		}
		else if (Mathf.Floor((float)checkForStraight()) == System.Array.IndexOf(pokerHandsArray, "STRAIGHT"))
		{
			print("Straight Rank: " + checkForStraight());
			return checkForStraight();
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "THREE_OF_A_KIND"))
		{
			print("3 of a Kind Rank: " + checkForMultiples());
			return checkForMultiples();
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "TWO_PAIR"))
		{
			print("2 Pair Rank: " + checkForMultiples());
			return checkForMultiples();
		}
		else if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray, "PAIR"))
		{
			print("1 Pair Rank: " + checkForMultiples());
			return checkForMultiples();
		}
		else // if (Mathf.Floor((float)checkForMultiples()) == System.Array.IndexOf(pokerHandsArray,"HIGH_CARD"))
		{
			print("High Card Rank: " + checkForMultiples());
			return checkForMultiples();
		}
	}
	
}
