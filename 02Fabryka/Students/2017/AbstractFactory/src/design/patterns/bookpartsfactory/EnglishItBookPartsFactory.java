package design.patterns.bookpartsfactory;

import design.patterns.parts.authors.Authors;
import design.patterns.parts.authors.StephenKing;
import design.patterns.parts.publisher.Publisher;
import design.patterns.parts.publisher.ScribnerPublisher;

public class EnglishItBookPartsFactory implements BookPartsFactory {

    @Override
    public int pageCount() {
        return 1104;
    }

    @Override
    public Authors getAuthor() {
        return new StephenKing();
    }

    @Override
    public Publisher getPublisher() {
        return new ScribnerPublisher();
    }
}
