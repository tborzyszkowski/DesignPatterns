package openclose;

public class TestGraphicEditor {

	public static void main(String[] args) {
		GraphicEditor geb = new GraphicEditor();
		
		Shape sh;
		
		sh = new Rectangle();
		geb.drawShape(sh);
		
		sh = new Circle();
		geb.drawShape(sh);

	}

}
