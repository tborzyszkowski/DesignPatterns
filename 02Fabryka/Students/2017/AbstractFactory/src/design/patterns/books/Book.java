package design.patterns.books;

import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;
import design.patterns.parts.authors.Authors;
import design.patterns.parts.publisher.Publisher;

public abstract class Book {

    protected BookType bookType;
    protected Integer pages;
    protected Authors author;
    protected Publisher publisher;

    public abstract void prepare();

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
                ", pages=" + pages +
                ", author='" + author + '\'' +
                ", publisher='" + publisher + '\'' +
                '}';
    }
}
