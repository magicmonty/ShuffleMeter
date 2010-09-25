
using System;
using CardLib.Cards;

namespace CardLib {


  public class NewDeckOrderStrategy: IShuffleStrategy {

    public NewDeckOrderStrategy() {
    }

    public void shuffle(CardDeck deck) {
      for (int i = 0; i < deck.Count; i++) {
        AbstractCard card = deck.getCardAt(i);
        if (!((card.faceSide is CardSide) && (card.backSide is BackSide))) {
          return;
        }
      }

      CardDeck tempDeck = new CardDeck();
      tempDeck.assign(deck);

      deck.clear();

      for (CardValue v = CardValue.Ace; v <= CardValue.King; v++) {
        for (int i = 0; i < tempDeck.Count; i++) {
          AbstractCard card = deck.getCardAt(i);
          AbstractSide cside = card.faceSide;

          if (cside is CardSide) {
            CardSide side = (CardSide) cside;
            if ((side.cardValue == v) && (side.suit == Suit.Hearts)) {
              deck.addCard(card);
            }
          }
        }
      }

      for (CardValue v = CardValue.Ace; v <= CardValue.King; v++) {
        for (int i = 0; i < tempDeck.Count; i++) {
          AbstractCard card = deck.getCardAt(i);
          AbstractSide cside = card.faceSide;

          if (cside is CardSide) {
            CardSide side = (CardSide) cside;
            if ((side.cardValue == v) && (side.suit == Suit.Clubs)) {
              deck.addCard(card);
            }
          }
        }
      }

      for (CardValue v = CardValue.King; v >= CardValue.Ace; v--) {
        for (int i = 0; i < tempDeck.Count; i++) {
          AbstractCard card = deck.getCardAt(i);
          AbstractSide cside = card.faceSide;

          if (cside is CardSide) {
            CardSide side = (CardSide) cside;
            if ((side.cardValue == v) && (side.suit == Suit.Diamonds)) {
              deck.addCard(card);
            }
          }
        }
      }

      for (CardValue v = CardValue.King; v >= CardValue.Ace; v--) {
        for (int i = 0; i < tempDeck.Count; i++) {
          AbstractCard card = deck.getCardAt(i);
          AbstractSide cside = card.faceSide;

          if (cside is CardSide) {
            CardSide side = (CardSide) cside;
            if ((side.cardValue == v) && (side.suit == Suit.Spades)) {
              deck.addCard(card);
            }
          }
        }
      }
    }
  }
}
