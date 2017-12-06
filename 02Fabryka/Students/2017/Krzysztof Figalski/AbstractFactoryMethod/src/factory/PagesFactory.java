package factory;

import covers.ICover;
import enums.Tittles;
import texts.ALittleLifePages;
import texts.IPages;
import texts.TheSistersBrothersPages;

public class PagesFactory extends AbstractFactory {

	@Override
	public ICover getCover(Tittles tittle) {
		return null;
	}

	@Override
	public IPages getPages(Tittles tittle) {

		if (tittle == null) {
			return null;
		} else if (tittle.equals(Tittles.A_LITTLE_LIFE)) {
			return new ALittleLifePages();
		} else if (tittle.equals(Tittles.THE_SISTER_BROTHERS)) {
			return new TheSistersBrothersPages();
		}

		return null;
	}

}
