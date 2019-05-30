import java.util.ArrayList;

class BookIterator extends Iterator {
  BookAggregate aggregate;
  int position = 0;

  public BookIterator(BookAggregate aggregate) {
    this.aggregate = aggregate;
  }

  public Object First() {
    return aggregate.get(0);
  };

  public Object Next() {
    position++;
    return aggregate.get(position);
  };

  public Object CurrentItem() {
    return aggregate.get(position);
  };

  public boolean HasNext() {
    if (position < aggregate.Count()-1) return true;
    return false;
  };
}
