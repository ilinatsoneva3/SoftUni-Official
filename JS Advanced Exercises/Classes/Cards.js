(function(){

    let Suits ={
        SPADES: "\U+2663",
        DIAMONDS: "\U+2666",
        HEARTS: "\U+2665",
        CLUBS: "\U+2660"
    }

    const cards = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card{
        constructor(face, suit){
            this.face = face;
            this.suit=suit;
        }

        get face(){
            return this._face;
        }

        set face(face){
            if(!cards.includes(face)){
                throw new Error("Invalid card face: " + face);
            }
            this._face = face;
        }

        get suit(){
            return this._suit;
        }

        set suit(suit){
            if(! Object.keys(Suits).map(k => Suits[k]).includes(suit)){
                throw new Error("Invalid card suit: " + suit);
            }
            this._suit=suit;
        }

        toString(){
            return `${this.value}${this.suit}`
        }
    }

    return {
        Suits, Card
    }
}())