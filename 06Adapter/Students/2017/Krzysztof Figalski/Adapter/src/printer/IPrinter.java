package printer;

import enums.DocumentTypes;

public interface IPrinter {

	public void print(DocumentTypes documentType, String document);

}
