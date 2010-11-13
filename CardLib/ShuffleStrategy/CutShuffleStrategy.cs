
using System;

namespace CardLib {


  public class CutShuffleStrategy: IShuffleStrategy {

    private int cutPosition;

    public CutShuffleStrategy(int cutPosition) {
      this.cutPosition = cutPosition;
    }

    public void shuffle(CardDeck deck) {
      if (deck != null && deck.Count > 0 && this.cutPosition >= 0 && this.cutPosition < deck.Count) {
        CardDeck tempDeck = new CardDeck();
        tempDeck.assign(deck);

        deck.clear();
        for (int i = this.cutPosition; i < tempDeck.Count; i++) {
          deck.addCard(tempDeck.getCardAt(i));
        }

        for (int i = 0; i < cutPosition; i++) {
          deck.addCard(tempDeck.getCardAt(i));
        }
      }
    }
  }
}
