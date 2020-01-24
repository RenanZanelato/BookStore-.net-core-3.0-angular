import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthorEntity } from '../Entities/author.entity';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'bookstore-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit{
 title = 'modal2';
 editProfileForm: FormGroup;
 authors: AuthorEntity[]
 
 constructor(private fb: FormBuilder, private modalService: NgbModal) {}
 ngOnInit() {
  let authorTeste = new AuthorEntity();
  authorTeste.Name = "Joao";
  authorTeste.BooksAuthor = [];

  this.authors = [authorTeste];
  this.editProfileForm = this.fb.group({
   Name: ['']
  });
  
 }
 openModal(targetModal, author) {
   console.log(author.Name)
  this.modalService.open(targetModal, {
   centered: true,
   backdrop: 'static'
  });
 
  this.editProfileForm.patchValue({
   Name: author.Name
  });
 }
 onSubmit() {
  this.modalService.dismissAll();
  console.log("res:", this.editProfileForm.getRawValue());
 }
}