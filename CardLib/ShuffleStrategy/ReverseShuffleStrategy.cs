
using System;

namespace CardLib {


  public class ReverseShuffleStrategy:IShuffleStrategy {

    private int reverseFrom;
    private int reverseTo;

    public ReverseShuffleStrategy(int reverseFrom, int reverseTo) {
      this.reverseFrom = reverseFrom;
      this.reverseTo = reverseTo;
    }

    public void shuffle(CardDeck deck) {
      if (deck != null && deck.Count > 1) {
        if (this.reverseFrom > this.reverseTo) {
          int temp = this.reverseFrom;
          this.reverseFrom = this.reverseTo;
          this.reverseTo = temp;
        }

        if (this.reverseFrom < 0) {
          this.reverseFrom = 0;
        }

        if (this.reverseTo > deck.Count - 1) {
          this.reverseTo = deck.Count - 1;
        }

        if (this.reverseFrom != this.reverseTo) {
          CardDeck tempDeck = new CardDeck();
          tempDeck.assign(deck);
          deck.clear();

          for (int i = 0; i < this.reverseFrom; i++) {
            deck.addCard(tempDeck.getCardAt(i));
          }

          for (int i = this.reverseTo; i >= this.reverseFrom; i--) {
            deck.addCard(tempDeck.getCardAt(i));
          }

          for (int i = this.reverseTo + 1; i < tempDeck.Count; i++) {
            deck.addCard(tempDeck.getCardAt(i));
          }
        }
      }
    }
  }
}
