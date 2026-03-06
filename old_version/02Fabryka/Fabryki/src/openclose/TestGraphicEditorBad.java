package openclose;

public class TestGraphicEditorBad {

	public static void main(String[] args) {
		GraphicEditorBad geb = new GraphicEditorBad();
		
		ShapeBad sh;
		
		sh = new RectangleBad();
		geb.drawShape(sh);
		
		sh = new CircleBad();
		geb.drawShape(sh);

	}
}
