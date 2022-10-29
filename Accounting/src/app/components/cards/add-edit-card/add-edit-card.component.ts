import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Card } from 'src/app/models/card';
import { CardsService } from 'src/app/services/cards.service';

@Component({
  selector: 'app-add-edit-card',
  templateUrl: './add-edit-card.component.html',
  styleUrls: ['./add-edit-card.component.css']
})
export class AddEditCardComponent implements OnInit {
  //cardslist$!: Observable<Card[]>;
  cards: Card[] = [];
  card: Card = {
    id:'',
    cardHolderName: '',
    cardNumber:'',
    expiryMonth:'',
    expiryYear:'',
    cvc:''
  }
  constructor(private service:CardsService) { }

  ngOnInit() {
    //this.cardslist$ = this.service.getCardList();
    this.getCardList();
  }
  getCardList(){
    this.service.getCardList()
    .subscribe(
      res=>{
      this.cards = res;
    });
  }

  onSubmit(){
    //console.log(this.card)
    if(this.card.id === ''){
      this.service.addCard(this.card).subscribe(res=>{
        //console.log(res);
        this.getCardList();
        this.card = {
          id:'',
          cardHolderName: '',
          cardNumber:'',
          expiryMonth:'',
          expiryYear:'',
          cvc:''
        }
      });
    }else{
      this.updateCard(this.card);
    }
  }

  deleteCard(id: string){
    //console.log(id);
    this.service.deleteCard(id).subscribe(res=>{
      this.getCardList();
    });
  }

  populateForm(card: Card){
    console.log(card)
    this.card = card;
  }

  updateCard(card: Card){
    this.service.updateCard(card).subscribe(res=>{
      this.getCardList();
      this.card = {
        id:'',
        cardHolderName: '',
        cardNumber:'',
        expiryMonth:'',
        expiryYear:'',
        cvc:''
      }
    })
  }
}
