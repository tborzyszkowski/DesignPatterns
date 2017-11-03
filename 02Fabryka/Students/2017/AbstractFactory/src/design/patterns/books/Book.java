package design.patterns.books;

import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public abstract class Book {

    private BookType bookType;
    private Binding binding;
    private Integer pages;
    private String author;
    private String publisher;

    public Book(BookType bookType, Binding binding, Integer pages, String author, String publisher) {
        this.bookType = bookType;
        this.binding = binding;
        this.pages = pages;
        this.author = author;
        this.publisher = publisher;
    }

    public void collecting(){
        System.out.println("Collecting order");
    }

    public void packing(){
        System.out.println("Packing order");
    }

    public void send(){
        System.out.println("Sending book");
    }

    @Override
    public String toString() {
        return "Book{" +
                "bookType=" + bookType +
                ", binding=" + binding +
                ", pages=" + pages +
                ", author='" + author + '\'' +
                ", publisher='" + publisher + '\'' +
                '}';
    }
}
