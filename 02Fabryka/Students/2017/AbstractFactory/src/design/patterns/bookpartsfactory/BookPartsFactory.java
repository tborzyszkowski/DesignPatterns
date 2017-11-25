package design.patterns.bookpartsfactory;

import design.patterns.parts.authors.Authors;
import design.patterns.parts.publisher.Publisher;

public interface BookPartsFactory {

    int pageCount();
    Authors getAuthor();
    Publisher getPublisher();
}
