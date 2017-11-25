package factory;

import covers.ALiitleLifeCover;
import covers.ICover;
import covers.TheSistersBrothersCover;
import enums.Tittles;
import texts.IPages;

public class CoverFactory extends AbstractFactory {

	@Override
	public ICover getCover(Tittles tittle) {

		if (tittle == null) {
			return null;
		} else if (tittle.equals(Tittles.A_LITTLE_LIFE)) {
			return new ALiitleLifeCover();
		} else if (tittle.equals(Tittles.THE_SISTER_BROTHERS)) {
			return new TheSistersBrothersCover();
		}

		return null;
	}

	@Override
	public IPages getPages(Tittles tittle) {
		return null;
	}

}
