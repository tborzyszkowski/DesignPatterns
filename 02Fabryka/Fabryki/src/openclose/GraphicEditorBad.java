package openclose;

//Open-Close Principle - Bad example
class GraphicEditorBad {

	public void drawShape(ShapeBad s) {
		if (s.m_type==1)
			drawRectangle((RectangleBad)s);
		else if (s.m_type==2)
			drawCircle((CircleBad)s);
	}
	public void drawCircle(CircleBad r) {
		System.out.println("Circle");
	}
	public void drawRectangle(RectangleBad r) {
		System.out.println("Rectangle");
	}
}

class ShapeBad {
	int m_type;
}

class RectangleBad extends ShapeBad {
	RectangleBad() {
		super.m_type=1;
	}
}

class CircleBad extends ShapeBad {
	CircleBad() {
		super.m_type=2;
	}
} 

// Zadanie: dodaj do programu mo¿liwoœæ rysowania trójk¹ta