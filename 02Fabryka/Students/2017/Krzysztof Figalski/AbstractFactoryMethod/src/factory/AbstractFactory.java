package factory;

import covers.ICover;
import enums.Tittles;
import texts.IPages;

public abstract class AbstractFactory {

	public abstract ICover getCover(Tittles tittle);

	public abstract IPages getPages(Tittles tittle);

}
