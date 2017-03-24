package openclose;

//Open-Close Principle - Good example
class GraphicEditor {
	public void drawShape(Shape s) {
		s.draw();
	}
}

abstract class Shape {
	abstract void draw();
}

class Rectangle extends Shape  {
	public void draw() {
		System.out.println("Rectangle");
	}
} 

class Circle extends Shape  {
	public void draw() {
		System.out.println("Circle");
	}
}

//Zadanie: dodaj do programu mo¿liwoœæ rysowania trójk¹ta